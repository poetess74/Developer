<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>

<html>
    <head>
        <title>application 내장객체</title>
    </head>
    <body>
        <h2>application 내장객체</h2>
        JSP 버전 :
        <%= application.getMajorVersion() %>.<%= application.getMinorVersion() %><br>
        컨테이너 정보 :
        <%= application.getServerInfo() %>
        <br>
        웹 애플리케이션의 실제 파일시스템 경로 :
        <%= application.getRealPath("/") %><br>
        로그기록 :
        <%  application.log("로그 - 김형민");%>
    </body>
</html>

