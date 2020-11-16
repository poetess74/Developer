<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*" %>
<% request.setCharacterEncoding("UTF-8"); %>
<%
    String id = request.getParameter("id");
    String passwd = request.getParameter("pw");
    String name = request.getParameter("name");
    String email = request.getParameter("email");

    Connection connection = null;
    PreparedStatement preparedStatement = null;
    String str = "";

    try {
        String jdbcURL = "jdbc:mysql://localhost:3306/basicjsp?serverTimezone=UTC";
        String dbID = "jspid";
        String dbPW = "jsppass";

        Class.forName("com.mysql.cj.jdbc.Driver");
        connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
        String executeSQL = "INSERT INTO member VALUES (?, ?, ?, ?)";
        preparedStatement = connection.prepareStatement(executeSQL);
        preparedStatement.setString(1, id);
        preparedStatement.setString(2, passwd);
        preparedStatement.setString(3, name);
        preparedStatement.setString(4, email);
        preparedStatement.executeUpdate();
        str = "member 테이블에 새로운 레코드를 추가하였습니다. ";
    } catch(Exception e) {
        e.printStackTrace();
        str = "member 테이블에 새로운 레코드 추가하는 도중 에러가 발생하였습니다. ";
    } finally {
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

<html>
    <head>
        <meta charset="UTF-8">
        <title>레코드 추가</title>
    </head>
    <body>
        <%=str%>
    </body>
</html>
