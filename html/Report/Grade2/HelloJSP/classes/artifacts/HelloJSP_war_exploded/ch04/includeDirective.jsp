<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>include 디렉티브</title>
    </head>
    <body>
        <h2>include디렉티브</h2>
        <%String name = "Kim"; %>
        <%@ include file="top.jsp" %>
        include디렉티브 실습자 : 컴공/20194315/김형민
        <%@ include file="bottom.jsp" %>
    </body>
</html>
