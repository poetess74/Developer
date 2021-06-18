using UnityEngine;

public class HelloUnity : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        // 주석, 컴퓨터가 처리하지 않는 라인 - 메모로 사용
        
        /*
         * 여러줄을 걸친
         * 주석을
         * 남길 수 있다. 
         */
        
        //콘솔 출력
        Debug.Log("Hello World!");
        
        //숫자형 변수
        int age = 23;
        int money = -1000;
        Debug.Log(age);
        Debug.Log(money);

        //floating point
        // 소수점 아래 7자리 까지만 정확함
        float height = 169.12345f;
        
        //float의 2배 메모리 사용 64bit
        // 소수점 아래 15자리 까지만 정확함
        double pi = 3.1415926359;

        // bool 은 true 혹은 false
        bool isBoy = true;
        bool isGirl = false;

        //char character 는 한 문자
        char grade = 'A';

        string movieTitle = "해리포터";
        Debug.LogFormat("내 나이는!: {0}", age);
        Debug.LogFormat("내가 가진 돈은!: {0}", money);
        Debug.LogFormat("내 키는!: {0}", height);
        Debug.LogFormat("원주율은!: {0}", pi);
        Debug.LogFormat("내 성적은!: {0}", grade);
        Debug.LogFormat("명작 영화!: {0}", movieTitle);
        Debug.LogFormat("나는 남자인가?: {0}", isBoy);

        //var는 할당하는 값을 기준으로 타입을 결정
        var /*string*/ myName = "I_Jemin";
        var /*int*/ myAge = 23;
        Debug.LogFormat("제민의 닉네임은 {0}, 제민의 나이는 {1}", myName, myAge);
    }
}
