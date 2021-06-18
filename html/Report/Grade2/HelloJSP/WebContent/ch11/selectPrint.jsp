<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*, javax.sql.*, javax.naming.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>레코드 표시 - 커넥션풀</title>
    </head>
    <body>
        <h2>member 테이블의 레코드 표시</h2>
        <table border="1">
            <tr>
                <td width="100">아이디</td>
                <td width="100">비밀번호</td>
                <td width="100">이름</td>
                <td width="250">이메일</td>
            </tr>
            <%
                Connection connection = null;
                PreparedStatement preparedStatement = null;
                ResultSet result = null;
                try {
                    Context initCtx = new InitialContext();
                    Context envCtx = (Context) initCtx.lookup("java:comp/env");
                    DataSource dataSource = (DataSource)envCtx.lookup("jdbc/hellojsp");
                    connection = dataSource.getConnection();
                    String executeSQL = "SELECT * FROM member";
                    preparedStatement = connection.prepareStatement(executeSQL);
                    result = preparedStatement.executeQuery();
                    while (result.next()) {
                    	String id = result.getString("member_id");
                        String pw = result.getString("member_pw");
                        String name = result.getString("member_name");
                        String email = result.getString("member_email");
            %>
            <tr>
                <td width="100"><%=id%></td>
                <td width="100"><%=pw%></td>
                <td width="100"><%=name%></td>
                <td width="250"><%=email%></td>
            </tr>
            <%
                    }
                } catch(Exception e) {
                    e.printStackTrace();
                } finally {
                	if (result != null) {
                		try {
                			result.close();
                        } catch(SQLException e) { }
                    }
                	if (preparedStatement != null) {
                		try {
                			result.close();
                        } catch(SQLException e) { }
                    }
                	if (connection != null) {
                		try {
                			connection.close();
                        } catch(SQLException e) { }
                    }
                }
            %>
        </table>
    </body>
</html>
