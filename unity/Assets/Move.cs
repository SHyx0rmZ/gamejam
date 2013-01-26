using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Vector3 origin = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	Vector3 Parametric(double time) {
		time = (time % (4.0 * System.Math.Tan(1.0))) - System.Math.Tan(1.0);
		
		Vector3 position = Vector3.zero;
		
		position.y = (float)System.Math.Atan(time);
		
		return position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = origin + Parametric(Time.time);
	}
}
