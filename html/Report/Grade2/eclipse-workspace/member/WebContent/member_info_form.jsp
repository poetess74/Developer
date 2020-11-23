<%@page import="member.service.MemberDBService"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.List"%>
<%@ page import="member.data.Member" %>
    
<jsp:useBean id="member" scope="session" class="member.data.Member"/>
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원정보관리::회원정보<%= member.isAdmin() ? "(관리자)" : "" %></title>
<link rel="stylesheet" type="text/css" href="css/style.css"/>
<script>
function logout() {
    window.location.href = "logout_process.jsp";
}

function deleteUser(userId) {
    window.location.href = "delete_process.jsp?userId=" + userId;
}
</script>
</head>
<body>
<header>
    <h1>회원정보수정</h1>
</header>
<section>
    <form name="member_info" method="post" action="member_info_process.jsp">
    <table class="center">
        <tr>
            <td class="right">아이디:</td>
            <td><input type="text" 
                       name="userId" 
                       maxlength="16" 
                       placeholder="사용자아이디" 
                       value="<%= member.getUserId() %>" 
                       readonly/></td>
        </tr>
        <tr>
            <td class="right">비밀번호:</td>
            <td><input type="password" 
                       name="password" 
                       maxlength="16" 
                       placeholder="변경 할 비밀번호"/></td>
        </tr>
        <tr>
            <td class="right">이름:</td>
            <td><input type="text" 
			           name="name" 
			           maxlength="30" 
			           placeholder="사용자 이름" 
                       value="<%= member.getName() %>" 
			           required/></td>
        </tr>
        <tr>
            <td class="right">학교:</td>
            <td><input type="text" 
                       name="school" 
                       maxlength="30" 
                       placeholder="학교명" 
                       value="<%= member.getSchool() %>" 
                       required/></td>
        </tr>
        <tr>
            <td class="right">학과:</td>
            <td><input type="text" 
		               name="department" 
		               maxlength="30" 
		               placeholder="학과명" 
                       value="<%= member.getDepartment() %>" 
		               required/></td>
        </tr>
        <tr>
            <td class="right">학번:</td>
            <td><input type="text" 
			           name="studentId" 
			           maxlength="16" 
			           placeholder="사용자 학번" 
                       value="<%= member.getStudentId() %>" 
			           required/></td>
        </tr>
        <tr>
            <td colspan="2" class="top-padding">
            <input type="button" value="로그아웃" onclick="logout()"/>
            <input type="reset"  value="변경취소"/>
            <input type="submit" value="적용"/>
            </td>
        </tr>
    </table>
    </form>
    <br/>
<%
    if (member.isAdmin()) {
    	List<Member> members = MemberDBService.getInstance().getMembers();
%>
    <table class="center" style="width: 650px;">
        <thead>
        <tr>
            <th>순번</th>
            <th>아이디</th>
            <th>권한</th>
            <th>이름</th>
            <th>학교</th>
            <th>학과</th>
            <th>학번</th>
            <th>&nbsp;</th>
        </tr>
        </thead>
        <tbody>
<%
        int no = 1;
        for (Member m : members) {
%>
        <tr>
            <td><%= no++ %></td>
            <td><%= m.getUserId() %></td>
            <td><%= m.isAdmin() ? "관리자" : "일반사용자" %></td>
            <td><%= m.getName() %></td>
            <td><%= m.getSchool() %></td>
            <td><%= m.getDepartment() %></td>
            <td><%= m.getStudentId() %></td>
            <td><input type="button" 
                       value="삭제" 
                       onclick="deleteUser('<%= m.getUserId() %>')"
                       <%= (m.getUserId().compareTo(member.getUserId()) == 0) ? "disabled" : "" %>/></td>
        </tr>
<%
        }
%>
        </tbody>
    </table>
<%
    }
%>
</section>
</body>
</html>