<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>주석 예제</title>
    </head>
    <body>
        <h2>주석 예제</h2>
        <hr>
        <%
        	String str = "컴공/20194315/김형민";
        %>
        <!-- HTML 주석 -->
        <!-- <%=str%> -->
        <%-- JSP 주석 --%>  
        <%-- <%=str%> --%>  
        <%
        	//JAVA 주석 
        	/* JAVA 주석 */
        %>
    </body>
</html>
