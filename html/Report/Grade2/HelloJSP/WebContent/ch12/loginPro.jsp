<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="ch12.member.LogonDBBean" %>
<% request.setCharacterEncoding("utf-8"); %>
<%
    String id = request.getParameter("id");
    String pw = request.getParameter("pw");

    LogonDBBean logon = LogonDBBean.getInstance();

    boolean check = logon.userCheck(id, pw);

    if (check) {
    	Cookie cookie = new Cookie("id", id);
    	cookie.setMaxAge(20 * 60);
    	response.addCookie(cookie);
    	response.sendRedirect("cookieMain.jsp");
    } else {
%>
        <script>
            alert("아이디 또는 비밀번호가 틀립니다");
            history.go(-1);
        </script>
<%
    }
%>