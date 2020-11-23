<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원정보관리::회원가입</title>
</head>
<body>
<header>
	<h1>회원가입</h1>
</header>
<section>
	<form name="register" method="post" action="register_process.jsp">
	<table>
		<tr>
			<td>권한:</td>
			<td>
				<input type="radio" name="admin" value="false" checked/>일반사용자
				<input type="radio" name="admin" value="true"/>관리자
			</td>
		</tr>
		<tr>
			<td>아이디:</td>
			<td><input type="text" name="userId" maxlength="16" placeholder="사용자아이디" required/></td>
		</tr>
		<tr>
			<td>비밀번호:</td>
			<td><input type="password" name="password" maxlength="16" placeholder="비밀번호" required/></td>
		</tr>
		<tr>
			<td>이름:</td>
			<td><input type="text" name="name" maxlength="30" placeholder="사용자 이름" required/></td>
		</tr>
		<tr>
			<td>학교:</td>
			<td><input type="text" name="school" maxlength="30" placeholder="학교명" required/></td>
		</tr>
		<tr>
			<td>학과:</td>
			<td><input type="text" name="department" maxlength="30" placeholder="학과명" required/></td>
		</tr>
		<tr>
			<td>학번:</td>
			<td><input type="text" name="studentId" maxlength="16" placeholder="사용자 학번" required/></td>
		</tr>
		<tr>
			<td colspan="2">
			<input type="button" name="login" value="로그인" onclick="location.href='login_form.jsp'"/>
			<input type="reset" value="초기화"/>
			<input type="submit" name="login" value="등록"/>
			</td>
		</tr>
	</table>
	</form>
</section>
</body>
</html>