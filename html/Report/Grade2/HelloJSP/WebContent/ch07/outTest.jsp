<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>out 내장 객체</title>
    </head>
    <body>
        <h2>out 내장 객체</h2>
        <%
            String name = "김형민";
            out.println("내 이름은 <b>" + name + "</b> 입니다.");
            out.println("내 이름은 <b>" + name + "</b> 입니다.");
        %>
        <br>
        <%
            out.print("내 이름은 <b>" + name + "</b> 입니다.");
            out.print("내 이름은 <b>" + name + "</b> 입니다.");
        %>
        <h2>위와 같은 내용 출력 - 표현식</h2>
        내 이름은 <b><%=name %></b> 입니다.
    </body>
</html>
