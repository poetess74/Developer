<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>선언문VS스크립트릿VS표현식</title>
    </head>
    <body>
        <%! String str1 = "전역변수"; %>
        <% String str2 = "지역변수"; %>
        선언문에서 선언한 변수는
        <%= str1 %><br> 스크립트릿에서 선언한 변수는
        <%= str2 %>
    </body>
</html>
