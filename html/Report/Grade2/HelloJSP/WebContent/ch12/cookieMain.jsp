<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%
    String id = "";
    try {
    	Cookie[] cookies = request.getCookies();
    	if (cookies != null) {
            for(Cookie cookie : cookies) {
                if(cookie.getName().equals("id")) {
                    id = cookie.getValue();
                }
            }
            if (id.equals("")) {
            	response.sendRedirect("loginForm.jsp");
            }
        } else {
    		response.sendRedirect("loginForm.jsp");
        }
    } catch(Exception e) { }
%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>쿠키를 사용한 간단한 회원인증</title>
    </head>
    <body>
        <b><%=id%></b>님이 로그인 하셨습니다.
        <form method="post" action="logout.jsp">
            <input type="submit" value="로그아웃"/>
        </form>
    </body>
</html>