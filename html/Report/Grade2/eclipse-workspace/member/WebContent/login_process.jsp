<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>

<% request.setCharacterEncoding("utf-8"); %>

<%
    String userId = request.getParameter("userId");
    String password = request.getParameter("password");

    // 데이터베이스로 부터 입력된 userId에 해당하는 회원정보 조회
    Member memberInfo = MemberDBService.getInstance().getMember(userId);

    boolean error = false;
    String errorMessage = "";
    
    // 없는 회원 또는 잘못된 비밀번호 오류 메시지 설정
    if (memberInfo == null) {
        error = true;
        errorMessage = "사용자 정보를 찾을 수 없습니다.";
    } else if (memberInfo.getPassword().compareTo(password) != 0) {
        error = true;
        errorMessage = "비밀번호가 다릅니다.";
    }
    
    // 오류가 발생했다면 alert을 띄운 후 로그인 페이지로 돌아감
    if (error) {
%>
<script>
    alert("<%= errorMessage %>");
    window.history.back();
</script>
<%        
        return;
    }
    
    // 로그인에 성공했다면 세션에 현재 로그인한 회원정보 저장
    session.setAttribute("member", memberInfo);
    
    // 회원정보 페이지로 이동
    response.sendRedirect("member_info_form.jsp");
%>
