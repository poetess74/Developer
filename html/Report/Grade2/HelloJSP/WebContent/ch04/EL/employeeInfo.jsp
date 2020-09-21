<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<%@ page import="java.util.HashMap" %>
<%@ page import="java.util.ArrayList" %>
<%@ page session="true" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>응답 페이지</title>
    </head>
    <body>
    <%
        ArrayList<HashMap> list = (ArrayList<HashMap>)session.getAttribute("emp_list");

        if (list == null) {
        	list = new ArrayList<>();
        	session.setAttribute("emp_list", list);
        }

        HashMap e = new HashMap();

        e.put("empno", request.getParameter("empno"));
        e.put("ename", request.getParameter("ename"));
        e.put("job", request.getParameter("job"));
        e.put("sal", request.getParameter("sal"));
        e.put("deptno", request.getParameter("deptno"));

        list.add(e);
    %>
        <table border="1" align="left">
            <th width="100">empno</th>
            <th width="100">ename</th>
            <th width="200">job</th>
            <th width="100">sal</th>
            <th width="100">deptno</th>
            <c:forEach items="${emp_list}" var="emp">
            <tr>
                <td><c:out value="${emp.empno}"/></td>
                <td><c:out value="${emp.ename}"/></td>
                <td><c:out value="${emp.job}"/></td>
                <td><c:out value="${emp.sal}"/></td>
                <td><c:out value="${emp.deptno}"/></td>
            </tr>
            </c:forEach>
            <!--
            <tr>
                <td>${param.empno}</td>
                <td>${param.ename}</td>
                <td>${param.job}</td>
                <td>${param.sal}</td>
                <td>${param.deptno}</td>
            </tr>
            -->
        </table>
    </body>
</html>
