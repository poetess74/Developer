DROP TABLE member;

CREATE TABLE MEMBER(
    MEMBER_ID VARCHAR(24) NOT NULL PRIMARY KEY,
    MEMBER_PW VARCHAR(24) NOT NULL,
    MEMBER_NAME VARCHAR(40) NOT NULL,
    MEMBER_EMAIL VARCHAR(60) NOT NULL
);

DESC member;

INSERT INTO member VALUES ('C20201113', '1234', '홍길동', 'gildong@gmail.com');

SELECT * FROM member;