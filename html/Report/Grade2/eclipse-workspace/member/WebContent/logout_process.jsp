<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%
    // 세션 소멸후 로그인 페이지로
    session.invalidate();
    response.sendRedirect("login_form.jsp");
%>
