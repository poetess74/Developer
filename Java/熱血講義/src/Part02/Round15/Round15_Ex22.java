package Part02.Round15;

import java.util.Calendar;
import java.util.Locale;
import java.util.TimeZone;

public class Round15_Ex22 {
    public static void main(String[] args) {
        Calendar calendar = Calendar.getInstance();
        int x = calendar.get(Calendar.DAY_OF_YEAR);
        System.out.println("오늘은 1년중 " + x + "번째 날입니다. ");
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        int hour = calendar.get(Calendar.HOUR_OF_DAY);
        int minute = calendar.get(Calendar.MINUTE);
        int second = calendar.get(Calendar.SECOND);
        System.out.println("year = " + year);
        System.out.println("month = " + month);
        System.out.println("hour = " + hour);
        System.out.println("ca = " + calendar.getTime());
        TimeZone.setDefault(TimeZone.getTimeZone(TimeZone.getTimeZone("America/Los_angeles").getID()));
        Locale locale = Locale.US;
        Calendar calendar1 = Calendar.getInstance(locale);
        System.out.println("ca1 = " + calendar1.getTime());
    }
}
