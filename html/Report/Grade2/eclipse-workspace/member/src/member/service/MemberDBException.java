package member.service;

// MemberDBService 사용 중 발생할 수 있는 오류를 표현하기 위한 예외 클래스
@SuppressWarnings("serial")
public class MemberDBException extends Exception {
	public MemberDBException(String message) {
		super(message);
	}
	
	public MemberDBException(String message, Throwable cause) {
		super(message, cause);
	}
}
