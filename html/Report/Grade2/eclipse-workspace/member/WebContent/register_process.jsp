<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>
<%@ page import="member.service.MemberDBException" %>

<% request.setCharacterEncoding("utf-8"); %>

<jsp:useBean id="member" scope="page" class="member.data.Member"/>
<jsp:setProperty name="member" property="*"/>

<%
    try {
        MemberDBService.getInstance().registerMember(member);
    } catch (MemberDBException e) {
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back(); // back to the register_form.jsp
</script>
<%
        return;
    }
%>
<script>
    alert("<%= member.getName() %>님 환영합니다. 입력한 정보로 로그인 해 주십시오.");
    window.location.href = "login_form.jsp";
</script>