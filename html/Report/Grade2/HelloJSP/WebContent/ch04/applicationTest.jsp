<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<%
    out.println("ch04폴더의 applicationTest.jsp페이지입니다.<br>");
    out.println("ch07폴더의 applicationAttribute.jsp에서 attribute의 값은 : ");

    // application내장 객체의 Attribute 가져오기
    out.println(application.getAttribute("HyeongminKim"));
%>
