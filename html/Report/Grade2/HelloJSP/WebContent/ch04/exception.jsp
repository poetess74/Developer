<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page isErrorPage="true" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>서버 에러</title>
    </head>
    <body>
        서버에 문제가 발생하였습니다. 문제가 계속되면 고객센터에 문의 바랍니다. 
        <%
        	System.out.println("Exception class: " + exception.getClass().getName());
        	System.out.println("Exception info: " + exception.getMessage());
        %>
    </body>
</html>
