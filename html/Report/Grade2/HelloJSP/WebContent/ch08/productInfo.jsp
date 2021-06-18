<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Info</title>
    </head>
    <body>
        <table width="100%" border="1">
            <tr>
                <td>제품번호</td> <td>XXXX</td>
            </tr>
            <tr>
                <td>가격</td> <td>₩10,000</td>
            </tr>
        </table>
        <jsp:include page="productInfoSub.jsp" flush="false">
            <jsp:param name="type" value="A"/>
        </jsp:include>
    </body>
</html>