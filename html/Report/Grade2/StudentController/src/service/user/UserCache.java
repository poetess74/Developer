package service.user;

public class UserCache {
	private String ID = null;
	private String PW = null;
	private Integer GID = null;
	private String name = null;
	private String school = null;
	private String SID = null;
	private String subject = null;
	private String task = null;

	public String getID() { return ID; }
	public String getPW() { return PW; }
	public Integer getGID() { return GID; }
	public String getName() { return name; }
	public String getSchool() { return school; }
	public String getSID() { return SID; }
	public String getSubject() { return subject; }
	public String getTask() { return task; }

	public void setID(String ID) { this.ID = ID; }
	public void setPW(String PW) { this.PW = PW; }
	public void setGID(Integer GID) { this.GID = GID; }
	public void setName(String name) { this.name = name; }
	public void setSchool(String school) { this.school = school; }
	public void setSID(String SID) { this.SID = SID; }
	public void setSubject(String subject) { this.subject = subject; }
	public void setTask(String task) { this.task = task; }

	public void setMultipleElements(String UID, String UPW) {
		this.ID = UID; this.PW = UPW;
	}
	public void setMultipleElements(Integer GID, String name, String school, String SID, String subject, String task) {
		this.GID = GID; this.name = name; this.school = school;
		this.SID = SID; this.subject = subject; this.task = task;
	}
	public void setMultipleElements(String UID, String UPW, Integer GID, String name, String school, String SID, String subject) {
		this.ID = UID; this.PW = UPW; this.GID = GID; this.name = name;
		this.school = school; this.SID = SID; this.subject = subject;
	}

	public void resetAllElements() {
		this.ID = null; this.PW = null; this.GID = null; this.task = null;
		this.SID = null; this.school = null; this.subject = null; this.name = null;
	}
}
