<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>JSTL</title>
    </head>
    <body>
        <h3>Parsed Date:</h3>
        <c:set var="date" value="16-09-2020"/>
        <p><c:out value="${date }"/></p>
        <fmt:parseDate value="${date }" var="cntDate1" pattern="dd-MM-yyyy"/>
        <p><c:out value="${cntDate1 }"/></p>
        <c:set var="cntDate2" value="<%=new java.util.Date() %>"/>
        <p><b>Date and Time in KST: </b>
        <fmt:formatDate value="${cntDate2 }" pattern="yyyy-MM-dd"/></p>
        <fmt:setTimeZone value="GMT-10"/>
        <p><b>Date and Time in GMT: </b>
        <fmt:formatDate value="${cntDate2 }" pattern="yyyy-MM-dd"/></p>
    </body>
</html>
