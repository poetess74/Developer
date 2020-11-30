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
    	// 데이터베이스 서비스를 호출하여 입력된 회원정보를 등록
        MemberDBService.getInstance().registerMember(member);
    } catch (MemberDBException e) {
    	// 등록 중 예외가 발생하면, 오류 메시지를 alert으로 띄운 후 이전 페이지로 돌아감
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back();
</script>
<%
        return;
    }

    // 정상 등록 후 환영 메시지를 alert로 띄운 후 로그인 페이지로 이동
%>
<script>
    alert("<%= member.getName() %>님 환영합니다. 입력한 정보로 로그인 해 주십시오.");
    window.location.href = "login_form.jsp";
</script>