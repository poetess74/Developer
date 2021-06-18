<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>입력한 숫자만큼 반복</title>
    </head>
    <body>
        <h3>입력한 숫자만큼 반복</h3>
        <table border="1">
            <thead>
                <tr>
                    <th>글번호</th><th>글제목</th><th>글내용</th>
                </tr>
            </thead>
            <tbody>
                <%
                    for(int i = Integer.parseInt(request.getParameter("count")); i > 0 ; i--) {
                %>
                <tr>
                    <td><%=i%></td>
                    <td>제목 <%=i%></td>
                    <td>내용 <%=i%></td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table><br>
        <table border="1">
            <thead>
                <tr>
                    <th>글번호</th><th>글제목</th><th>글내용</th>
                </tr>
            </thead>
            <tbody>
                <%
                    int index = Integer.parseInt(request.getParameter("count"));
                    while(index > 0) {
                %>
                <tr>
                    <td><%=index%></td>
                    <td>제목 <%=index%></td>
                    <td>내용 <%=index%></td>
                </tr>
                <%
                       index--;
                    }
                %>
            </tbody>
        </table>
    </body>
</html>
