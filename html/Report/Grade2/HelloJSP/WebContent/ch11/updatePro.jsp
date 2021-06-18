<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*" %>
<% request.setCharacterEncoding("UTF-8"); %>
<%
    String id = request.getParameter("id");
    String passwd = request.getParameter("pw");
    String name = request.getParameter("name");

    Connection connection = null;
    PreparedStatement preparedStatement = null;
    ResultSet result = null;

    try {
        String jdbcURL = "jdbc:mysql://localhost:3306/basicjsp?serverTimezone=UTC";
        String dbID = "jspid";
        String dbPW = "jsppass";

        Class.forName("com.mysql.cj.jdbc.Driver");
        connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
        String executeSQL = "SELECT member_id, member_pw FROM member WHERE member_id = ?";
        preparedStatement = connection.prepareStatement(executeSQL);
        preparedStatement.setString(1, id);
        result = preparedStatement.executeQuery();
        if (result.next()) {
        	String rID = result.getString("member_id");
            String rPW = result.getString("member_pw");
            if (id.equals(rID) && passwd.equals(rPW)) {
            	executeSQL = "UPDATE member SET member_name = ? WHERE member_id = ?";
            	preparedStatement = connection.prepareStatement(executeSQL);
            	preparedStatement.setString(1, name);
                //noinspection JpaQueryApiInspection
                preparedStatement.setString(2, id);
                preparedStatement.executeUpdate();
                %>
<html>
    <head>
        <meta charset="UTF-8">
        <title>레코드 수정</title>
    </head>
    <body>
        <jsp:forward page="selectPrint.jsp"></jsp:forward>
        member 테이블의 레코드를 수정했습니다.
    </body>
</html>
<%
            } else {
            	out.println("패스워드가 틀렸습니다. ");
            }
        } else {
        	out.println("아이디가 틀렸습니다. ");
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
    			preparedStatement.close();
            } catch(SQLException e) { }
        }
    	if (connection != null) {
    		try {
    			connection.close();
            } catch(SQLException e) { }
        }
    }
%>

