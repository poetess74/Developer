package ch13.board;

import ch12.member.LogonDataBean;

import javax.naming.*;
import javax.sql.DataSource;
import java.sql.*;

public class BoardDBBean {
	private static BoardDBBean instance = new BoardDBBean();

	public static BoardDBBean getInstance() {
		return instance;
	}

	private BoardDBBean() {
		// empty method body
	}

	private Connection getConnection() throws Exception {
		Context initCtx = new InitialContext();
		Context envCtx = (Context)initCtx.lookup("java:comp/env");
		DataSource dataSource = (DataSource)envCtx.lookup("jdbc/hellojsp");
		return dataSource.getConnection();
	}

	public void insertMember(LogonDataBean member) {
		Connection connection = null;
		PreparedStatement initialized = null;
		try {
			connection = getConnection();
			initialized = connection.prepareStatement("INSERT INTO member VALUES (?, ?, ?, ?)");
			initialized.setString(1, member.getId());
			initialized.setString(2, member.getPw());
			initialized.setString(3, member.getName());
			initialized.setString(4, member.getEmail());
			initialized.executeUpdate();
		} catch(Exception e) {
			e.printStackTrace();
		} finally {
			if (initialized != null) {
				try { initialized.close(); } catch(SQLException e) { }
			}
			if (initialized != null) {
				try { connection.close(); } catch(SQLException e) { }
			}
		}
	}

	public boolean userCheck(String id, String password) {
		Connection connection = null;
		PreparedStatement initialized = null;
		ResultSet recode = null;
		String dbPass = "";
		boolean checkResult = false;

		try {
			connection = getConnection();
			initialized = connection.prepareStatement("SELECT member_pw FROM member WHERE member_id = ?");
			initialized.setString(1, id);
			recode = initialized.executeQuery();
			if (recode.next()) {
				dbPass = recode.getString("member_pw");
				checkResult = dbPass.equals(password);
			}
		} catch(Exception e) {
			e.printStackTrace();
		} finally {
			if (recode != null) {
				try { recode.close(); } catch(SQLException e) { }
			}
			if (initialized != null) {
				try { initialized.close(); } catch(SQLException e) { }
			}
			if (connection!= null) {
				try { connection.close(); } catch(SQLException e) { }
			}
		}
		return checkResult;
	}
}
