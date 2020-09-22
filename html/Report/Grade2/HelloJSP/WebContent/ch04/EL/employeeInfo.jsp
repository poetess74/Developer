<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>응답 페이지</title>
    </head>
    <body>
        <table border="1" align="left">
            <th width="100">empno</th>
            <th width="100">ename</th>
            <th width="200">job</th>
            <th width="100">sal</th>
            <th width="100">deptno</th>
            <tr>
                <td>${param.empno}</td>
                <td>${param.ename}</td>
                <td>${param.job}</td>
                <td>${param.sal}</td>
                <td>${param.deptno}</td>
            </tr>
        </table>
    </body>
</html>
