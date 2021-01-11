using UnityEngine;

public class HelloCSharp : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        //형 변환 캐스팅
        int height = 170;
        float heightDetail = 170.3f;

        //자동 형변환
        heightDetail = height;
        //유실되는 정보가 있을 경우 직접 명시
        height = (int) heightDetail;
        
        // 조건문 if문
        bool isBoy = false;
        if(!isBoy) {
            Debug.Log("나는 여자다. ");
        }

        int love = 60;
        if(love < 50) {
            Debug.Log("배드 엔딩");
        } else {
            Debug.Log("해피 엔딩");
        }

        int age = 17;
        if(age >= 60 || age <= 17) {
            Debug.Log("일을 하면 안된다. ");
        }

        if(age > 17 && age < 60) {
            Debug.Log("일할 나이");
        }
        
        if(age <= 7) {
            Debug.Log("유치원에 간다. ");
        } else if(age <= 12) {
            Debug.Log("초등학교에 간다. ");
        } else if(age <= 15) {
            Debug.Log("중학교에 간다. ");
        } else if(age <= 18) {
            Debug.Log("고등학교에 간다. ");
        } else {
            Debug.Log("성인");
        }
        Debug.LogFormat("!true = {0}", !true);
        
        //switch 분기문
        int year = 2017;
        switch(year) {
            case 2012: 
                Debug.Log("레미제라블");
                break;
            case 2015:
                Debug.Log("러브라이브");
                break;
            case 2016:
                Debug.Log("곡성");
                break;
            case 2017:
                Debug.Log("트랜스포머5");
                break;
            default:
                Debug.Log("연도가 해당사항 없음");
                break;
        }
        
        // 반복문
        for(int i = 0; i < 10; i++) {
            Debug.LogFormat("현재 순번: {0}", i);
        }
        Debug.Log("루프 끝");

        bool isShot = false;
        int index = 0, luckyNum = 4;
        while(!isShot) {
            index++;
            Debug.LogFormat("현재 시도: {0}", index);
            if(index == luckyNum) {
                Debug.Log("탕!");
                isShot = true;
            } else {
                Debug.Log("찰칵!");
            }
        }

        do {
            Debug.Log("Do-While");
        } while(!isShot);
    }
}
