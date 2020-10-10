<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>pageContext 내장객체</title>
    </head>
    <body>
        <h2>pageContextTest1.jsp에서 포워딩한 페이지</h2>
        <%
            pageContext.include("pageContextTest3.jsp");
        %>
    </body>
</html>