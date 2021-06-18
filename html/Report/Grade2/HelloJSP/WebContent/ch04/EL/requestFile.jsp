<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Form Data</title>
    </head>
    <body>
        <h2>요청 페이지</h2>
        <hr>
        <form method="get" action="respondFile.jsp">
			이름 <input type="text" name="id"><br>
			암호 <input type="password" name="pwd"><br>
			<input type="submit" value="제출">
        </form>
    </body>
</html>
