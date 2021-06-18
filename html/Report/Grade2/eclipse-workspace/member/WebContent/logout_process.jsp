<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%
    // 세션에 저장된 회원 정보 폐기 후 로그인 페이지로 이동
    session.invalidate();
    response.sendRedirect("login_form.jsp");
%>
