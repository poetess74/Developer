<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<jsp:useBean id="memberInfo" class="ch10.been.MemberInfo" scope="request"></jsp:useBean>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원정보 출력</title>
    </head>
    <body>
        참조변수 영역: memberUseObject.jsp<br>
        <ul>
            <li>아이디: <jsp:getProperty name="memberInfo" property="id"/></li>
            <li>패스워드: <jsp:getProperty name="memberInfo" property="pw"/></li>
            <li>이름: <jsp:getProperty name="memberInfo" property="name"/></li>
            <li>이메일: <jsp:getProperty name="memberInfo" property="email"/></li>
        </ul>
    </body>
</html>
