<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>include 액션태그</title>
    </head>
    <body>
        <table width="40%" border="1">
            <tr> <td colspan="2"><jsp:include page="top.jsp"></jsp:include></td> </tr>
            <tr>
                <td><jsp:include page="left.jsp"></jsp:include></td>
                <td>레이아웃 1</td>
            </tr>
            <tr> <td colspan="2"><jsp:include page="bottom.jsp"></jsp:include></td> </tr>
        </table>
    </body>
</html>
