package member.service;

@SuppressWarnings("serial")
public class MemberDBException extends Exception {
	public MemberDBException(String message) {
		super(message);
	}
	
	public MemberDBException(String message, Throwable cause) {
		super(message, cause);
	}
}
