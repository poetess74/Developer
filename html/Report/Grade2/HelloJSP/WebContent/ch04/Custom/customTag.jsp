<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ page import="sample.CommonUtil" %>
<%@ taglib uri="tld/CommonUtil.tld" prefix="cUtil" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>커스텀 태그</title>
    </head>
    <body>
        <%= CommonUtil.makeFormat("홍길동") %>
        <% CommonUtil.makeFormat("홍길동"); %>
        ${ cUtil:makeFormat("김길동") }
    </body>
</html>
