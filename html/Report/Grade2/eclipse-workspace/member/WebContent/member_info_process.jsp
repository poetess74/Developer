<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>
<%@ page import="member.service.MemberDBException" %>

<% request.setCharacterEncoding("utf-8"); %>

<jsp:useBean id="member" scope="session" class="member.data.Member"/>

<jsp:useBean id="modifiedMember" scope="page" class="member.data.Member"/>
<jsp:setProperty name="modifiedMember" property="*"/>

<%
    if (member.getUserId() != null && member.getUserId().compareTo(modifiedMember.getUserId()) != 0) {
%>
<script>
    alert("본인의 정보만 수정할 수 있습니다.\n보안을 위해 로그아웃 합니다.");
    window.location.href = "logout_process.jsp";
</script>
<%
        return;
    }

    // admin privileges use the value stored in the session
    modifiedMember.setAdmin(member.isAdmin());
    
    // if the password is empty, use the old password
    String newPassword = modifiedMember.getPassword();
    if (newPassword == null || newPassword.isEmpty()) {
        modifiedMember.setPassword(member.getPassword());
    }
    
    try {
    	MemberDBService.getInstance().updateMember(modifiedMember);
    } catch (MemberDBException e) {
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back(); // back to the member_info_form.jsp
</script>
<%
        return;
    }
    
    // update session value with modified member information
    session.setAttribute("member", modifiedMember);
%>
<script>
    alert("회원 정보가 갱신되었습니다.");
    window.location.href = "member_info_form.jsp";
</script>