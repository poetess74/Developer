<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page import = "java.util.Calendar" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>page디렉티브-import</title>
    </head>
    <body>
        <%
        	Calendar calendar = Calendar.getInstance();
        %>
        오늘은
        <br>
        <%=calendar.get(Calendar.YEAR) %> 년
        <%=calendar.get(Calendar.MONTH) + 1 %> 월
        <%=calendar.get(Calendar.DATE) %> 일 
        <br>
        입니다. 
    </body>
</html>
