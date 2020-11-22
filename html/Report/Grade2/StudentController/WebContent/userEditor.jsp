<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="service.data.DBController" %>
<%@ page import="java.sql.ResultSet" %>
<%@ page import="java.sql.SQLException" %>
<%@ page import="java.util.ArrayList" %>
<% request.setCharacterEncoding("utf-8"); %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<%!
	DBController mysql = new DBController();
		String del = null, edit = null; Integer GID = null;
	ArrayList<String> statement = new ArrayList<>();
%>
<%
	try {
		statement.add(userCache.getID());
		ResultSet list = mysql.SQLQueryExistOutput("SELECT del, edit, gid FROM user WHERE UID = ?", statement);
		statement.clear();
		if (list == null) { throw new SQLException(); }
		while(list.next()) {
			del = list.getString("del");
			edit = list.getString("edit");
			GID = list.getInt("gid");
		}
		mysql.SQLClose();
	} catch(SQLException e) {
		statement.clear();
		out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
	}
%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 정보편집</title>
	</head>
	<body>
	<header class="header">
		<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="join" method="post" action="request.jsp">
				<table border="1">
					<th colspan="3">회원 편집</th>
					<tr>
						<td>편집자</td>
						<td><input type="text" name="requestUser" value="<%=userCache.getRequestID()%>" readonly/></td>
					</tr>
					<tr>
						<td>아이디</td>
						<td><input type="text" name="userID" value="<%=userCache.getID()%>" readonly/></td>
					</tr>
                    <%
						if (!userCache.getID().equals("root")) {
                    %>
					<tr>
						<td>그룹 설정</td>
						<td colspan="2" align="center">
                            <%
								if (GID == 0) {
                            %>
								<input type="radio" id="0" name="GID" value="0" checked/>관리자
								<input type="radio" id="1" name="GID" value="1"/>관계자
								<input type="radio" id="2" name="GID" value="2"/>학생
                            <%
								} else if (GID == 1) {
                            %>
								<input type="radio" id="0" name="GID" value="0"/>관리자
								<input type="radio" id="1" name="GID" value="1" checked/>관계자
								<input type="radio" id="2" name="GID" value="2"/>학생
							<%
								} else {
							%>
								<input type="radio" id="0" name="GID" value="0"/>관리자
								<input type="radio" id="1" name="GID" value="1"/>관계자
								<input type="radio" id="2" name="GID" value="2" checked/>학생
							<%
								}
							%>
						</td>
					</tr>
					<%
						}
					%>
					<tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="학적부에 기입된 이름" value="<%=userCache.getName()%>" required="required"/></td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSchool" placeholder="입학한 학교" value="<%=userCache.getSchool()%>" required="required"/></td>
					</tr>
					<tr>
						<td>학번</td>
						<%
							if (userCache.getSID() == null) {
								userCache.setSID("");
							}
						%>
						<td><input type="text" name="userPIN" placeholder="학번" value="<%=userCache.getSID()%>"/></td>
					</tr>
					<tr>
						<td colspan="3" align="center">
							<input type="submit" name="do" value="취소"/>
							<input type="submit" name="do" value="적용"/>
							<input type="reset" name="reset" value="초기화"/>
						</td>
					</tr>
					<tr>
						<td colspan="2">이 작업에 편집자 아이디가 영구히 기록됩니다.</td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>