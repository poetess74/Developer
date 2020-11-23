<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>

<% request.setCharacterEncoding("utf-8"); %>

<jsp:useBean id="member" scope="page" class="member.data.Member">
	<jsp:setProperty name="member" property="*"/>
</jsp:useBean>

<%
	try {
		MemberDBService.getInstance().registerMember(member);
	} catch (RuntimeException e) {
%>
<script language="javascript">
	alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
	window.history.back(); // back to the register_form.jsp
</script>
<%
	}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원정보관리::회원가입결과</title>
</head>
<body>
<h1>성공!</h1>
</body>
</html>