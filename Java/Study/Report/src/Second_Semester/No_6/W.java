package Second_Semester.No_6;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Set;
import java.util.Vector;

public class W {
	public static Vector<String> hashToVector(HashMap<String, String> h) {
		Vector<String> v = new Vector<>();
		Set<String> s = h.keySet();
		Iterator<String> it = s.iterator();
		while(it.hasNext()) {
			String key = it.next();
			v.add(h.get(key));
		}
		return v;
	}

	public static void main(String[] args) {
		HashMap<String, String> h = new HashMap<>();
		h.put("범죄", "112"); h.put("화재", "119"); h.put("전화번호", "114");
		Vector<String> v = hashToVector(h);
		for(int n = 0; n < v.size(); n++) {
			System.out.print(v.get(n) + " ");
		}
	}
}
