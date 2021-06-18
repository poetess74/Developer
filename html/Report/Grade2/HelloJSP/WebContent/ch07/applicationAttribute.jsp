<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<%@ page import="java.util.Enumeration" %>

<%
    // Attribute 추가 및 가져오기
    application.setAttribute("HyeongminKim", "김형민");
    out.println(application.getAttribute("HyeongminKim"));
%>
<%
    /* web.xml의 [context-param]에 설정한 파라메터 얻어오기  */
    Enumeration<String> paramList = application.getInitParameterNames();
    String paramName = " ";
    String paramValue = " ";
    while(paramList.hasMoreElements()) {
    	paramName = paramList.nextElement();
        /* 해당 파라메터의 값 얻어오기 */
        paramValue = application.getInitParameter(paramName);

        out.println("<br>"+ paramName +" = "+ paramValue);
    }
%>
