<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 정보편집요청</title>
	</head>
	<body>
	<header class="header">
		<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="join" method="post" action="request.jsp">
				<table border="1">
					<th colspan="3">회원편집/삭제</th>
					<tr>
						<td>모드 선택</td>
						<td colspan="2">
							<input type="radio" id="modify" name="user" value="modify"/>편집
							<input type="radio" id="delete" name="user" value="delete"/>제거
						</td>
						<td>그룹 설정</td>
						<td colspan="2">
							<input type="radio" id="0" name="GID" value="0"/>관리자
							<input type="radio" id="1" name="GID" value="1"/>관계자
							<input type="radio" id="2" name="GID" value="2" checked="checked"/>학생
						</td>
					</tr>
					<tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="학적부에 기입된 이름" required="required"/></td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSchool" placeholder="입학한 학교" required="required"/></td>
					</tr>
					<tr>
						<td>학번</td>
						<td><input type="text" name="userPIN" placeholder="학번"/></td>
						<td align="center"><input type="button" name="userPINCheck" value="중복확인" onclick=""/></td>
					</tr>
					<tr>
						<td>학과</td>
						<td><input type="text" name="userSubject" placeholder="전공학과"/></td>
					</tr>
					<tr>
						<td colspan="3" align="center">
							<input type="button" name="cancel" value="취소" onclick="
								alert('유저 편집 작업을 취소하였습니다. ');
								location.href='index.html';
							"/>
							<input type="submit" name="제출"/>
							<input type="reset" name="reset" value="초기화"/>
						</td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>