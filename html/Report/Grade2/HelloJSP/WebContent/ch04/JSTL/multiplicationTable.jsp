<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>구구단 테이블</title>
        <style>
            table { border-color: red; }
            th, td { font-weight: normal; text-align: center; border-color: blue; }
        </style>
    </head>
    <body>
        <h2>구구단</h2>
            <c:forEach var="i" begin="2" end="9" step="1">
                <table border="1" width="500">
                    <tr>
                        <th colspan="5">${i}단</th>
                    </tr>
                    <c:forEach var="j" begin="1" end="9" step="1">
                        <tr>
                            <td>${i}</td>
                            <td>*</td>
                            <td>${j}</td>
                            <td>=</td>
                            <td>${i * j}</td>
                        </tr>
                    </c:forEach>
                </table>
            </c:forEach>
    </body>
</html>
