<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page errorPage="exception.jsp" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>null Exception</title>
    </head>
    <body>
        <%
        	String nullStr = null;
        	System.out.println(nullStr.toString());
        %>
    </body>
</html>
