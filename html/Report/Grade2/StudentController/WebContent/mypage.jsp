<%@ page language="java" contentType="text/html; charset=UTF-8"
		 pageEncoding="UTF-8"%>
<%@ page import="service.data.DBController" %>
<%@ page import="java.sql.ResultSet" %>
<%@ page import="java.sql.SQLException" %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<% request.setCharacterEncoding("utf-8"); %>
<%!
	DBController mysql = new DBController();
	String UID = null, name = null, task = null; Integer GID = null;
%>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - 마이페이지</title>
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
					<th colspan="3">나의 정보 관리</th>
					<tr>
						<td>아이디 변경</td>
						<%
							if (userCache.getID().equals("root")) {
						%>
						<td><input type="text" name="userID" value="<%=userCache.getID()%>" disabled/></td>
						<%
							} else {
						%>
						<td><input type="text" name="userID" placeholder="사용자ID" value="<%=userCache.getID()%>"/></td>
						<%
							}
						%>
						<td align="center"><input type="submit" name="userLogout" value="로그아웃"/></td>
					</tr>
					<tr>
						<td>이전 비밀번호</td>
						<td><input type="password" name="userPrevPW" placeholder="이전에 사용한 비밀번호"/></td>
					</tr>
					<tr>
                        <td>비밀번호 변경</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분 12자리 이상"/></td>
					</tr>
                    <tr>
						<td>이름</td>
						<%
							if (userCache.getGID() == 2) {
						%>
						<td><input type="text" name="userName" placeholder="이름" value="<%=userCache.getName()%>" disabled/></td>
						<%
						} else {
						%>
						<td><input type="text" name="userName" placeholder="변경할 이름" value="<%=userCache.getName()%>"/></td>
						<%
							}
						%>
					</tr>
					<tr>
						<%
							String sidResult;
							if (userCache.getSID() == null) {
								sidResult = "";
							} else {
								sidResult = userCache.getSID();
							}
						%>
                        <%
							if (userCache.getGID() == 2) {
                        %>
						<td>학번</td>
						<td><input type="text" name="userPIN" placeholder="학번" value="<%=sidResult%>" disabled/></td>
						<%
							}
						%>
					</tr>
					<tr>
						<td>권한 및 그룹</td>
						<td align="center">
							<%
								String resultGID = null;
								switch(userCache.getGID()) {
									case 0: resultGID = "777 • admin"; break;
									case 1: resultGID = "775 • wheel"; break;
									case 2: resultGID = "750 • staff"; break;
								}
								if (userCache.getGID() == 0 && !userCache.getID().equals("root")) {
									switch(userCache.getGID()) {
										case 0: resultGID = "777"; break;
										case 1: resultGID = "775"; break;
										case 2: resultGID = "750"; break;
									}
							%>
							<input type="text" value="<%=resultGID%>" placeholder="권한 입력 (예: 750)"/>
							<%
								} else {
									out.println(resultGID);
								}
							%>
						</td>
					</tr>
					<tr>
						<td>학교</td>
						<%
							if (userCache.getGID() == 2) {
						%>
						<td><input type="text" name="userSubject" placeholder="학교" value="<%=userCache.getSchool()%>" disabled/></td>
						<%
							} else {
						%>
						<td><input type="text" name="userSubject" placeholder="변경할 학교" value="<%=userCache.getSchool()%>"/></td>
						<%
							}
						%>
					</tr>
					<tr>
						<td>학과</td>
						<td><input type="text" name="userSubject" placeholder="변경할 학과" value="<%=userCache.getSubject()%>"/></td>
					</tr>
					<tr>
                        <%
							if (userCache.getID().equals("root")) {
                        %>
						<td>수정 및 초기화</td>
						<td align="center" colspan="2"><input type="button" name="userEdit" value="변경" onclick=""/>
						<input type="button" name="userFactoryReset" value="초기화" onclick=""/></td>
						<%
							} else if (userCache.getGID() != 2) {
						%>
						<td>수정 및 탈퇴</td>
						<td align="center" colspan="2"><input type="button" name="userEdit" value="변경" onclick=""/>
							<input type="button" name="userExit" value="탈퇴" onclick=""/></td>
						<%
							} else {
						%>
						<td>수정 및 탈퇴</td>
						<td align="center" colspan="2"><input type="button" name="userEdit" value="변경" onclick=""/>
							<input type="button" name="userExit" value="탈퇴 요청" onclick=""/></td>
						<%
							}
						%>
					</tr>
                    <%
						if (userCache.getGID() == 2) {
					%>
					<tr> <td colspan="3" align="center">수정 불가 항목은 담당 선생님께 요청</td> </tr>
					<%
                        }
                    %>
				</table>
                <%
					if (userCache.getGID() != 2) {
                %>
				<br>
				<table border="1">
					<th colspan="7">사용자 목록</th>
                    <tr>
						<td>사용자 ID</td>
						<td>사용자 이름</td>
						<td>GSO 권한</td>
						<td>그룹</td>
                        <%
							if (userCache.getGID() == 0) {
                        %>
						<td colspan="2" align="center">편집</td>
						<%
							} else {
						%>
						<td colspan="2" align="center">편집 요청</td>
                        <%
							}
                        %>
						<td align="center">비고</td>
					</tr>
						<%
							try {
								ResultSet list = mysql.SQLQueryExistOutput("SELECT UID, name, GID, task FROM user;");
								while(list.next()) {
									UID = list.getString("UID");
									name = list.getString("name");
									GID = list.getInt("GID");
									task = list.getString("task");
						%>
					<tr>
						<td><%=UID%></td>
						<td><%=name%></td>
						<td align="center">
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
						<td align="center" colspan="2">
							<input type="button" name="editUser" value="수정" onclick="alert('기능 준비중 입니다.')"/>
							<%
								if (!userCache.getID().equals(UID) && !UID.equals("root")) {
							%>
							<input type="button" name="deleteUser" value="삭제" onclick="alert('기능 준비중 입니다.')"/>
							<%
								}
							%>
						</td>
						<td align="center">
							<%
								if(task == null) {
									out.println();
								} else {
									out.println(task);
								}
							%>
						</td>
					</tr>
						<%
								}
							} catch(SQLException e) {
								out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
							}
						%>
				</table>
				<%
					}
				%>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>