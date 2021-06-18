using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	public string Name;

	void Start() {
		Debug.Log("Hello, " + Name + "!");
	}
}
