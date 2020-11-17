<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<%@ page import="service.data.DBController" %>
<%@ page import="java.sql.ResultSet" %>
<%@ page import="java.sql.SQLException" %>
<%!
    DBController mysql = new DBController();
    boolean isRootSet = false;
%>
<%
    try {
        mysql.SQLInitialize();
        ResultSet list = mysql.SQLQueryExistOutput("SELECT UID FROM user WHERE UID = 'root';");
        while(list.next()) {
        	if (list.getString("UID").equals("root")) {
        		isRootSet = true;
            }
        }
        mysql.SQLClose();
    } catch(SQLException e) {
        out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
    }
%>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>회원 정보 관리 - 도움말</title>
    </head>
    <body>
        <header class="header">
            <h1>회원 정보 관리 프로그램</h1>
        </header>
        <section class="section">
            <form method="post" action="request.jsp">
                <table border="1">
                    <th colspan="2">도움말</th>
                    <tr>
                        <td colspan="2" align="center">로그인</td>
                    </tr>
                    <tr>
                        <td>아이디</td>
                        <td>회원들을 구분하는 고유 문자열 입니다. </td>
                    </tr>
                    <tr>
                        <td>비밀번호</td>
                        <td>다른 사람에게 알려주면 안됩니다. </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">회원가입 - 학생</td>
                    </tr>
                    <tr>
                        <td>수집 정보</td>
                        <td>이름, 학교, 학번, 학과</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">회원가입 - 선생님</td>
                    </tr>
                    <tr>
                        <td>수집 정보</td>
                        <td>이름, 학교, 과목/부서</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">회원가입 - 관리자</td>
                    </tr>
                    <tr>
                        <td>수집 정보</td>
                        <td>이름, 직장, 사번, 부서</td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">날조하거나 누락 할 경우 불이익이 있을 수 있음</td>
                    </tr>
                    <%
                        if (!isRootSet) {
                    %>
	                <tr>
                        <td align="center">
                            <input type="submit" name="rootCreate" value="루트 생성"/>
                            <input type="button" name="rootInfo" value="?" onclick="
                                alert('루트 계정은 한번 생성되면 지워지지 않으며 GSO가 777인 즉 모든 권한을 가진 계정을 의미합니다. 보안 수준을 높이기 위해 생성할 것을 강력히 권고하는 바입니다. (이 작업은 GSO가 775 이상인 사용자들만 수행할 수 있습니다. )');
                            "/>
                        </td>
		                <td>이 환경에 루트 계정을 생성합니다...</td>
                    </tr>
                    <%
                        }
                    %>
                    <tr>
                        <td colspan="2" align="center">
                            <input type="button" name="userFind" value="로그인" onclick="location.href='index.html'"/>
                            <input type="button" name="userJoin" value="회원가입" onclick="location.href='joinUser.html'"/>
                            <input type="button" name="userFind" value="회원정보 찾기" onclick="location.href='findUser.html'"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            ☎︎ <a href="tel:02-1234-5678">02-1234-5678</a> ,
                            ✉︎ <a href="mailto:abcd@mail.com?subject=회원%20정보%20프로그램%20문의&body=아이디:%0A문의%20주제:%0A브라우저%20사용환경:%0A문의%20내용%20(구체적으로):">abcd@mail.com</a>
                        </td>
                    </tr>
                </table>
            </form>
        </section>
        <footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
    </body>
</html>