DROP TABLE user;

CREATE TABLE user(
    UID VARCHAR(20) NOT NULL PRIMARY KEY,
    UPW VARCHAR(40) BINARY NULL,
    SID VARCHAR(8) NULL,
    GID TINYINT UNSIGNED NOT NULL DEFAULT 2,
    name VARCHAR(18) NOT NULL,
    school VARCHAR(50) NOT NULL,
    subject VARCHAR(30) NULL
);

DESC user;

INSERT INTO user (UID, UPW, GID, name, school, subject)
    VALUES ('root', 'passwd', 0, '관리자', '숭실대학교 부설', '교학과');

INSERT INTO user (UID, UPW, SID, name, school, subject)
    VALUES ('test', 'passwd', 20191842, '홍길동', '숭실대학교 부설', '컴퓨터공학');

SELECT * FROM user;