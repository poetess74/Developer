<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%
    response.setHeader("Refresh", "5") ;
%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>response 내장객체</title>
    </head>
    <body>
        <%!int i = 0;%>
        <%i++;%>
        <h2><%=i%>번째 방문입니다. </h2><br>
        5초 후 다시 방문합니다. <br>
    </body>
</html>