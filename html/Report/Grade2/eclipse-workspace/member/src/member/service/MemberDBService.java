package member.service;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;

import member.data.Member;

public class MemberDBService {
    private static MemberDBService instance;
    
    private DataSource dataSource;
    
    public static MemberDBService getInstance() {
        if (instance == null) {
            instance = new MemberDBService();
            instance.initialize();
        }
        
        return instance;
    }
    
    public static String escapeJS(String s) {
        return s.replaceAll("\"", "\\\\\"").replaceAll("'", "\\\\'");
    }
    
    private MemberDBService() {
        // empty method body
    }
    
    public void initialize() {
        try {
            var initialContext = new InitialContext();
            var envContext = (Context)initialContext.lookup("java:comp/env");
            
            dataSource = (DataSource)envContext.lookup("jdbc/MEMBERDB");
        } catch (NamingException e) {
            instance = null;
            
            e.printStackTrace();
            throw new RuntimeException("데이터베이스 서비스 초기화에 실패하였습니다.");
        }
    }
    
    private void safeClose(Connection conn, PreparedStatement stmt, ResultSet rs) {
        if (rs != null) {
            try {
                rs.close();
            } catch (SQLException e) { /* empty */ } 
        }
        
        if (stmt != null) {
            try {
                stmt.close();
            } catch (SQLException e) { /* empty */ } 
        }
        
        if (conn != null) {
            try {
                conn.close();
            } catch (SQLException e) { /* empty */ } 
        }
    }
    
    public void registerMember(Member member) throws MemberDBException {
        final String sql_checkDupUserId = 
                  "SELECT COUNT(1) FROM MEMBER WHERE USER_ID = ?";
        final String sql_checkDupUserInfo = 
                  "SELECT COUNT(1) FROM MEMBER "
                + " WHERE NAME       = ?       "
                + "   AND SCHOOL     = ?       "
                + "   AND DEPARTMENT = ?       "
                + "   AND STUDENT_ID = ?       ";
        
        final String sql = "INSERT INTO MEMBER VALUES (?, ?, ?, ?, ?, ?, ?)";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = dataSource.getConnection();
            
            // check duplicated user_id
            stmt = conn.prepareStatement(sql_checkDupUserId);
            stmt.setString(1, member.getUserId());
            
            rs = stmt.executeQuery();
            
            if (rs.next()) {
                if (rs.getInt(1) != 0) {
                    throw new MemberDBException("이미 사용중인 아이디 입니다.");
                }
            }
            
            rs.close();
            stmt.close();
            
            // check duplicated user info
            stmt = conn.prepareStatement(sql_checkDupUserInfo);
            stmt.setString(1, member.getName());
            stmt.setString(2, member.getSchool());
            stmt.setString(3, member.getDepartment());
            stmt.setString(4, member.getStudentId());
            
            rs = stmt.executeQuery();
            
            if (rs.next()) {
                if (rs.getInt(1) != 0) {
                    throw new MemberDBException("이미 등록된 사용자 입니다.");
                }
            }
            
            rs.close();
            stmt.close();
            
            // insert
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, member.getUserId());
            stmt.setString(2, member.getPassword()); 
            stmt.setBoolean(3, member.isAdmin()); 
            stmt.setString(4, member.getName());
            stmt.setString(5, member.getSchool()); 
            stmt.setString(6, member.getDepartment()); 
            stmt.setString(7, member.getStudentId());
            
            if (stmt.executeUpdate() != 1) {
                throw new MemberDBException("알 수 없는 오류로 사용자 등록에 실패하였습니다.");
            }
        } catch (SQLException e) {
            e.printStackTrace(); // dump to log
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
            safeClose(conn, stmt, rs);
        }
    }
    
    public Member getMember(String userId) {
        final String sql = "SELECT * FROM MEMBER WHERE USER_ID = ?";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = dataSource.getConnection();
            
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, userId);
            
            rs = stmt.executeQuery();
            
            if (rs.next()) {
                return Member.create(
                        rs.getString("USER_ID"),
                        rs.getString("PASSWORD"),
                        rs.getBoolean("IS_ADMIN"),
                        rs.getString("NAME"),
                        rs.getString("SCHOOL"),
                        rs.getString("DEPARTMENT"),
                        rs.getString("STUDENT_ID"));
                        
            }
        } catch (SQLException e) {
            e.printStackTrace(); // dump to log
        } finally {
            safeClose(conn, stmt, rs);
        }
        
        return null;
    }
    
    public List<Member> getMembers() {
        final String sql = "SELECT * FROM MEMBER ORDER BY USER_ID";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        var members = new ArrayList<Member>();
        
        try {
            conn = dataSource.getConnection();
            stmt = conn.prepareStatement(sql);
            
            rs = stmt.executeQuery();
            
            while (rs.next()) {
                members.add(Member.create(
                        rs.getString("USER_ID"),
                        rs.getString("PASSWORD"),
                        rs.getBoolean("IS_ADMIN"),
                        rs.getString("NAME"),
                        rs.getString("SCHOOL"),
                        rs.getString("DEPARTMENT"),
                        rs.getString("STUDENT_ID")));
                        
            }
        } catch (SQLException e) {
            e.printStackTrace(); // dump to log
        } finally {
            safeClose(conn, stmt, rs);
        }
        
        return members;
    }
    
    public void updateMember(Member member) throws MemberDBException {
        final String sql = 
                  "UPDATE MEMBER         "
                + "   SET PASSWORD   = ? "
                + "     , IS_ADMIN   = ? "
                + "     , NAME       = ? "
                + "     , SCHOOL     = ? "
                + "     , DEPARTMENT = ? "
                + "     , STUDENT_ID = ? "
                + " WHERE USER_ID    = ? ";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = dataSource.getConnection();
            
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, member.getPassword()); 
            stmt.setBoolean(2, member.isAdmin()); 
            stmt.setString(3, member.getName());
            stmt.setString(4, member.getSchool()); 
            stmt.setString(5, member.getDepartment()); 
            stmt.setString(6, member.getStudentId());
            stmt.setString(7, member.getUserId());
            
            if (stmt.executeUpdate() != 1) {
                throw new MemberDBException("등록된 사용자를 찾을 수 없습니다.");
            }
        } catch (SQLException e) {
            e.printStackTrace(); // dump to log
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
            safeClose(conn, stmt, rs);
        }
    }
    
    public void deleteMember(String userId) throws MemberDBException {
        final String sql = "DELETE FROM MEMBER WHERE USER_ID = ?";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        
        try {
            conn = dataSource.getConnection();
            
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, userId);
            
            if (stmt.executeUpdate() != 1) {
                throw new MemberDBException("삭제할 사용자를 찾을 수 없습니다.");
            }
        } catch (SQLException e) {
            e.printStackTrace(); // dump to log
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
            safeClose(conn, stmt, null);
        }
    }
}
