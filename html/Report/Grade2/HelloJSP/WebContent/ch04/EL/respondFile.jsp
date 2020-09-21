<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>응답 페이지</title>
    </head>
    <body>
        <h2>응답 페이지</h2>
        <hr>
        ${param.id }/${param.pwd } <br>
        ${param["id"] }/${param["pwd"] }
    </body>
</html>
