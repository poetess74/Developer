<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<%@ page import="service.data.DBController" %>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="request"></jsp:useBean>
<%
    DBController mysql = new DBController();
    ResultSet sqlResult = null;
    String prevURL = request.getHeader("referer");
    System.out.println(prevURL);
    switch(prevURL) {
        case "http://localhost:8080/StudentController/index.jsp":
        	userCache.setID((String) request.getAttribute("userID"));
            userCache.setPW((String) request.getAttribute("userPW"));
            sqlResult = mysql.ExecuteSQLQuery("SELECT UID, UPW FROM user;");
            try {
                if (sqlResult.next()) {
                    String dataID = sqlResult.getString("UID");
                	String dataPW = sqlResult.getString("UPW");
                    if ((userCache.getID().equals(dataID) && userCache.getPW().equals(dataPW))) {
                        out.println("<script>alert('아이디 또는 비밀번호가 다릅니다. ');</script>");
                        userCache.resetAllElements();
                        out.println("<script>location.href='index.jsp';</script>");
                    }
                }
            } catch(SQLException e) {
                System.err.println("Connection refused.");
                e.printStackTrace();
            }
            //TODO: userID 와 userPW 가 DB와 매칭시 mypage.jsp로 리디렉션 아니면 index.jsp로 복귀 후 접근 거부 메시지
            break;
        case "http://localhost:8080/StudentController/mypage.jsp":
            out.println("<script>alert('로그아웃에 성공하였습니다. 방문해 주셔서 감사합니다. ');</script>");
            userCache.resetAllElements();
        	out.println("<script>location.href='index.jsp';</script>");
        	break;
        case "http://localhost:8080/StudentController/findUser.jsp":
            userCache.setID((String) request.getAttribute("userID"));
            userCache.setPW((String) request.getAttribute("userPW"));
            mysql.ExecuteSQLQuery("UPDATE user SET UPW = '" + userCache.getPW() + "' WHERE UID = '" + userCache.getID() + "';");
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';</script>");
        	break;
        case "http://localhost:8080/StudentController/joinUser.jsp":
        	userCache.setAllElements(
        			(String) request.getAttribute("userID"),
                    (String) request.getAttribute("userPW"),
                    (Integer) request.getAttribute("userGID"),
                    (String) request.getAttribute("userName"),
                    (String) request.getAttribute("userSchool"),
                    (String) request.getAttribute("userPIN"),
                    (String) request.getAttribute("usersection")
            );
            //TODO: 등록된 모든 정보를 DB에 적용
            if (userCache.getGID() != 2) {
                mysql.ExecuteSQLQuery("INSERT INTO user (UID, UPW, GID, name, school, subject) VALUES ("
                        + userCache.getID() + ", " + userCache.getPW() + ", " + userCache.getGID() + ", "
                        + userCache.getName() + ", " + userCache.getSchool() + ", " + userCache.getSection() +");");
            } else {
                mysql.ExecuteSQLQuery("INSERT INTO user (UID, UPW, SID, name, school, subject) VALUES ("
                        + userCache.getID() + ", " + userCache.getPW() + ", " + userCache.getStudentCode() + ", "
                        + userCache.getName() + ", " + userCache.getSchool() + ", " + userCache.getSection() +");");
            }
            out.println("<script>alert('회원 가입에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';</script>");
        	break;
        default:
            System.err.print("Sneaky redirects: ");
            System.out.println(prevURL);
            out.println(
                "<script>" +
                    "alert('확인되지 않은 예외가 발생하였습니다. 메인 페이지로 리디렉션 됩니다. ');" +
                    "location.href='index.jsp';" +
                "</script>"
            );
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
