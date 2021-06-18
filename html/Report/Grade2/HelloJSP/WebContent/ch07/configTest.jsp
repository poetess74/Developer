<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>

<%@ page import="java.util.Enumeration"  %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>config 내장객체</title>
    </head>
    <body>
        <h2>파라메터 표시</h2>
        <%
            /* 모든 초기화 파라미터 이름 리턴 */
            Enumeration <String> initParam = config.getInitParameterNames();

            String paramName = "";
            String paramValue = "";

            while(initParam.hasMoreElements()) {
            	paramName = initParam.nextElement();

                /* 파라미터 이름에 해당하는 속성값 얻어오기 */
                paramValue = config.getInitParameter(paramName);
                out.println(paramName + " : " + paramValue +"<br>");
            }
        %>
    </body>
</html>