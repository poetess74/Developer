<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<jsp:useBean id="userCache" class="service.user.UserCache"></jsp:useBean>
<%
    System.out.println(request.getServletPath());
    switch(request.getServletPath()) {
        case "/index.jsp":
        	userCache.setID((String) request.getAttribute("userID"));
            userCache.setPW((String) request.getAttribute("userPW"));
            break;
        default:
            System.err.println("Sneaky redirects");
            out.println("<script>alert('확인되지 않은 예외가 발생하였습니다. 메인 페이지로 리디렉션 됩니다. ');</script>");
            response.sendRedirect((String) session.getAttribute("index.jsp"));
            break;
    }
%>
<%!
    Connection connection = null;
    PreparedStatement initialize = null;
    ResultSet result = null;
%>

<head>
    <meta charset="UTF-8">
    <title>리디렉션 중...</title>
</head>

<%
    try {
        final String jdbcURL = "jdbc:mysql://localhost:3306/userdb?serverTimezone=UTC";
        final String dbID = "report_only";
        final String dbPW = "report";
        final String exeSQL = "SELECT uid, upw FROM user";
        Class.forName("com.mysql.cj.jdbc.Driver");
        connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
        System.out.println("Connection established.");
        initialize = connection.prepareStatement(exeSQL);
        result = initialize.executeQuery();
    } catch(Exception e) {
        System.out.println("Connection refused. ");
        e.printStackTrace();
    }
%>
