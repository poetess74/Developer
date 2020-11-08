<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>회원 정보 관리 - {마이페이지/관리자}</title>
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
						<td><input type="text" name="userID" placeholder="사용자ID" value="<%=userCache.getID()%>"/></td>
						<td align="center"><input type="submit" name="userLogout" value="로그아웃"/></td>
					</tr>
					<tr>
						<td>비밀번호 변경</td>
						<td><input type="password" name="userPW" placeholder="대 • 소문자 구분 12자리 이상"/></td>
					</tr>
					<tr>
                        <td>비밀번호 검증</td>
						<td><input type="password" name="userPWCheck" placeholder="변경할 비밀번호 재입력"/></td>
					</tr>
                    <tr>
						<td>이름</td>
						<td><input type="text" name="userName" placeholder="변경할 이름" value="<%=userCache.getName()%>"/></td>
					</tr>
					<tr>
						<td>학번</td>
						<td><input type="text" name="userPIN" placeholder="변경할 학번" value="<%=userCache.getSID()%>"/></td>
						<td align="center"><input type="button" name="userPINCheck" value="중복확인" onclick=""/></td>
					</tr>
					<tr>
						<td>권한 및 그룹</td>
						<td align="center">
							<%
								switch (userCache.getGID()) {
									case 0:
										out.print("777 • root");
										break;
									case 1:
										out.print("775 • wheel");
										break;
									case 2:
										out.print("750 • staff");
										break;
								}
							%>
						</td>
					</tr>
					<tr>
						<td>학교</td>
						<td><input type="text" name="userSubject" placeholder="변경할 학교" value="<%=userCache.getSchool()%>"/></td>
					</tr>
					<tr>
						<td>학과/부서</td>
						<td><input type="text" name="userSubject" placeholder="변경할 학과" value="<%=userCache.getSubject()%>"/></td>
					</tr>
					<tr>
						<td>수정 및 탈퇴</td>
						<td align="center" colspan="2"><input type="button" name="userEdit" value="변경" onclick=""/>
						<input type="button" name="userExit" value="탈퇴 요청" onclick=""/></td>
					</tr>
					<tr> <td colspan="3" align="center">수정 불가 항목은 담당 선생님께 요청됨</td> </tr>
				</table>
                <br>
				<table border="1">
					<th colspan="7">사용자 목록</th>
                    <tr>
						<td>사용자 ID</td>
						<td>사용자 이름</td>
						<td>GSO 권한</td>
						<td>그룹</td>
						<td colspan="2" align="center">편집</td>
						<td align="center">비고</td>
					</tr>
					<tr>
						<td>root</td>
						<td>관리자</td>
						<td align="center">777</td>
						<td align="center"><input type="button" name="showPermission" value="admin" onclick="alert(adminDescription)"/> </td>
						<td align="center" colspan="2"><input type="button" name="editUser" value="수정"/> </td>
						<td align="center"></td>
					</tr>
				</table>
			</form>
		</section>
    	<footer class="footer"><b>Copyright © 김형민 2020, 모든 권리 보유.</b></footer>
	</body>
</html>