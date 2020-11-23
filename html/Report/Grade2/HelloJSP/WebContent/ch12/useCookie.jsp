<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>웹 브라우저에 저장된 쿠키를 가져오기</title>
    </head>
    <body>
        <h2>웹 브라우저에 저장된 쿠키를 가져오는 페이지</h2>
    <%
        Cookie[] cookies = request.getCookies();
        if (cookies != null) {
            for(Cookie cookie : cookies) {
                if(cookie.getName().equals("id")) {
    %>
        쿠키의 이름은 "<%=cookie.getName()%>"이고
        쿠키의 값은 "<%=cookie.getValue()%>" 입니다.
    <%
                }
            }
        }
    %>
    </body>
</html>