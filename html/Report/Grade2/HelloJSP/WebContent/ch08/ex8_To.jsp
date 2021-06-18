<%@ page language="java" contentType="text/html; charset=UTF-8"
     pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("utf-8"); %>
<%
    String to_id = request.getParameter("id");
    String to_pw = request.getParameter("passwd");
%>

<h2>ex8_To.jsp 수행결과</h2>

아이디: <%=to_id%><br>
패스워드: <%=to_pw%>
