package service.user;

public class UserCache {
	private String ID = null;
	private String PW = null;
	private String GID = null;
	private String name = null;
	private String school = null;
	private String SID = null;
	private String subject = null;
	private String del = null;
	private String edit = null;
	private String requestID = null;
	private String requestPW = null;

	public String getID() { return ID; }
	public String getPW() { return PW; }
	public String getGID() { return GID; }
	public String getName() { return name; }
	public String getSchool() { return school; }
	public String getSID() { return SID; }
	public String getSubject() { return subject; }
	public String getDel() { return del; }
	public String getEdit() { return edit; }
	public String getRequestID() { return requestID; }
	public String getRequestPW() { return requestPW; }

	public void setID(String ID) { this.ID = ID; }
	public void setPW(String PW) { this.PW = PW; }
	public void setGID(String GID) { this.GID = GID; }
	public void setName(String name) { this.name = name; }
	public void setSchool(String school) { this.school = school; }
	public void setSID(String SID) { this.SID = SID; }
	public void setSubject(String subject) { this.subject = subject; }
	public void setDel(String del) { this.del = del; }
	public void setEdit(String edit) { this.edit = edit; }
	public void setRequestID(String requestID) { this.requestID = requestID; }
	public void setRequestPW(String requestPW) { this.requestPW = requestPW; }

	public void setMultipleElements(String UID, String UPW) {
		this.ID = UID; this.PW = UPW;
	}
	public void setMultipleElements(String name, String school, String SID, String subject) {
		this.name = name; this.school = school; this.SID = SID; this.subject = subject;
	}
	public void setMultipleElements(String UID, String UPW, String GID, String name, String school, String SID, String subject) {
		this.ID = UID; this.PW = UPW; this.GID = GID; this.name = name;
		this.school = school; this.SID = SID; this.subject = subject;
	}

	public void resetAllElements() {
		this.ID = null; this.PW = null; this.GID = null; this.del = null;
		this.edit = null; this.SID = null; this.school = null; this.subject = null;
		this.name = null; this.requestID = null; this.requestPW = null;
	}
}
