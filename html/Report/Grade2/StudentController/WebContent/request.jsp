<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8" %>
<%@ page import="java.sql.*"%>
<jsp:useBean id="userCache" class="service.user.UserCache" scope="request"></jsp:useBean>
<%
    String prevURL = request.getHeader("referer");
    System.out.println(prevURL);
    switch(prevURL) {
        case "http://localhost:8080/StudentController/index.jsp":
        	userCache.setID((String) request.getAttribute("userID"));
            userCache.setPW((String) request.getAttribute("userPW"));
            //TODO: userID 와 userPW 가 DB와 매칭시 mypage.jsp로 리디렉션 아니면 index.jsp로 복귀 후 접근 거부 메시지
            break;
        case "http://localhost:8080/StudentController/mypage.jsp":
            out.println("<script>alert('로그아웃에 성공하였습니다. 방문해 주셔서 감사합니다. ');</script>");
            userCache.resetAllElements();
        	out.println("<script>location.href='index.jsp';");
        	break;
        case "http://localhost:8080/StudentController/findUser.jsp":
            userCache.setID((String) request.getAttribute("userID"));
            userCache.setPW((String) request.getAttribute("userPW"));
            //TODO: userID 를 찾아서 userPW 를 변경
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';");
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
            out.println("<script>alert('회원 가입에 성공하였습니다. 기입하신 정보로 로그인 하여 주시기 바랍니다. ');</script>");
            userCache.resetAllElements();
            out.println("<script>location.href='index.jsp';");
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
<%!
    Connection connection = null;
    PreparedStatement initialize = null;
    ResultSet result = null;
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

<%
    try {
        final String jdbcURL = "jdbc:mysql://localhost:3306/userdb?serverTimezone=UTC";
        final String dbID = "report_only";
        final String dbPW = "report";
        final String exeSQL = "SELECT uid, upw FROM user";
        Class.forName("com.mysql.cj.jdbc.Driver");
        connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
        System.out.println("Connection established.");
        initialize = connection.prepareStatement(exeSQL);
        result = initialize.executeQuery();
    } catch(Exception e) {
        System.out.println("Connection refused. ");
        e.printStackTrace();
    }
%>
