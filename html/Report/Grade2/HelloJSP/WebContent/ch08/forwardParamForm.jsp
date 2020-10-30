<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>

<% request.setCharacterEncoding("utf-8"); %>
<%
    String id = "20194315";
    String hobby = "코딩하기";
%>

포워딩 하는 페이지 forwardParamForm.jsp 입니다.

<jsp:forward page="forwardParamTo.jsp">
    <jsp:param name="id" value="<%=id%>"/>
    <jsp:param name="hobby" value="<%=hobby%>"/>
</jsp:forward>
