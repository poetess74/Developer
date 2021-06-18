<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page import="java.sql.Timestamp" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>top.jsp</title>
    </head>
    <body>
        <%
        	Timestamp current = new Timestamp(System.currentTimeMillis());
        %>
        top.jsp입니다. <p>
        <%=current.toString() %>
        <hr>
    </body>
</html>
