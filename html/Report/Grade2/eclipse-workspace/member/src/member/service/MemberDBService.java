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

// Member 관련 데이터베이스 인터페이스를 제공하는 서비스 클래스
public class MemberDBService {
	// MemberDBService를 매번 새로 생성하지 않기 위해 인스턴스를 유지하기 위한 전역 변수
    private static MemberDBService instance;
    
    private DataSource dataSource;
    
    // MemberDBService를 얻어오기 위해 사용하는 스테틱 메소드
    public static MemberDBService getInstance() {
        // instance 가 존재하지 않을 경우 새로 생성
        if (instance == null) {
            instance = new MemberDBService();
            instance.initialize();
        }
        
        return instance;
    }
    
    // 문자열에 ', " 가 나올경우 이스케이프 문자 삽입하는 메소드
    public static String escapeJS(String s) {
        return s.replaceAll("\"", "\\\\\"").replaceAll("'", "\\\\'");
    }
    
    // MemberDBService.getInstance()를 통해서만 인스턴스를 얻을 수 있도록 기본 생성자를 private로 선언
    private MemberDBService() {
        // empty
    }
    
    // 데이터베이스 연결 초기화
    public void initialize() {
        try {
            var initialContext = new InitialContext();
            var envContext = (Context)initialContext.lookup("java:comp/env");
            
            dataSource = (DataSource)envContext.lookup("jdbc/MEMBERDB");
        } catch (NamingException e) {
            instance = null; // DB 연결시 오류가 발생하면 instance를 null로 초기화 하여 다음번에 새로 생성될 수 있도록 함
            
            e.printStackTrace();
            throw new RuntimeException("데이터베이스 서비스 초기화에 실패하였습니다.");
        }
    }
    
    // 데이터베이스 관련 리소스를 안전하게 닫기 위해 사용하는 유틸리티 메소드
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
    
    // 새로운 회원 가입
    public void registerMember(Member member) throws MemberDBException {
        // ID 중복 확인
        final String sql_checkDupUserId = 
                  "SELECT COUNT(1) FROM MEMBER WHERE USER_ID = ?";
        // 사용자 정보 중복 확인
        final String sql_checkDupUserInfo = 
                  "SELECT COUNT(1) FROM MEMBER "
                + " WHERE NAME       = ?       "
                + "   AND SCHOOL     = ?       "
                + "   AND DEPARTMENT = ?       "
                + "   AND STUDENT_ID = ?       ";
        
        // 새로운 회원 정보 등록
        final String sql = "INSERT INTO MEMBER VALUES (?, ?, ?, ?, ?, ?, ?)";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = dataSource.getConnection();
            
            // USER_ID 중복여부 확인
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
            
            // 사용자 정보 중복여부 확인
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
            
            // 중복된 정보가 없다면 새로운 회원 정보 등록
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
            e.printStackTrace(); // LOG 파일에 오류 기록
            // 데이터베이스 관련 예외를 호출한 쪽으로 전달하여 처리하도록 함
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
        	// 메소드에서 리턴하기 전 열려있는 데이터베이스 리소스 정리
            safeClose(conn, stmt, rs);
        }
    }
    
    // 회원 정보 가져오기
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
            e.printStackTrace(); // LOG 파일에 오류 기록
        } finally {
        	// 메소드에서 리턴하기 전 열려있는 데이터베이스 리소스 정리
            safeClose(conn, stmt, rs);
        }

        // 오류가 발생했거나 사용자 정보를 찾을 수 없다면 null을 리턴
        return null;
    }
    
    // 회원 목록 가져오기
    public List<Member> getMembers() {
        final String sql = "SELECT * FROM MEMBER ORDER BY USER_ID"; // USER_ID 순으로 정렬
        
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        // 회원 목록을 담을 ArrayList 생성
        var members = new ArrayList<Member>();
        
        try {
            conn = dataSource.getConnection();
            stmt = conn.prepareStatement(sql);
            
            rs = stmt.executeQuery();
            
            while (rs.next()) {
            	// Member.create() 메소드를 이용하여 Member 인스턴스를 생성 후 ArrayList에 추가
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
            e.printStackTrace(); // LOG 파일에 오류 기록
        } finally {
        	// 메소드에서 리턴하기 전 열려있는 데이터베이스 리소스 정리
            safeClose(conn, stmt, rs);
        }
        
        // 조회된 회원 목록 리턴, 데이터베이스 조회 중 오류가 발생했다면 빈 목록이 리턴 됨
        return members;
    }
    
    // 회원 정보 수정
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
            
            // UPDATE로 영향받은 ROW의 수가 1이 아니면 회원정보를 찾지 못한 것으로 볼 수 있음(USER_ID는 PK라 중복 불가)
            if (stmt.executeUpdate() != 1) {
                // 회원 정보를 찾을 수 없다면 예외를 생성하여 호출 측으로 전달
                throw new MemberDBException("등록된 사용자를 찾을 수 없습니다.");
            }
        } catch (SQLException e) {
            e.printStackTrace(); // LOG 파일에 오류 기록
            // 데이터베이스 관련 예외를 호출한 쪽으로 전달하여 처리하도록 함
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
        	// 메소드에서 리턴하기 전 열려있는 데이터베이스 리소스 정리
            safeClose(conn, stmt, rs);
        }
    }
    
    // 회원 정보 삭제
    public void deleteMember(String userId) throws MemberDBException {
        final String sql = "DELETE FROM MEMBER WHERE USER_ID = ?";
        
        Connection conn = null;
        PreparedStatement stmt = null;
        
        try {
            conn = dataSource.getConnection();
            
            stmt = conn.prepareStatement(sql);
            stmt.setString(1, userId);
            
            // DELETE로 영향받은 ROW의 수가 1이 아니면 회원정보를 찾지 못한 것으로 볼 수 있음(USER_ID는 PK라 중복 불가)
            if (stmt.executeUpdate() != 1) {
                // 회원 정보를 찾을 수 없다면 예외를 생성하여 호출 측으로 전달
                throw new MemberDBException("삭제할 사용자를 찾을 수 없습니다.");
            }
        } catch (SQLException e) {
            e.printStackTrace(); // LOG 파일에 오류 기록
            // 데이터베이스 관련 예외를 호출한 쪽으로 전달하여 처리하도록 함
            throw new MemberDBException("데이터베이스 오류가 발생하였습니다.(SQL-ERROR=" + e.getErrorCode() + ")");
        } finally {
        	// 메소드에서 리턴하기 전 열려있는 데이터베이스 리소스 정리
            safeClose(conn, stmt, null);
        }
    }
}
