using UnityEngine;

public class HelloClass : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        Animal jack = new Animal();
        jack.name = "JACK";
        jack.sound = "Bark";
        jack.weight = 4.5f;

        Animal nate = new Animal();
        nate.name = "NATE";
        nate.sound = "Nyaa";
        nate.weight = 1.2f;

        Animal annie = new Animal();
        annie.name = "ANNIE";
        annie.sound = "Wee";
        annie.weight = 0.8f;

        nate = jack;
        nate.name = "JIMMY";
        nate.sound = "Cheese";
        
        Debug.Log(jack.name);
        Debug.Log(jack.sound);
        
        Debug.Log(nate.name);
        Debug.Log(nate.sound);
        
        Debug.Log(annie.name);
        Debug.Log(annie.sound);
    }

    private class Animal {
        public string name;
        public string sound;
        public float weight;
    }
}