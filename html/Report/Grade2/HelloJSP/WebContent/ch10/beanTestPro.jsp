<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<% request.setCharacterEncoding("utf-8"); %>

<jsp:useBean id="testBean" class="ch10.been.TestBeen">
    <jsp:setProperty name="testBean" property="name"/>
</jsp:useBean>

<h2>자바빈을 사용하는 JSP 페이지</h2>
입력된 이름은
<jsp:getProperty name="testBean" property="name"/> 입니다.