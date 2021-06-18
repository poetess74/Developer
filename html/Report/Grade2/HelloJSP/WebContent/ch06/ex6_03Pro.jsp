<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%
    String id = request.getParameter("id");
    String pw = request.getParameter("passwd");

    final String checkID = "abcd";
    final String checkPW = "z1234";

    if (id.equals(checkID) && pw.equals(checkPW)) {
        out.println("로그인에 성공하셨습니다. ");
    } else {
        out.println("로그인에 실패하셨습니다. ");
    }
%>