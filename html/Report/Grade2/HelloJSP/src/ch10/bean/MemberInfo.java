package ch10.bean;

public class MemberInfo {
	private String id;
	private String pw;
	private String name;
	private String email;

	public String getId() { return id; }
	public String getPw() { return pw; }
	public String getName() { return name; }
	public String getEmail() { return email; }

	public void setId(String id) { this.id = id; }
	public void setPw(String pw) { this.pw = pw; }
	public void setName(String name) { this.name = name; }
	public void setEmail(String email) { this.email = email; }
}
