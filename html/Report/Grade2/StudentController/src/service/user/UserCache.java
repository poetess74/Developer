package service.user;

public class UserCache {
	private String ID = null;
	private String PW = null;
	private Integer GID = null;
	private String name = null;
	private String school = null;
	private String studentCode = null;
	private String section = null;

	public String getID() { return ID; }
	public String getPW() { return PW; }
	public Integer getGID() { return GID; }
	public String getName() { return name; }
	public String getSchool() { return school; }
	public String getStudentCode() { return studentCode; }
	public String getSection() { return section; }

	public void setID(String ID) { this.ID = ID; }
	public void setPW(String PW) { this.PW = PW; }
	public void setGID(Integer GID) { this.GID = GID; }
	public void setName(String name) { this.name = name; }
	public void setSchool(String school) { this.school = school; }
	public void setStudentCode(String studentCode) { this.studentCode = studentCode; }
	public void setSection(String section) { this.section = section; }

	public void setAllElements(String id, String pw, Integer GID, String name, String school, String code, String section) {
		this.ID = id; this.PW = pw; this.GID = GID; this.name = name;
		this.school = school; this.studentCode = code; this.section = section;
	}
	public void resetAllElements() {
		this.ID = null;
		this.PW = null;
		this.GID = null;
		this.studentCode = null;
		this.school = null;
		this.section = null;
	}
}
