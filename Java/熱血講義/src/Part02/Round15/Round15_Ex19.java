package Part02.Round15;

public class Round15_Ex19 {
    public static void main(String[] args) throws Exception {
        String string = "Hello Java!!!";
        char ch = string.charAt(3);
        System.out.println("ch = " + ch);
        String str1 = "www.daum.net";
        if (str1.endsWith("um.net")) {
            System.out.println(".net 사이트 입니다. ");
        }
        String str2 = "AbcD";
        String str3 = "abcd";
        if (str2.equalsIgnoreCase(str3)) {
            System.out.println("같다");
        }
        String str4 = "java2java5";
        byte[] bytes = str4.getBytes();
        for (int i = 0; i < bytes.length; i++) {
            System.out.println(i + " : " + (char)bytes[i]);
        }
        String name = "김승현";
        byte[] bytes1 = name.getBytes("KSC5601");
        //byte[] bytes1 = name.getBytes("ISO8859_1");
        System.out.println(new String(bytes1));
        String email = "aaa.aaa@com";
        boolean a = email.indexOf("@") == -1;
        boolean b = email.indexOf(".") == -1;
        boolean c = email.indexOf("@") > email.indexOf(".");
        System.out.println(!a && !b && !c ? "이메일 규칙이 올바릅니다. " : "이메일 규칙이 올바르지 않습니다. ");
        String aaa = "aaa@bbb.com";
        //String bbb = aaa.substring(4, 7);
        String bbb = aaa.substring(aaa.indexOf("@") + 1, aaa.indexOf("."));
        String ccc = aaa.substring(aaa.indexOf("@") + 1);
        System.out.println(bbb);
        char[] ddd = aaa.toCharArray();
        String eee = "FdkEasdj1EKJLFDSljfdsl";
        String fff = eee.toLowerCase();
        String ggg = eee.toUpperCase();
        String hhh = "          fjkldsajfldsa          ";
        String iii = hhh.trim();
        int x = 10;
        int y = 20;
        System.out.println(String.valueOf(x) + y);
        /*
        String str = "abc";
        String str_str = "abc";
        String str1 = new String("abc");
        String str1_str1 = new String("abc");
         */
        String pass = new String("1234");
        if (pass == "1234") {
            System.out.println("== 로 비교했을 때 같다. ");
        }
        if (pass.equals("1234")) {
            System.out.println("equals 로 비교했을 때 같다. ");
        }
    }
}
