using UnityEngine;

public class AnimalTest : MonoBehaviour {

    private void Start() {
        Cat nate = new Cat();
        nate.name = "Nate";
        nate.weight = 1.5f;
        nate.year = 3;
        
        nate.Stealth();
        nate.Print();
    }

    private class Animal {
        public string name;
        public float weight;
        public int year;

        public void Print() {
            Debug.LogFormat("{0}| 몸무게: {1}| 나이: {2}", name, weight, year);
        }

        protected float GetSpeed() {
            return CalcSpeed();
        }

        private float CalcSpeed() {
            return 100f / (weight * year);
        }
    }

    private class Cat : Animal {
        public void Hunt() {
            float speed = GetSpeed();
            Debug.LogFormat("{0}의 속도로 달려가서 사냥했다. ", speed);
            weight += 2f;
        }

        public void Stealth() {
            Debug.Log("숨었다. ");
        }
    }
}
