<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>사원정보 등록</title>
    </head>
    <body>
        <h2>사원정보 등록</h2>
        <hr>
        <form method="get" action="employeeInfo.jsp">
			empno: <input type="text" name="empno"><br>
			ename: <input type="text" name="ename"><br>
			job: <input type="text" name="job"><br>
			sal: <input type="text" name="sal"><br>
            deptno: <select name="deptno">
                <option value="10">10</option>
                <option value="20">20</option>
                <option value="30">30</option>
            </select>
            <br>
			<input type="submit" value="저장">
			<input type="reset" value="취소">
        </form>
    </body>
</html>
