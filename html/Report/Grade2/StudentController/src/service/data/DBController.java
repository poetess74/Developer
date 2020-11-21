package service.data;
import java.sql.*;

public class DBController {
	private final String jdbcURL = "jdbc:mysql://localhost:3306/userdb?serverTimezone=UTC";
	private final String dbID = "report_only";
	private final String dbPW = "report";

	private Connection connection;
	private PreparedStatement initialize;

	public boolean SQLInitialize() {
		try {
			System.out.println("Connection initialized.");
			connection = null;
			initialize = null;
			Class.forName("com.mysql.cj.jdbc.Driver");
			return true;
		} catch(ClassNotFoundException e) {
			return false;
		}
	}

	public boolean SQLQueryNoOutput(String sql) {
		try {
			if (!SQLInitialize()) { throw new ClassNotFoundException(); }
			connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
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
		} catch(ClassNotFoundException e) {
			System.err.println("JDBC driver failure.");
			System.err.println("Are you missing an assembly reference?");
			e.printStackTrace();
			return false;
		}
	}

	public ResultSet SQLQueryExistOutput(String sql) {
		try {
			if (!SQLInitialize()) { throw new ClassNotFoundException(); }
			connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
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
		} catch(ClassNotFoundException e) {
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
