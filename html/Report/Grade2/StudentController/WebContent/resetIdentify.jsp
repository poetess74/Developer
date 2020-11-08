<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 비밀번호 재설정</title>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="reset" method="post" action="request.jsp">
                <table border="1">
					<th colspan="2">아이디/비밀번호 찾기</th>
                    <%
						if (request.getParameter("userID") != null) {
                    %>
					<tr>
						<td>아이디</td>
						<td><input type="text" name="userID" placeholder="검색 결과 없음" disabled/></td>
					</tr>
					<tr>
						<td>새 비밀번호</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분" required="required"/></td>
					</tr>
					<tr>
						<td>비밀번호 검증</td>
						<td><input type="password" name="userPWCheck" placeholder="비밀번호 재입력" required="required"/></td>
					</tr>
					<tr>
						<td colspan="2" align="center"><input type="submit" name="userDone" value="변경"/></td>
					</tr>
                    <%
						} else {
                    %>
					<tr>
						<td colspan="2" align="center">앗! 이런!</td>
					</tr>
					<tr>
						<td colspan="2" align="center">기입하신 정보와 일치하는 계정을 찾을 수 없어요</td>
					</tr>
					<%
						}
					%>
					<tr>
						<td colspan="2" align="center">
							<input type="button" name="userLogin" value="로그인" onclick="location.href='index.jsp'"/>
							<input type="button" name="userJoin" value="회원가입" onclick="location.href='joinUser.jsp'"/>
						</td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>