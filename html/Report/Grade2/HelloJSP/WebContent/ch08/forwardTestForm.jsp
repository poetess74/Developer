<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<% request.setCharacterEncoding("utf-8");%>

<jsp:forward page="forwardTestTo.jsp"></jsp:forward>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>forward 액션태그</title>
    </head>
    <body>
        <h2>forward 액션태그</h2>
        <form method="post" action="forwardTestForm.jsp">
            아이디 : <input type="text" name="id">
            취미 : <select name="hobby">
                <option value="음악감상">음악감상</option>
                <option value="만화보기">만화보기</option>
                <option value="산책">산책</option>
            </select><br>
            <input type="submit" value="입력완료">
        </form>
    </body>
</html>
