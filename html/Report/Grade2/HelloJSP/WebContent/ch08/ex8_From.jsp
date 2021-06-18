<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<% request.setCharacterEncoding("utf-8"); %>

<%
    String from_id = request.getParameter("id");
    String from_pw = request.getParameter("passwd");

    if(from_id == null || from_id.equals("")) { from_id = "test"; }
    if(from_pw == null || from_pw.equals("")) { from_pw = "testwd"; }
%>

ex8_To.jsp 페이지로 포워딩 합니다. <br>
<jsp:forward page="ex8_To.jsp">
    <jsp:param name="id" value="<%=from_id%>"/>
    <jsp:param name="passwd" value="<%=from_pw%>"/>
</jsp:forward>