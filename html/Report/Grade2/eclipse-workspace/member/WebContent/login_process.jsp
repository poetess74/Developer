<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="member.data.Member" %>
<%@ page import="member.service.MemberDBService" %>

<% request.setCharacterEncoding("utf-8"); %>

<%
    String userId = request.getParameter("userId");
    String password = request.getParameter("password");

    Member memberInfo = MemberDBService.getInstance().getMember(userId);

    boolean error = false;
    String errorMessage = "";
    
    if (memberInfo == null) {
        error = true;
        errorMessage = "사용자 정보를 찾을 수 없습니다.";
    } else if (memberInfo.getPassword().compareTo(password) != 0) {
        error = true;
        errorMessage = "비밀번호가 다릅니다.";
    }
    
    if (error) {
%>
<script>
    alert("<%= errorMessage %>");
    window.history.back(); // back to the login_form.jsp
</script>
<%        
        return;
    }
    
    session.setAttribute("member", memberInfo);
    
    response.sendRedirect("member_info_form.jsp");
%>
