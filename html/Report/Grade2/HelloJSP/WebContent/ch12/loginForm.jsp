<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>쿠키사용 로그인 폼</title>
    </head>
    <body>
        <h2>쿠키사용 로그인 폼</h2>
        <form method="post" action="loginPro.jsp">
            아이디: <input type="text" name="id" maxlength="12"/><br>
            패스워드: <input type="password" name="pw" maxlength="12"/><br>
            <input type="submit" value="로그인"/>
            <input type="button" value="회원가입" onclick="location.href='memberForm.jsp'"/>
        </form>
    </body>
</html>