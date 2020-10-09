<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%
    // 헤더 추가하기
    response.addHeader("testKey", "JSP20201007");
// 헤더값을 "본인 학번"으로 변경하기
    response.setHeader("testKey", "20194315") ;
// 헤더 추가하기
    response.addHeader("JSP", "JSP2020");

    out.println("response 내장 객체");
//    response.setContentType("application/zip");
%>