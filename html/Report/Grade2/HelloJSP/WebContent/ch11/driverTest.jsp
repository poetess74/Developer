<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>JDBC 드라이버 테스트</title>
    </head>
    <body>
        <%
            Connection connection = null;
            try {
            	String jdbcURL = "jdbc:mysql://localhost:3306/basicjsp?serverTimezone=UTC";
            	String dbID = "jspid";
            	String dbPW = "jsppass";

            	Class.forName("com.mysql.cj.jdbc.Driver");
            	connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
            	out.println("Connection OK");
            } catch(Exception e) {
            	e.printStackTrace();
            }
        %>
    </body>
</html>
