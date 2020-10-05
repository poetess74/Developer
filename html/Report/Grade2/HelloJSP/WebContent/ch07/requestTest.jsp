<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<%@ page import="java.util.Enumeration" %>

<html>
    <head>
        <title>request 내장객체 예제</title>
    </head>
    <body>
        <h2>웹 브라우저와 웹 서버 정보 표시</h2>
        <%
            String[] names = {
            		"프로토콜이름", "서버이름", "Method방식",
                    "컨텍스트 경로", "URI", "접속한 클라이언트의 IP"
            };
            /* 2. request 내장객체가 제공하는 메소드를 사용하여
            서버이름, Method 방식, 컨텍스트 경로, URI, 접속한 클라이언트 IP 정보 얻어오기 */
            String[] values = {
            		request.getProtocol(), request.getServerName(), request.getMethod(),
                    request.getContextPath(), request.getRequestURI(), request.getRemoteAddr()
            };

            for(int i = 0; i < names.length; i++) {
                out.println(names[i] + " : " + values[i] + "<br>");
            }
        %>

        <h2>헤더의 정보 표시</h2>
        <%
            /* 3. request 내장객체가 제공하는 메소드를 사용하여 HTTP 요청 헤더에 있는 모든 헤더 이름 얻어오기 */
            Enumeration<String> en = request.getHeaderNames();

            String headerName = "";
            String headerValue = "";

            while(en.hasMoreElements()) {
                headerName = en.nextElement();

                /* 4.헤더 이름에 해당하는 속성값 얻어오기 */
                headerValue = request.getHeader(headerName);
                out.println(headerName + " : " + headerValue + "<br>");
            }
        %>
    </body>
</html>
