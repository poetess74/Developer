<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - {마이페이지/관리자}</title>
		<style>
			/*@import url(main.css);*/ /*TODO: If Release UnComment this line */
		</style>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="mypage" method="post" action="index.jsp">
				<table border="1">
					<th colspan="3">{나의/회원} 정보 관리</th>
					<tr>
						<td>아이디 변경</td>
						<td><input type="text" name="userID" placeholder="사용자ID" value="hashed"></td>
						<td align="center"><input type="submit" name="userLogout" value="로그아웃" onclick="
								let id = document.login.userID.value;
								document.login.userID.value = '';
								document.login.userPW.value = '';
								alert('로그아웃에 성공하였습니다.' + id + '님 방문해 주셔서 감사합니다. ');
							"></td>
					</tr>
					<tr>
						<td>비밀번호 변경</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분 12자리 이상"></td>
						<td align="center" rowspan="2"><input type="submit" name="userLogout" value="변경" onclick="
								function PasswordCompare(UPW, UPWC) {
									return UPW === UPWC;
								}
								if(document.login.userPW.value.length < 12) {
									document.login.userPW.value = '';
									document.login.userPWCheck.value = '';
									alert('비밀번호 생성 규정은 12자리 이상입니다. ');
								}
								if (!PasswordCompare(document.login.userPW.value, document.login.userPWCheck.value)) {
									document.login.userPW.value = '';
									document.login.userPWCheck.value = '';
									alert('비밀번호 와 비밀번호검증이 다릅니다. ');
								} else {
									if(document.login.userPW.value.isEmpty() && document.login.userPWCheck.value.isEmpty()) {
										alert('비밀번호를 변경하지 않았습니다. ')
									}
									alert('회원정보가 성공적으로 변경되었습니다. ');
								}
							"></td>
					</tr>
					<tr>
                        <td>비밀번호 검증</td>
						<td><input type="password" name="userPWCheck" placeholder="변경할 비밀번호 재입력"></td>
					</tr>
                    <tr>
						<td>이름</td>
						<td colspan="2">사용자이름</td>
					</tr>
					<tr>
						<td>학번</td>
						<td colspan="2">사용자학번</td>
					</tr>
					<tr>
						<td>학교</td>
                        <td colspan="2">등록학교</td>
					</tr>
					<tr>
						<td>학과</td>
						<td><input type="text" name="userSubject" placeholder="변경할 학과" value="등록학과"></td>
						<td align="center"><input type="submit" name="userSubjectEdit" value="변경" onclick="">
					</tr>
					<tr> <td colspan="3" align="center">수정 불가 항목은 관리자에게 문의하여 수정</td> </tr>
					<tr> <td colspan="3" align="center">☎︎ 02-1234-5678 , ✉︎ abcd@mail.com</td> </tr>
				</table>
				<table border="1">
					<th colspan="6">사용자 목록</th>
                    <tr>
						<td>사용자 이름</td>
						<td>GSO 권한</td>
						<td>그룹</td>
						<td>수정된 시각</td>
						<td colspan="2" align="center">편집</td>
					</tr>
					<tr>
						<td>root</td>
						<td align="center">777</td>
                        <td align="center">admin</td>
						<td>2020-1-1 00:00</td>
						<td align="center" colspan="2"><input type="button" name="editUser" value="수정"> </td>
					</tr>
					<tr>
						<td>staff</td>
						<td align="center">775</td>
						<td align="center">wheel</td>
						<td>2020-1-1 00:00</td>
						<td align="center"><input type="button" name="editUser" value="수정"> </td>
						<td align="center"><input type="button" name="delUser" value="삭제"> </td>
					</tr>
					<tr>
						<td>user</td>
						<td align="center">750</td>
						<td align="center">staff</td>
						<td>2020-1-1 00:00</td>
                        <td align="center"><input type="button" name="editUser" value="수정"> </td>
						<td align="center"><input type="button" name="delUser" value="삭제"> </td>
					</tr>
					<tr><td colspan="6" align="center">GSO :General Data, Sensitive Data, Other User</td></tr>
					<tr><td colspan="6" align="center">GSO 권한은 Linux/Unix 권한 체계를 따릅니다. </td></tr>
					<tr><td colspan="6" align="center">wheel은 admin에게 수정 권한을 요청해야 합니다. </td></tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>