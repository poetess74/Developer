<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원정보 변경 양식폼</title>
    </head>
    <body>
        <form action="deletePro.jsp" method="post">
            회원정보 변경 양식폼
            <table>
                <tr>
                    <td>아이디</td>
                    <td><input type="text" size="12" name="id"/> </td>
                </tr>
                <tr>
                    <td>패스워드</td>
                    <td><input type="password" size="12" name="pw"/> </td>
                </tr>
                <tr>
                    <td>변경될 이름</td>
                    <td><input type="text" size="12" name="name"/> </td>
                </tr>
                <tr>
                    <td colspan="2"><input type="submit" value="변경"/> </td>
                </tr>
            </table>
        </form>
    </body>
</html>
