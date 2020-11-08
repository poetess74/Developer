DROP TABLE user;

CREATE TABLE user(
    UID VARCHAR(20) NOT NULL PRIMARY KEY,
    UPW VARCHAR(40) BINARY NULL,
    SID VARCHAR(8) NULL,
    GID TINYINT UNSIGNED NOT NULL DEFAULT 2,
    name VARCHAR(18) NOT NULL,
    school VARCHAR(50) NOT NULL,
    subject VARCHAR(30) NULL,
    task VARCHAR(12) NULL
);

DESC user;

INSERT INTO user (UID, UPW, GID, name, school, subject)
    VALUES ('root', 'passwd', 0, '관리자', '숭실대학교 부설', '교학과');

INSERT INTO user (UID, UPW, GID, name, school, subject)
    VALUES ('id', 'passwd', 0, '정보관리', '숭실대학교 부설', '정보화팀');

INSERT INTO user (UID, UPW, GID, name, school, subject)
    VALUES ('admin', 'passwd', 1, '관계자', '숭실대학교 부설', '학생서비스팀');

INSERT INTO user (UID, UPW, GID, name, school, subject)
    VALUES ('1234', 'passwd', 1, '테스터', '숭실대학교 부설', '학사팀');

INSERT INTO user (UID, UPW, SID, name, school, subject)
    VALUES ('test', 'passwd', 20191842, '홍길동', '숭실대학교 부설', '컴퓨터공학');

INSERT INTO user (UID, UPW, SID, name, school, subject)
    VALUES ('abcd', 'passwd', 20192842, '김철수', '숭실대학교 부설', '정보보안');

SELECT * FROM user;