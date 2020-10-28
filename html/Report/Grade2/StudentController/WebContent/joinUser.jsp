<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 회원가입</title>
		<style>
			/*@import url(main.css);*/ /*TODO: If Release UnComment this line */
		</style>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="join" method="post" action="index.jsp">
				<table border="1">
					<th colspan="3">회원 가입</th>
					<tr>
						<td>그룹 설정</td>
						<td>
							<input type="radio" id="0" name="GID" value="admin" onclick="showAdminCode();">관리자
							<input type="radio" id="1" name="GID" value="wheel" onclick="showAdminCode();">관계자
							<input type="radio" id="2" name="GID" value="staff" onclick="showAdminCode();" checked="checked">학생
                            <!-- FIXME: Don't hide adminCode tag -->
                            <script>
								function showAdminCode() {
									if(document.getElementById('2').checked) {
										document.adminCode.hide();
									} else {
										document.adminCode.show();
									}
								}
							</script>
						</td>
					</tr>
					<tr name="adminCode">
						<td>관리자 코드</td>
						<td><input type="text" name="authorizedUserCode" placeholder="XXX-XXX-XXX-XXX" required="required"></td>
					</tr>
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
						<td>아이디</td>
						<td><input type="text" name="userID" placeholder="사용자ID" required="required"></td>
					</tr>
					<tr>
						<td>비밀번호</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분" required="required"></td>
					</tr>
					<tr>
						<td>비밀번호 검증</td>
						<td><input type="password" name="userPWCheck" placeholder="비밀번호 재입력" required="required"></td>
					</tr>
					<tr>
						<td colspan="2" align="center"><input type="submit" name="userDone"></td>
					</tr>
					<tr>
						<td colspan="3" align="center">
							<label><input type="checkbox" name="userSecurity" value="Apply">보안통신</label>
							<input type="button" name="userLogin" value="로그인" onclick="alert('준비중인 기능입니다. ')">
							<input type="button" name="userFind" value="회원정보 찾기" onclick="alert('준비중인 기능입니다. ')">
						</td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>