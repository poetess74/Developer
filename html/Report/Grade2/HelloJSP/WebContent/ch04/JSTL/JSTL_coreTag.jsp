<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>JSTL</title>
    </head>
    <body>
        <c:set var="income" scope="session" value="${4000*4 }"/>
        <c:if test = "${income > 8000 }">
        	<p>My income is: <c:out value="${income }"/><p>
        	<p>My income is: ${income }<p>
		</c:if>
    </body>
</html>
