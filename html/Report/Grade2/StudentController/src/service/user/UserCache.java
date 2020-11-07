package service.user;

public class UserCache {
	private String ID = null;
	private String PW = null;
	private String GID = null;
	private String school = null;
	private String activateCode = null;
	private String section = null;

	public String getID() { return ID; }
	public String getPW() { return PW; }
	public String getGID() { return GID; }
	public String getSchool() { return school; }
	public String getActivateCode() { return activateCode; }
	public String getSection() { return section; }

	public void setID(String ID) { this.ID = ID; }
	public void setPW(String PW) { this.PW = PW; }
	public void setGID(String GID) { this.GID = GID; }
	public void setSchool(String school) { this.school = school; }
	public void setActivateCode(String activateCode) { this.activateCode = activateCode; }
	public void setSection(String section) { this.section = section; }
}
