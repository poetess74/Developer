<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<%@ page import="service.data.DBController" %>
<%@ page import="java.util.ArrayList" %>
<% request.setCharacterEncoding("utf-8"); %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="session"></jsp:useBean>
<%!
    DBController mysql = new DBController();
    ResultSet sqlResult = null;
    ArrayList<String> statement = new ArrayList<>();
%>
<%
    String prevURL = request.getHeader("referer");
    switch(prevURL) {
        case "http://localhost:8080/StudentController/index.html":
            userCache.setMultipleElements(request.getParameter("userID"), request.getParameter("userPW"));
            if (userCache.getID() == null) {
                out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            try {
            	statement.add(userCache.getID());
                sqlResult = mysql.SQLQueryExistOutput("SELECT UID, UPW FROM user WHERE uid = ?", statement);
                statement.clear();
                if (sqlResult == null) { throw new SQLException(); }
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
                mysql.SQLClose();
                if (!loginFound) {
                    out.println("<script>alert('아이디 또는 비밀번호가 다릅니다. ');</script>");
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                } else {
                    statement.add(loginFoundID);
                    sqlResult = mysql.SQLQueryExistOutput("SELECT SID, GID, name, school, subject, del, edit FROM user WHERE UID = ?", statement);
                    statement.clear();
                    if (sqlResult == null) { throw new SQLException(); }
                    if (sqlResult.next()) {
                    	userCache.setGID(sqlResult.getString("GID"));
                    	userCache.setName(sqlResult.getString("name"));
                        userCache.setSchool(sqlResult.getString("school"));
                        userCache.setSID(sqlResult.getString("SID"));
                        userCache.setSubject(sqlResult.getString("subject"));
                        userCache.setDel(sqlResult.getString("del"));
                        userCache.setEdit(sqlResult.getString("edit"));
                    }
                    mysql.SQLClose();
                    out.println("<script>alert(" + loginFoundID + "'님 환영합니다. ');</script>");
                    out.println("<script>location.href='mypage.jsp';</script>");
                }
            } catch(Exception e) {
                statement.clear();
                userCache.resetAllElements();
                out.println("<script>alert('DB 통신 에러. 문제가 계속될 경우 관리자에게 제보하여 주십시오.');</script>");
                out.println("<script>location.href='errorPage/503code.jsp';</script>");
            }
            break;
        case "http://localhost:8080/StudentController/mypage.jsp":
        	switch (request.getParameter("do")) {
                case "로그아웃":
                    userCache.setID(request.getParameter("userID"));
                    if (userCache.getID() == null) {
                        out.println("<script>alert('세션이 만료되었습니다. 다시 시도하여 주시기 바랍니다. ');</script>");
                    } else {
                        out.println("<script>alert('로그아웃에 성공하였습니다. " + userCache.getID() + "님 방문해 주셔서 감사합니다. ');</script>");
                    }
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                    break;
                // TODO: 아래 기능 리디렉션 완성하기
                case "변경":
                    userCache.setMultipleElements(
                            request.getParameter("changeID"),
                            request.getParameter("userPW"),
                            request.getParameter("GID"),
                            request.getParameter("userName"),
                            request.getParameter("userSchool"),
                            request.getParameter("userPIN"),
                            request.getParameter("userSubject")
                    );
                    userCache.setRequestID(request.getParameter("userID"));
                    try {
                    	if (userCache.getID() == null) {
                            out.println("<script>alert('세션이 만료되었습니다. 다시 시도하여 주시기 바랍니다. ');</script>");
                            userCache.resetAllElements();
                            out.println("<script>location.href='index.html';</script>");
                        } else if(!userCache.getID().equals("")) {
                            if (!userCache.getID().equals(userCache.getRequestID())) {
                                statement.add(userCache.getID());
                                sqlResult = mysql.SQLQueryExistOutput("SELECT UID FROM user WHERE uid = ?", statement);
                                if(sqlResult == null) {
                                    throw new SQLException();
                                }
                                if(sqlResult.next()) {
                                    if(statement.get(0).equals(sqlResult.getString("uid"))) {
                                        out.println("<script>alert('" + statement.get(0) + "은(는) 이미 사용중인 아이디입니다. ');</script>");
                                        statement.clear();
                                        userCache.resetAllElements();
                                        out.println("<script>location.href='index.html';</script>");
                                    }
                                }
                                statement.clear();
                                statement.add(userCache.getID());
                                statement.add(userCache.getRequestID());
                                if(!mysql.SQLQueryNoOutput("UPDATE user SET UID = ? WHERE UID = ?", statement)) {
                                    throw new SQLException();
                                }
                                statement.clear();
                            }
                        }
                    	if (userCache.getPW() != null && !userCache.getPW().equals("")) {
                            statement.add(userCache.getPW());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET UPW = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                    	if (userCache.getGID() != null && !userCache.getGID().equals("")) {
                            switch(userCache.getGID()) {
                                case "777": userCache.setGID("0"); break;
                                case "775": userCache.setGID("1"); break;
                                case "750": userCache.setGID("2"); break;
                                default: throw new IllegalArgumentException();
                            }
                            statement.add(userCache.getGID());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET GID = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                        if (userCache.getName() != null && !userCache.getName().equals("")) {
                            statement.add(userCache.getName());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET name = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                        if (userCache.getSchool() != null && !userCache.getSchool().equals("")) {
                            statement.add(userCache.getSchool());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET school = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                        if (userCache.getSID() != null && !userCache.getSID().equals("")) {
                            statement.add(userCache.getSID());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET sid = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                        if (userCache.getSubject() != null && !userCache.getSubject().equals("")) {
                            statement.add(userCache.getSubject());
                            statement.add(userCache.getID());
                            if (!mysql.SQLQueryNoOutput("UPDATE user SET subject = ? WHERE UID = ?", statement)) {
                                throw new SQLException();
                            }
                            statement.clear();
                        }
                        out.println("<script>alert('계정이 성공적으로 변경 되었습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
                    } catch(IllegalArgumentException | SQLException e) {
                        statement.clear();
                        out.println("<script>alert('게정을 수정하는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                    }
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                	break;
                case "탈퇴":
                    userCache.setID(request.getParameter("userID"));
                    if (userCache.getID() == null) {
                        out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                        userCache.resetAllElements();
                        out.println("<script>location.href='index.html';</script>");
                    }
                    try {
                    	statement.add(userCache.getID());
                        if (!mysql.SQLQueryNoOutput("DELETE FROM user WHERE UID = ?", statement)) {
                        	throw new SQLException();
                        }
                        statement.clear();
                        out.println("<script>alert('성공적으로 탈퇴되었습니다. " + userCache.getID() + "님 그동안 저희와 함께해 주셔서 감사합니다. ');</script>");
                    } catch(Exception e) {
                        out.println("<script>alert('게정을 삭제하는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                    }
                    statement.clear();
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                	break;
                case "탈퇴 요청":
                    userCache.setID(request.getParameter("userID"));
                    if (userCache.getID() == null) {
                        out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                        userCache.resetAllElements();
                        out.println("<script>location.href='index.html';</script>");
                    }
                    try {
                    	statement.add(userCache.getID());
                        if (!mysql.SQLQueryNoOutput("UPDATE user SET del = TRUE WHERE UID = ?", statement)) {
                        	throw new SQLException();
                        }
                        if (!mysql.SQLQueryNoOutput("UPDATE user SET edit = NULL WHERE UID = ?", statement)) {
                        	throw new SQLException();
                        }
                        statement.clear();
                        out.println("<script>alert('성공적으로 탈퇴 요청이 완료되었습니다. ');</script>");
                    } catch(Exception e) {
                        statement.clear();
                        out.println("<script>alert('탈퇴 요청을 등록하는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                    }
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                    break;
                case "탈퇴 취소":
                    userCache.setID(request.getParameter("userID"));
                    if (userCache.getID() == null) {
                        out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                        userCache.resetAllElements();
                        out.println("<script>location.href='index.html';</script>");
                    }
                    try {
                    	statement.add(userCache.getID());
                        if (!mysql.SQLQueryNoOutput("UPDATE user SET del = NULL WHERE UID = ?", statement)) {
                        	throw new SQLException();
                        }
                        statement.clear();
                        out.println("<script>alert('성공적으로 탈퇴 취소가 완료되었습니다. ');</script>");
                    } catch(Exception e) {
                        statement.clear();
                        out.println("<script>alert('탈퇴 취소를 등록하는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                    }
                    userCache.resetAllElements();
                    out.println("<script>location.href='index.html';</script>");
                    break;
//                case "수정":
//                    out.println("<script>location.href='userEditor.jsp';</script>");
//                	break;
//                case "삭제":
//                    out.println("<script>location.href='userEditor.jsp';</script>");
//                	break;
//                case "제출안 적용":
//                	break;
                case "열람":
                	try {
                        if (userCache.getID() == null) {
                            out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                            userCache.resetAllElements();
                            out.println("<script>location.href='index.html';</script>");
                        }
                        userCache.setRequestID(request.getParameter("requestID"));
                        userCache.setRequestGID(request.getParameter("requestGID"));
                        userCache.setID(request.getParameter("view"));
                        statement.add(userCache.getID());
                        sqlResult = mysql.SQLQueryExistOutput("SELECT SID, GID, name, school, subject, del, edit FROM user WHERE UID = ?", statement);
                        statement.clear();
                        if (sqlResult == null) { throw new SQLException(); }
                        if (sqlResult.next()) {
                            userCache.setGID(sqlResult.getString("GID"));
                            userCache.setName(sqlResult.getString("name"));
                            userCache.setSchool(sqlResult.getString("school"));
                            userCache.setSID(sqlResult.getString("SID"));
                            userCache.setSubject(sqlResult.getString("subject"));
                            userCache.setDel(sqlResult.getString("del"));
                            userCache.setEdit(sqlResult.getString("edit"));
                        }
                        mysql.SQLClose();
                    } catch(SQLException e) {
                        statement.clear();
                        out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
                        userCache.resetAllElements();
                        out.println("<script>location.href='index.html';</script>");
                    }
                    out.println("<script>location.href='userViewer.jsp';</script>");
                	break;
//                case "편집/삭제 요청":
//                    out.println("<script>location.href='userEditor.jsp';</script>");
//                	break;
//                case "제출안 취하":
//                	break;
                default:
                    System.err.print("Sneaky redirects: ");
                    System.out.println(prevURL + "?do=" + request.getParameter("do"));
                    out.println("<script>location.href='errorPage/403code.jsp';</script>");
                    break;
            }
        	break;
        case "http://localhost:8080/StudentController/findUser.html":
        	userCache.resetAllElements();
            userCache.setMultipleElements(
            		request.getParameter("userName"),
            		request.getParameter("userSchool"),
                    request.getParameter("userPIN"),
                    request.getParameter("userSubject")
            );
            if (userCache.getName() == null) {
                out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            sqlResult = mysql.SQLQueryExistOutput("SELECT UID, name, school, SID, subject FROM user;", null);
            try {
                if (sqlResult == null) { throw new SQLException(); }
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
                    boolean nameCheck = userCache.getName().equals(name);
                    boolean schoolCheck = userCache.getSchool().equals(school);
                    boolean SIDCheck = userCache.getSID().equals(SID);
                    boolean subjectCheck = userCache.getSubject().equals(subject);
                    if ((nameCheck && schoolCheck) && (SIDCheck && subjectCheck)) {
                    	userFound = true; break;
                    }
                }
                mysql.SQLClose();
                userCache.setID(userFoundID);
                out.println("<script>location.href='resetIdentify.jsp';</script>");
            } catch(Exception e) {
                out.println("<script>alert('계정을 찾는 중에 문제가 발생하였습니다. 잠시 후 다시 시도해 주세요. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            break;
        case "http://localhost:8080/StudentController/resetIdentify.jsp":
        	userCache.setMultipleElements(request.getParameter("userID"), request.getParameter("userPW"));
            if (userCache.getID() == null) {
                out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            try {
            	statement.add(userCache.getID());
            	statement.add(userCache.getPW());
                if (!mysql.SQLQueryNoOutput("UPDATE user SET UPW = ? WHERE UID = ?", statement)) {
                	throw new SQLException();
                }
                statement.clear();
                statement.add(userCache.getID());
                if (!mysql.SQLQueryNoOutput("UPDATE user SET del = NULL WHERE UID = ?", statement)) {
                	throw new SQLException();
                }
                if (!mysql.SQLQueryNoOutput("UPDATE user SET edit = NULL WHERE UID = ?", statement)) {
                	throw new SQLException();
                }
                statement.clear();
                out.println("<script>alert('비밀번호 변경에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            } catch(Exception e) {
                statement.clear();
                out.println("<script>alert('비밀번호 변경에 실패하였습니다. 잠시후 다시 시도해 주세요. ');</script>");
            }
            userCache.resetAllElements();
            out.println("<script>location.href='index.html';</script>");
        	break;
        case "http://localhost:8080/StudentController/joinUser.html":
        	userCache.setMultipleElements(
        			request.getParameter("userID"),
                    request.getParameter("userPW"),
                    request.getParameter("GID"),
                    request.getParameter("userName"),
                    request.getParameter("userSchool"),
                    request.getParameter("userPIN"),
                    request.getParameter("userSubject")
            );
            if (userCache.getID() == null) {
                out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
        	try {
                if(!userCache.getGID().equals("2")) {
                	statement.add(userCache.getID());statement.add(userCache.getPW());statement.add(userCache.getGID());
                	statement.add(userCache.getName());statement.add(userCache.getSchool());statement.add(userCache.getSubject());

                    if (!mysql.SQLQueryNoOutput("INSERT INTO user (UID, UPW, GID, name, school, subject) VALUES (?, ?, ?, ?, ?, ?)", statement)) {
                    	throw new SQLException();
                    }
                    statement.clear();
                } else {
                    statement.add(userCache.getID());statement.add(userCache.getPW());statement.add(userCache.getSID());
                    statement.add(userCache.getName());statement.add(userCache.getSchool());statement.add(userCache.getSubject());

                    if (!mysql.SQLQueryNoOutput("INSERT INTO user (UID, UPW, SID, name, school, subject) VALUES (?, ?, ?, ?, ?, ?)", statement)) {
                    	throw new SQLException();
                    }
                    statement.clear();
                }
                out.println("<script>alert('회원 가입에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            } catch(Exception e) {
                statement.clear();
                out.println("<script>alert('회원 등록에 실패하였습니다. 잠시후 다시 시도해 주세요. ');</script>");
            }
            userCache.resetAllElements();
            out.println("<script>location.href='index.html';</script>");
        	break;
        case "http://localhost:8080/StudentController/userViewer.jsp":
            if (userCache.getID() == null) {
                out.println("<script>alert('세션이 만료되었습니다. 다시 시도해 주시기 바랍니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            switch(request.getParameter("do")) {
                case "열람":
                    userCache.setRequestID(request.getParameter("requestID"));
                    userCache.setRequestGID(request.getParameter("requestGID"));
                    userCache.setID(request.getParameter("view"));
                	break;
                case "확인":
                	userCache.setID(request.getParameter("requestID"));
                    break;
            }
            try {
                statement.add(userCache.getID());
                sqlResult = mysql.SQLQueryExistOutput("SELECT SID, GID, name, school, subject, del, edit FROM user WHERE UID = ?", statement);
                statement.clear();
                if (sqlResult == null) { throw new SQLException(); }
                if (sqlResult.next()) {
                    userCache.setGID(sqlResult.getString("GID"));
                    userCache.setName(sqlResult.getString("name"));
                    userCache.setSchool(sqlResult.getString("school"));
                    userCache.setSID(sqlResult.getString("SID"));
                    userCache.setSubject(sqlResult.getString("subject"));
                    userCache.setDel(sqlResult.getString("del"));
                    userCache.setEdit(sqlResult.getString("edit"));
                }
                mysql.SQLClose();
            } catch(SQLException e) {
                statement.clear();
                out.println("<script>alert('사용자 목록을 조회하는 도중 에러가 발생하였습니다. ');</script>");
                userCache.resetAllElements();
                out.println("<script>location.href='index.html';</script>");
            }
            out.println(request.getParameter("do").equals("열람") ?
                    "<script>location.href='userViewer.jsp';</script>" : "<script>location.href='mypage.jsp';</script>"
            );
            break;
//        case "http://localhost:8080/StudentController/userEditor.jsp":
//            break;
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
