<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>선언문VS스크립트릿</title>
    </head>
    <body>
        <%!
        	int a = 0;
        	String stuName = "김형민";
        	public String getName() {
        		return stuName;
        	}
        %>
        <%
        	int b = 0;
        	a++; b++;
        %>
        <h2><%=a %></h2>
        <h2><%=b %></h2>
        <h2>메서드 호출:<%=getName() %></h2>
    </body>
</html>
