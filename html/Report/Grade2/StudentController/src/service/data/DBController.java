package service.data;

import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class DBController {

	private Connection connection;
	private PreparedStatement initialize;
	private DataSource dataSource;

	public boolean SQLInitialize() {
		try {
			System.out.println("Connection initialized.");
			Context initialContext = new InitialContext();
			Context envContext = (Context)initialContext.lookup("java:comp/env");
			dataSource = (DataSource)envContext.lookup("jdbc/userdb");
			return true;
		} catch(NamingException e) {
			return false;
		}
	}

	public boolean SQLQueryNoOutput(String sql) {
		try {
			if (!SQLInitialize()) { throw new NamingException(); }
			connection = dataSource.getConnection();
			System.out.println("Connection established.");
			connection.prepareStatement(sql).executeUpdate();
			System.out.println("Connection engaged.");
			SQLClose();
			return true;
		} catch(SQLTimeoutException e) {
			System.err.println("Connection time out.");
			e.printStackTrace();
			return false;
		} catch(SQLException e) {
			System.err.println("Connection refused.");
			e.printStackTrace();
			return false;
		} catch(NamingException e) {
			System.err.println("JDBC driver failure.");
			System.err.println("Are you missing an assembly reference?");
			e.printStackTrace();
			return false;
		}
	}

	public ResultSet SQLQueryExistOutput(String sql) {
		try {
			if (!SQLInitialize()) { throw new NamingException(); }
			connection = dataSource.getConnection();
			System.out.println("Connection established.");
			initialize = connection.prepareStatement(sql);
			System.out.println("Connection engaged.");
			return initialize.executeQuery();
		} catch(SQLTimeoutException e) {
			System.err.println("Connection time out.");
			e.printStackTrace();
			return null;
		} catch(SQLException e) {
			System.err.println("Connection refused.");
			e.printStackTrace();
			return null;
		} catch(NamingException e) {
			System.err.println("JDBC driver failure.");
			System.err.println("Are you missing an assembly reference?");
			e.printStackTrace();
			return null;
		}
	}

	public void SQLClose() {
		try {
			if (connection != null) { connection.close(); }
			if (initialize != null) { initialize.close(); }
			System.out.println("Connection closed.");
		} catch(SQLException e) {
			System.err.println("Connection terminated.");
			e.printStackTrace();
		}
	}
}
