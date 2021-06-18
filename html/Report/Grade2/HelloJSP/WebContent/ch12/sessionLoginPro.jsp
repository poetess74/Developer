<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="ch12.member.LogonDBBean" %>
<% request.setCharacterEncoding("utf-8"); %>
<%
    String id = request.getParameter("id");
    String passwd = request.getParameter("pw");

    LogonDBBean logon = LogonDBBean.getInstance();

    if (logon.userCheck(id, passwd)) {
    	session.setAttribute("id", id);
        session.setAttribute("pw", passwd);
        response.sendRedirect("sessionMain.jsp");
    } else {
%>
        <script>
            alert("아이디 또는 비밀번호가 다릅니다. ");
            history.go(-1);
        </script>
<%
    }
%>