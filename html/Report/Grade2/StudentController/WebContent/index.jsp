<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 로그인</title>
		<style>
			/*@import url(main.css);*/ /*TODO: If Release UnComment this line */
		</style>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="login" method="post" action="mypage.jsp">
				<table border="1">
					<th colspan="3">로그인</th>
					<tr>
						<td>아이디</td>
						<td><input type="text" name="userID" placeholder="사용자ID" required="required"></td>
						<td rowspan="2"><input type="submit" name="userLogin" value="로그인" onclick="
								function CheckIdentify(UID, UPW) {
									return true;
								}
								if (!CheckIdentify(document.login.userID.value, document.login.userPW.value)) {
									document.login.userID.value = '';
									document.login.userPW.value = '';
									alert('아이디 또는 비밀번호가 다릅니다. ');
								} else {
									let id = document.login.userID.value;
									alert(document.login.userSecurity.checked
									? '환영합니다 ' + id + '님. ' + '보안통신이 적용되었습니다. '
									: '환영합니다 ' + id + '님. ' + '보안통신이 활성화 되어 있지 않아 민감 정보를 제외한 정보 뷰어로 전환합니다. ');
								}
							"></td>
					</tr>
					<tr>
						<td>비밀번호</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분" required="required"></td>
					</tr>
					<tr>
						<td colspan="3" align="center">
							<label><input type="checkbox" name="userSecurity" value="Apply">보안통신</label>
							<input type="button" name="userJoin" value="회원가입" onclick="alert('준비중인 기능입니다. ')">
							<input type="button" name="userFind" value="회원정보 찾기" onclick="alert('준비중인 기능입니다. ')">
						</td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>