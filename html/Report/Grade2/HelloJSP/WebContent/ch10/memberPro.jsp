<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="ch10.been.MemberInfo" %>
<% request.setCharacterEncoding("utf-8"); %>
<jsp:useBean id="memberinfo" class="ch10.been.MemberInfo">
    <jsp:setProperty name="memberinfo" property="id"/>
    <jsp:setProperty name="memberinfo" property="pw"/>
    <jsp:setProperty name="memberinfo" property="name"/>
    <jsp:setProperty name="memberinfo" property="email"/>
</jsp:useBean>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원정보저장</title>
    </head>
    <body>
        <%
            String id = request.getParameter("id");
            String pw = request.getParameter("pw");
            String name = request.getParameter("name");
            String email = request.getParameter("email");

            MemberInfo memberInfo = new MemberInfo();
            memberInfo.setId(id);
            memberInfo.setPw(pw);
            memberInfo.setName(name);
            memberInfo.setEmail(email);
        %>
        액션태그 사용안한 버전: memberPro.jsp<br>
        <ul>
            <li>아이디: <%=memberInfo.getId()%></li>
            <li>패스워드: <%=memberInfo.getPw()%></li>
            <li>이름: <%=memberInfo.getName()%></li>
            <li>이메일: <%=memberInfo.getEmail()%></li>
        </ul>
    </body>
</html>
