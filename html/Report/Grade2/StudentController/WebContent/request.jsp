<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<%@ page import="service.data.DBController" %>
<% request.setCharacterEncoding("utf-8"); %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<%
    DBController mysql = new DBController();
    ResultSet sqlResult = null;
    String prevURL = request.getHeader("referer");
    switch(prevURL) {
        case "http://localhost:8080/StudentController/index.jsp":
            userCache.setMultipleElements(request.getParameter("userID"), request.getParameter("userPW"));
            try {
                sqlResult = mysql.SQLQueryExistOutput("SELECT UID, UPW FROM user;");
                String loginFoundID = null;
                String loginFoundPW = null;
                boolean loginFound = false;
                while (sqlResult.next()) {
                    loginFoundID = sqlResult.getString("UID");
                	loginFoundPW = sqlResult.getString("UPW");
                	if (userCache.getID().equals(loginFoundID) && userCache.getPW().equals(loginFoundPW)) {
                		loginFound = true; break;
                    }
                }
                if (!loginFound) {
                    out.println("<script>alert('아이디 또는 비밀번호가 다릅니다. ');</script>");
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.jsp';</script>");
                } else {
                    sqlResult = mysql.SQLQueryExistOutput("SELECT SID, GID, name, school, subject, task FROM user WHERE UID = '" + loginFoundID + "';");
                    if (sqlResult.next()) {
                        userCache.setMultipleElements(
                        	sqlResult.getInt("GID"),
                        	sqlResult.getString("name"),
                        	sqlResult.getString("school"),
                            sqlResult.getString("SID"),
                            sqlResult.getString("subject"),
                            sqlResult.getString("task")
                        );
                    }
                    out.println("<script>alert(" + loginFoundID + "'님 환영합니다. ');</script>");
                    out.println("<script>location.href='mypage.jsp';</script>");
                }
            } catch(SQLException e) {
                userCache.resetAllElements();
                out.println("<script>alert('DB 통신 에러. 문제가 계속될 경우 관리자에게 제보하여 주십시오.');</script>");
                out.println("<script>location.href='errorPage/503code.jsp';</script>");
            }
            break;
        case "http://localhost:8080/StudentController/mypage.jsp":
            userCache.setID(request.getParameter("userID"));
            out.println("<script>alert('로그아웃에 성공하였습니다. " + userCache.getID() + "님 방문해 주셔서 감사합니다. ');</script>");
            userCache.resetAllElements();
        	out.println("<script>location.href='index.jsp';</script>");
        	break;
        case "http://localhost:8080/StudentController/findUser.jsp":
        	userCache.resetAllElements();
            userCache.setMultipleElements(
            		request.getParameter("userName"),
            		request.getParameter("userSchool"),
                    request.getParameter("userPIN"),
                    request.getParameter("userSubject")
            );
            sqlResult = mysql.SQLQueryExistOutput("SELECT UID, name, school, SID, subject FROM user;");
            try {
            	boolean userFound = false;
            	String userFoundID = null;
                while (sqlResult.next()) {
                    userFoundID = sqlResult.getString("UID");
                    String name = sqlResult.getString("name");
                    String school = sqlResult.getString("school");
                    String SID = sqlResult.getString("SID");
                    if (SID == null) { SID = ""; }
                    String subject = sqlResult.getString("subject");
                    if (subject == null) { subject = ""; }
                    boolean nameCheck = userCache.getAllElements().get(3).equals(name);
                    boolean schoolCheck = userCache.getAllElements().get(1).equals(school);
                    boolean SIDCheck = userCache.getAllElements().get(0).equals(SID);
                    boolean subjectCheck = userCache.getAllElements().get(2).equals(subject);
                    if ((nameCheck && schoolCheck) && (SIDCheck && subjectCheck)) {
                    	userFound = true; break;
                    }
                }
                if (!userFound) {
                    out.println("<script>alert('등록된 계정이 없습니다. 로그인 페이지로 이동합니다. ');</script>");
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.jsp';</script>");
                }
                userCache.setID(userFoundID);
                out.println("<script>location.href='resetIdentify.jsp';</script>");
            } catch(SQLException e) {
                out.println("<script>alert('계정을 찾는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.jsp';</script>");
            }
            break;
        case "http://localhost:8080/StudentController/resetIdentify.jsp":
        	userCache.setMultipleElements(request.getParameter("userID"), request.getParameter("userPW"));
            try {
                mysql.SQLQueryNoOutput("UPDATE user SET UPW = '" + userCache.getPW() + "' WHERE UID = '" + userCache.getID() + "';");
                out.println("<script>alert('비밀번호 변경에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            } catch(Exception e) {
                out.println("<script>alert('비밀번호 변경에 실패하였습니다. 잠시후 다시 시도해 주세요. ');</script>");
            }
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';</script>");
        	break;
        case "http://localhost:8080/StudentController/joinUser.jsp":
        	userCache.setMultipleElements(
        			request.getParameter("userID"),
                    request.getParameter("userPW"),
                    Integer.parseInt(request.getParameter("GID")),
                    request.getParameter("userName"),
                    request.getParameter("userSchool"),
                    request.getParameter("userPIN"),
                    request.getParameter("userSubject")
            );
        	try {
                if(userCache.getGID() != 2) {
                    mysql.SQLQueryNoOutput("INSERT INTO user (UID, UPW, GID, name, school, subject) VALUES ('"
                            + userCache.getID() + "', '" + userCache.getPW() + "', '" + userCache.getGID() + "', '"
                            + userCache.getName() + "', '" + userCache.getSchool() + "', '" + userCache.getSubject() + "');");
                } else {
                    mysql.SQLQueryNoOutput("INSERT INTO user (UID, UPW, SID, name, school, subject) VALUES ('"
                            + userCache.getID() + "', '" + userCache.getPW() + "', '" + userCache.getSID() + "', '"
                            + userCache.getName() + "', '" + userCache.getSchool() + "', '" + userCache.getSubject() + "');");
                }
                out.println("<script>alert('회원 가입에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            } catch(Exception e) {
                out.println("<script>alert('회원 등록에 실패하였습니다. 잠시후 다시 시도해 주세요. ');</script>");
            }
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';</script>");
        	break;
        default:
            System.err.print("Sneaky redirects: ");
            System.out.println(prevURL);
            out.println("<script>location.href='errorPage/403code.jsp';</script>");
            break;
    }
%>

<head>
    <meta charset="UTF-8">
    <title>리디렉션 중...</title>
</head>
<body>
    <h1 align="center">102 Processing</h1>
    <hr>
    <p align="center">요청하신 작업을 처리하는 중입니다. 잠시만 기다려 주십시오.</p>
</body>
