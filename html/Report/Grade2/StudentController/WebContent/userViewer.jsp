<%@ page language="java" contentType="text/html; charset=UTF-8"
		 pageEncoding="UTF-8"%>
<%@ page import="service.data.DBController" %>
<%@ page import="java.sql.ResultSet" %>
<%@ page import="java.sql.SQLException" %>
<%@ page import="java.util.ArrayList" %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<% request.setCharacterEncoding("utf-8"); %>
<%!
	DBController mysql = new DBController();
	String UID = null, name = null, del = null, edit = null; Integer GID = null;
	ArrayList<String> statement = new ArrayList<>();
%>
<%
	try {
		statement.add(userCache.getID());
		ResultSet list = mysql.SQLQueryExistOutput("SELECT del FROM user WHERE UID = ?", statement);
		statement.clear();
		if (list == null) { throw new SQLException(); }
		while(list.next()) {
			del = list.getString("del");
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
		<title>회원 정보 관리 - 사용자 훓어보기</title>
        <script>
			let adminDescription = '이 그룹에 속해있는 사용자는 본인의 모든 데이터를 읽고 편집할 수 있고 다른 사용자의 모든 데이터를 읽고 편집할 수 있습니다. 또한 다른 사용자의 권한과 그룹 설정도 변경할 수 있습니다. '
			let wheelDescription = '이 그룹에 속해있는 사용자는 본인의 모든 데이터를 읽고 편집할 수 있으며 다른 사용자의 일반 데이터를 읽을 수 있습니다. '
			let staffDescription = '이 그룹에 속해있는 사용자는 본인의 일반 데이터를 읽고 편집할 수 있으며 민감한 데이터는 읽기만 할 수 있습니다. '
		</script>
	</head>
	<body>
		<header class="header">
			<h1>회원 정보 관리 프로그램</h1>
		</header>
		<section class="section">
			<form name="mypage" method="post" action="request.jsp">
				<table border="1">
					<th colspan="3">사용자 훓어보기</th>
					<tr>
						<td>열람자</td>
						<td><input type="text" name="requestID" value="<%=userCache.getRequestID()%>" readonly/></td>
					</tr>
					<tr>
						<td>아이디</td>
						<td><input type="text" name="userID" value="<%=userCache.getID()%>" readonly/></td>
					</tr>
                    <tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="이름" value="<%=userCache.getName()%>" readonly/></td>
					</tr>
					<tr>
						<%
							if (userCache.getSID() != null) {
						%>
						<td>학번</td>
						<td><input type="text" name="userPIN" placeholder="학번" value="<%=userCache.getSID()%>" readonly/></td>
						<%
							}
						%>
					</tr>
					<tr>
						<td>권한 및 그룹</td>
						<td align="center">
							<%
								switch(userCache.getGID()) {
									case "0": out.println("777 • admin"); break;
									case "1": out.println("775 • wheel"); break;
									case "2": out.println("750 • staff"); break;
								}
                            %>
						</td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSchool" placeholder="학교" value="<%=userCache.getSchool()%>" readonly/></td>
					</tr>
					<tr>
						<td>학과</td>
						<td><input type="text" name="userSubject" placeholder="변경할 학과" value="<%=userCache.getSubject()%>" readonly/></td>
					</tr>
					<tr>
						<td align="center" colspan="3"><input type="submit" name="do" value="확인"/></td>
					</tr>
					<tr> <td colspan="3" align="center">보기 전용 모드</td> </tr>
				</table>
			</form>
			<%
					if (!userCache.getRequestGID().equals("2")) {
                %>
				<br>
			<form name="modifyForm" method="post" action="request.jsp">
				<table border="1">
					<th colspan="7">사용자 목록</th>
                    <tr>
						<td align="center">사용자 ID</td>
						<td align="center">사용자 이름</td>
						<td align="center">GSO 권한</td>
						<td align="center">그룹</td>
						<td colspan="2" align="center">열람</td>
						</td>
						<td align="center">비고</td>
					</tr>
						<%
							try {
								ResultSet list = mysql.SQLQueryExistOutput("SELECT UID, name, GID, del, edit FROM user", null);
								if (list == null) { throw new SQLException(); }
								while(list.next()) {
									UID = list.getString("UID");
									name = list.getString("name");
									GID = list.getInt("GID");
									del = list.getString("del");
									edit = list.getString("edit");
						%>
					<tr>
						<td>
							<input type="text" name="requestID" value="<%=userCache.getRequestID()%>" readonly hidden/>
							<%=UID%>
						</td>
						<td><%=name%></td>
						<td align="center">
							<input type="text" name="requestGID" value="<%=userCache.getRequestGID()%>" readonly hidden/>
							<%
								switch(GID) {
									case 0: out.println(777); break;
									case 1: out.println(775); break;
									case 2: out.println(750); break;
								}
							%>
						</td>
						<%
							String gidResult = null;
							switch(GID) {
								case 0: gidResult = "admin"; break;
								case 1: gidResult = "wheel"; break;
								case 2: gidResult = "staff"; break;
							}
						%>
						<td align="center"><input type="button" name="showPermission" value="<%=gidResult%>" onclick="
							<%
								switch(GID) {
									case 0: %> alert(adminDescription) <% break;
									case 1: %> alert(wheelDescription) <% break;
									case 2: %> alert(staffDescription) <% break;
								}
							%>
						"/> </td>
						<td colspan="2">
							<label><input type="radio" name="view" value="<%=UID%>"/>열람</label>
						</td>
						<td align="center">
							<label>
							<%
								if(del == null && edit == null) {
									out.println("-");
								} else {
									out.println("심사중");
								}
							%>
							</label>
						</td>
					</tr>
						<%
								}
								mysql.SQLClose();
							} catch(SQLException e) {
								out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
							}
						%>
					<tr>
						<td colspan="7" align="center">
							<input type="submit" name="do" value="열람"/>
							<input type="reset" name="resetForm" value="초기화"/>
						</td>
					</tr>
				</table>
			</form>
				<%
					}
				%>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>