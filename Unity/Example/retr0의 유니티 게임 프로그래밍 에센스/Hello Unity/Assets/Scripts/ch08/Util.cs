using UnityEngine;

public class Util : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
        Print(30);
        Print("Hello");
        
        var container = new Container<string>();
        container.messages = new string[3];
        container.messages[0] = "Hello";
        container.messages[1] = "World";
        container.messages[2] = "Generic";
        foreach(var index in container.messages) {
            Debug.Log(index);
        }
        var containers = new Container<int>();
        containers.messages = new int[3];
        containers.messages[0] = 0;
        containers.messages[1] = 1;
        containers.messages[2] = 100;
        foreach(var index in containers.messages) {
            Debug.Log(index);
        } 
    }

    private void Print<T>(T input) {
        Debug.Log(input);
    }

    private class Container<T> {
        public T[] messages;
    }
}
