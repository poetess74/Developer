<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page import="java.text.SimpleDateFormat" %>
<%@ page import="java.util.Date" %>

<%@ page session="true" %>

<%
	Date time = new Date();
	SimpleDateFormat simpleDate = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>page디렉티브 - session</title>
    </head>
    <body>
        <h2>page디렉티브 연습 - session 속성</h2>
        세션 ID : <%=session.getId() %><br>

        <% time.setTime(session.getCreationTime()); %>
        세션 생성 시간 : <%=simpleDate.format(time) %><br>

        <% time.setTime(session.getLastAccessedTime()); %>
        마지막 접속 시간 : <%=simpleDate.format(time) %><br>
        
        기본 유지 시간 : <%=session.getMaxInactiveInterval() %>s<br>
        <% session.setMaxInactiveInterval(1); %>
        변경 유지 시간 : <%=session.getMaxInactiveInterval() %>s<br>
    </body>
</html>
