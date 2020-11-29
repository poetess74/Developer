package member.data;

public class Member {
    // DB 어트리뷰트와 매칭되는 필드들
    private String userId;
    private String password;
    private boolean isAdmin;
    private String name;
    private String school;
    private String department;
    private String studentId;
    
    public Member() {
        // empty method body for JavaBeans
    }
    
    //member 설정시 필드를 한번에 설정해줌
    public static Member create(
            String userId, 
            String password, 
            boolean isAdmin, 
            String name, 
            String school, 
            String department, 
            String studentId) {
        
        var member = new Member();
        
        member.setUserId(userId);
        member.setPassword(password);
        member.setAdmin(isAdmin);
        member.setName(name);
        member.setSchool(school);
        member.setDepartment(department);
        member.setStudentId(studentId);
        
        return member;
    }
    
    //getter/setter
    public String getUserId() {
        return userId;
    }
    
    public void setUserId(String userId) {
        this.userId = userId;
    }
    
    public String getPassword() {
        return password;
    }
    
    public void setPassword(String password) {
        this.password = password;
    }
    
    public boolean isAdmin() {
        return isAdmin;
    }
    
    public void setAdmin(boolean isAdmin) {
        this.isAdmin = isAdmin;
    }
    
    public String getName() {
        return name;
    }
    
    public void setName(String name) {
        this.name = name;
    }
    
    public String getSchool() {
        return school;
    }
    
    public void setSchool(String school) {
        this.school = school;
    }
    
    public String getDepartment() {
        return department;
    }
    
    public void setDepartment(String department) {
        this.department = department;
    }
    
    public String getStudentId() {
        return studentId;
    }
    
    public void setStudentId(String studentId) {
        this.studentId = studentId;
    }
}
