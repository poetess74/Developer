<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원정보관리::로그인</title>
</head>
<body>
<header>
	<h1>로그인</h1>
</header>
<section>
	<form name="login" method="post" action="login_process.jsp">
	<table>
		<tr>
			<td>아이디:</td>
			<td><input type="text" name="userId" placeholder="사용자아이디" required/></td>
		</tr>
		<tr>
			<td>비밀번호:</td>
			<td><input type="password" name="password" placeholder="비밀번호" required/></td>
		</tr>
		<tr>
			<td colspan="2">
			<input type="button" name="register" value="회원가입" onclick="location.href='register_form.jsp'"/>
			<input type="submit" name="login" value="로그인"/>
			</td>
		</tr>
	</table>
	</form>
</section>
</body>
</html>