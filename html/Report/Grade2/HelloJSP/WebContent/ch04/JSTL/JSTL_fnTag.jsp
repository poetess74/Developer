<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>JSTL</title>
    </head>
    <body>
        <c:set var="str1" value="Welcome to JSP Programming"/>
        ${ fn:toLowerCase(str1) }<br>
        ${ fn:toLowerCase("Welcome to JSP Programming") }<br>
        
        <c:set var="str2" value="오늘도 좋은 하루!!"/>
        Length of the str2 is: ${ fn:length(str2) }<br>
        Length of the str2 is: ${ fn:length("내일도 좋은 하루!!") }<br>
        
    </body>
</html>
