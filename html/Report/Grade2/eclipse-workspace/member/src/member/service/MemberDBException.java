package member.service;

@SuppressWarnings("serial")
public class MemberDBException extends Exception {
    // DB 전용 예외 메시지
	public MemberDBException(String message) {
		super(message);
	}
	
    // DB 전용 예외 이유와 메시지
	public MemberDBException(String message, Throwable cause) {
		super(message, cause);
	}
}
