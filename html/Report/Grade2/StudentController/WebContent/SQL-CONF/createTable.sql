DROP TABLE user;

CREATE TABLE user(
    UID VARCHAR(20) NOT NULL PRIMARY KEY,
    UPW VARCHAR(50) NOT NULL,
    GID INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    school VARCHAR(50) NOT NULL,
    adminCode VARCHAR(16) NULL,
    section VARCHAR(20) NULL
);

INSERT INTO user (UID, UPW, GID, name, school, section)
    VALUES ('test', 'passwd', 2, '홍길동', '숭실대학교 부설', '컴퓨터공학');

SELECT * FROM user;