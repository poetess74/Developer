<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%!
	public int sum(int a, int b) {
		return a + b;
	}
%>
<%
	String str1 = "1 + 2의 합";
	String[] str2 = { "JSP", "Java", "Android", "HTML" };
	int index = (int)(Math.random() * 4);
%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>표현식</title>
    </head>
    <body>
        <%= "1 + 2의 합" %>은 <%= 1 + 2 %>입니다. <br>
        <%= str1 %>은 <%=sum(1, 2) %>입니다. <br>
        <%= str1 %>에 3을 곱하면 <%=sum(1, 2) * 3 %>이 됩니다. <br>
        <%= str2[index] %>를 공부합니다. <br>
    </body>
</html>
