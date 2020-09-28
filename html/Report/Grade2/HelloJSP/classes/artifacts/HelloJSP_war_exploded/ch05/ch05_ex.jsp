<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<%!
    String name = "김형민";
    String id = "20194315";
    public String getName() { return name; }
    public String getId() { return id; }
%>
<%
    String hobby = "음악 감상";
%>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>ch05_ex</title>
    </head>
    <body>
        <h2>ch05_ex</h2>
        이름: <%=getName()%><br>
        학번: <%=getId()%><br>
        취미: <%=hobby%><br>
    </body>
</html>
