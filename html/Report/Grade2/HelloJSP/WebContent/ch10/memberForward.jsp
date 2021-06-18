<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<% request.setCharacterEncoding("utf-8"); %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원정보 저장</title>
    </head>
    <body>
        <jsp:useBean id="memberInfo" class="ch10.bean.MemberInfo" scope="request">
            <jsp:setProperty name="memberInfo" property="*"></jsp:setProperty>
        </jsp:useBean>
        <jsp:forward page="memberUseObject.jsp"></jsp:forward>
    </body>
</html>
