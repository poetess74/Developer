package service.data;
import java.sql.*;

public class DBController {
	private final String jdbcURL = "jdbc:mysql://localhost:3306/userdb?serverTimezone=UTC";
	private final String dbID = "report_only";
	private final String dbPW = "report";

	private Connection connection = null;
	private PreparedStatement initialize = null;

	public void SQLQueryNoOutput(String sql) {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
			System.out.println("Connection established.");
			initialize = connection.prepareStatement(sql);
			initialize.executeUpdate();
		} catch(SQLTimeoutException e) {
			System.err.println("Connection time out.");
			e.printStackTrace();
		} catch(SQLException e) {
			System.err.println("Connection refused.");
			e.printStackTrace();
		} catch(Exception e) {
			System.err.println("Connection terminated.");
			System.err.println("Are you missing an assembly reference?");
			e.printStackTrace();
		}
	}
	public ResultSet SQLQueryExistOutput(String sql) {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection = DriverManager.getConnection(jdbcURL, dbID, dbPW);
			System.out.println("Connection established.");
			initialize = connection.prepareStatement(sql);
			return initialize.executeQuery();
		} catch(SQLTimeoutException e) {
			System.err.println("Connection time out.");
			e.printStackTrace();
			return null;
		} catch(SQLException e) {
			System.err.println("Connection refused.");
			e.printStackTrace();
			return null;
		} catch(Exception e) {
			System.err.println("Connection terminated.");
			System.err.println("Are you missing an assembly reference?");
			e.printStackTrace();
			return null;
		}
	}
}
