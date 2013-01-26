using UnityEngine;
using System.Collections;

public class Timerecording : MonoBehaviour {
	private float time = 0.0f;

	public float Time {
		get {
			float result = this.time;
			
			this.time = 0.0f;
			
			return result;
		}
	}	
	// Use this for initialization
	void Awake() {
		this.transform.tag = "Figuren";
	}

	void Update() {
	}
	
	void OnCollisionEnter() {
	 	time = UnityEngine.Time.time;
	}
}
