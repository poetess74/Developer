<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page buffer="1kb" autoFlush="true" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>page 디렉티브-buffer/autoFlush</title>
    </head>
    <body>
        <h1>page 디렉티브-buffer/autoFlush</h1>
        <hr>
        <%
        	for(int i = 1; i <= 1000; i++) {
        %>
        buffer/autoFlush 실습 : 컴공-20194315-김형민
        <%
        	}
        %>
    </body>
</html>
