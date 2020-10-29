<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
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
			<form name="find" method="post" action="index.jsp">
				<table border="1">
					<th colspan="2">신원 확인</th>
					<tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="사용자이름" required="required"></td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSchool" placeholder="사용자학교" required="required"></td>
					</tr>
					<tr>
						<td>학번/사번</td>
						<td><input type="text" name="userPIN" placeholder="사용자학번" required="required"></td>
					</tr>
					<tr>
						<td>학과/부서</td>
						<td><input type="text" name="userPIN" placeholder="사용자학과" required="required"></td>
					</tr>
					<tr>
						<td colspan="2" align="center">
							<input type="button" name="userLogin" value="조회" onclick="alert('준비중인 기능입니다. ')">
						</td>
					</tr>
					<tr>
						<td colspan="3" align="center">
							<input type="button" name="userJoin" value="로그인" onclick="location.href='index.jsp'">
							<input type="button" name="userFind" value="회원가입" onclick="location.href='joinUser.jsp'">
						</td>
					</tr>
				</table>
				<br>
                <table border="1">
					<th colspan="2">아이디/비밀번호 찾기</th>
					<tr>
						<td>아이디</td>
						<td>NULL</td>
					</tr>
					<tr>
						<td>새 비밀번호</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분" required="required"></td>
					</tr>
					<tr>
						<td>비밀번호 검증</td>
						<td><input type="password" name="userPWCheck" placeholder="비밀번호 재입력" required="required"></td>
					</tr>
					<tr>
						<td colspan="2" align="center"><input type="submit" name="userDone" value="변경"></td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>