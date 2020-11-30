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
    // 현재 회원 정보가 세션에 존재하지 않거나, 본인의 정보가 아니면 alert을 띄운 후 로그아웃 
    if (member.getUserId() != null && member.getUserId().compareTo(modifiedMember.getUserId()) != 0) {
%>
<script>
    alert("본인의 정보만 수정할 수 있습니다.\n보안을 위해 로그아웃 합니다.");
    window.location.href = "logout_process.jsp";
</script>
<%
        return;
    }

    // 관리자 권한 여부는 현재 세션에 저장되어 있는 회원 정보의 값을 사용
    modifiedMember.setAdmin(member.isAdmin());
    
    // 입력된 패스워드가 빈 값이면, 이전 패스워드 사용
    String newPassword = modifiedMember.getPassword();
    if (newPassword == null || newPassword.isEmpty()) {
        modifiedMember.setPassword(member.getPassword());
    }
    
    try {
    	// 회원 정보를 데이터베이스 서비스를 호출하여 업데이트
    	MemberDBService.getInstance().updateMember(modifiedMember);
    } catch (MemberDBException e) {
    	// 업데이트 중 예외가 발생하면, 오류 메시지를 alert으로 띄운 후 이전 페이지로 돌아감
%>
<script>
    alert("<%= MemberDBService.escapeJS(e.getMessage()) %>");
    window.history.back();
</script>
<%
        return;
    }
    
    // 업데이트가 성공했다면 세션에 저장된 회원 정보를 변경된 정보로 설정
    session.setAttribute("member", modifiedMember);
    
    // 업데이트 완료 alert을 띄운 후 회원정보 페이지로 이동
%>
<script>
    alert("회원 정보가 갱신되었습니다.");
    window.location.href = "member_info_form.jsp";
</script>
