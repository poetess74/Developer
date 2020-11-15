<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 회원정보 찾기</title>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="find" method="post" action="request.jsp">
				<table border="1">
					<th colspan="2">신원 확인</th>
					<!-- TODO: 그룹 지정에 따른 다른 보기 보여주기-->
					<tr>
						<td>그룹 지정</td>
						<td colspan="2">
							<input type="radio" id="0" name="GID" value="0"/>관리자
							<input type="radio" id="1" name="GID" value="1"/>관계자
							<input type="radio" id="2" name="GID" value="2" checked="checked"/>학생
						</td>
					</tr>
					<tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="가입시 기입한 이름" required="required"/></td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSchool" placeholder="가입시 기입한 학교" required="required"/></td>
					</tr>
					<tr>
						<td>학번</td>
						<td><input type="text" name="userPIN" placeholder="학번"/></td>
					</tr>
					<tr>
						<td>학과</td>
						<td><input type="text" name="userSubject" placeholder="전공학과"/></td>
					</tr>
					<tr>
						<td colspan="2" align="center">
							<input type="submit" name="userFind" value="조회"/>
						</td>
					</tr>
					<tr>
						<td colspan="3" align="center">
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