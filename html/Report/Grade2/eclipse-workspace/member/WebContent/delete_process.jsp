<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>
<%@ page import="member.service.MemberDBException" %>

<% request.setCharacterEncoding("utf-8"); %>

<jsp:useBean id="member" scope="session" class="member.data.Member"/>

<jsp:useBean id="requestMember" scope="page" class="member.data.Member"/>
<jsp:setProperty name="requestMember" property="*"/>

<%
    // 관리자가 아닐경우 alert을 띄운 후 로그아웃
    if (!member.isAdmin()) {
%>
<script>
    alert("회원정보 삭제는 관리자만 가능합니다.\n보안을 위해 로그아웃 합니다.");
    window.location.href = "logout_process.jsp";
</script>
<%
        return;
    }
    
    try {
    	// 데이터베이스 서비스를 호출하여 대상 회원정보 삭제
    	MemberDBService.getInstance().deleteMember(requestMember.getUserId());
    } catch (MemberDBException e) {
    	// 삭제 도중 예외가 발생하면, 오류 메시지를 alert으로 띄운 후 이전 페이지로 돌아감
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back();
</script>
<%
        return;
    }
    
    // 삭제 완료 alert을 띄운 후 회원정보 페이지로 이동
%>
<script>
    alert("삭제되었습니다.");
    window.location.href = "member_info_form.jsp";
</script>
