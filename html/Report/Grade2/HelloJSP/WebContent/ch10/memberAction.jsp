<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원정보저장</title>
    </head>
    <body>
        <jsp:useBean id="memberInfo" class="ch10.bean.MemberInfo" scope="page">
            <jsp:setProperty name="memberInfo" property="id"></jsp:setProperty>
            <jsp:setProperty name="memberInfo" property="pw"></jsp:setProperty>
            <jsp:setProperty name="memberInfo" property="name"></jsp:setProperty>
            <jsp:setProperty name="memberInfo" property="email"></jsp:setProperty>
        </jsp:useBean>
        액션태그 사용한 버전: memberAction.jsp<br>
        <ul>
            <li>아이디: <jsp:getProperty name="memberInfo" property="id"/></li>
            <li>패스워드: <jsp:getProperty name="memberInfo" property="pw"/></li>
            <li>이름: <jsp:getProperty name="memberInfo" property="name"/></li>
            <li>이메일: <jsp:getProperty name="memberInfo" property="email"/></li>
        </ul>
    </body>
</html>
