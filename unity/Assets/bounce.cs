using UnityEngine;
using System.Collections;

public class bounce : MonoBehaviour {
	public float mass = 1.0f;
	
	// Use this for initialization
	void Start () {
		Rigidbody rigid = (Rigidbody)gameObject.AddComponent(typeof(Rigidbody));
		
		if (rigid == null)
			throw new MissingComponentException("Rigidbody component not found");
		
		rigid.mass = mass;
		rigid.constraints = RigidbodyConstraints.FreezeAll ^ RigidbodyConstraints.FreezePositionY;
		
		Timerecording recording = (Timerecording)gameObject.AddComponent(typeof(Timerecording));
		
		if (recording == null)
			throw new MissingComponentException("Timerecording component not found");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
