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
    //관리자가 아닐경우 alert을 띄운후 로그아웃
    if (!member.isAdmin()) {
%>
<script>
    alert("회원정보 삭제는 관리자만 가능합니다.\n보안을 위해 로그아웃 합니다.");
    window.location.href = "logout_process.jsp";
</script>
<%
        return;
    }
    
    //정상 접근일 경우 타겟 회원 삭제
    try {
    	MemberDBService.getInstance().deleteMember(requestMember.getUserId());
    } catch (MemberDBException e) {
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back(); // back to the member_info_form.jsp
</script>
<%
        return;
    }
%>
<script>
    alert("삭제되었습니다.");
    window.location.href = "member_info_form.jsp";
</script>
