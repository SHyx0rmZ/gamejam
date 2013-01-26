using UnityEngine;
using System.Collections;

public class trampoline : MonoBehaviour {
	public float bounciness = 10.0f;
	private GameObject jumper = null;
	private GameObject cube;
	private Dropzone drop;
	
	// Use this for initialization
	void Start () {
		cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		
		if (cube == null)
			throw new UnityException("Could not create primitive");
		
		drop = (Dropzone)cube.AddComponent(typeof(Dropzone));
		
		if (drop == null)
			throw new MissingComponentException("Dropzone component not found");
		
		drop.Jumper = jumper;
		cube.layer = 8;
		cube.transform.localScale = this.transform.lossyScale + new Vector3(0.0f, 5.0f, 0.0f);
		cube.transform.position = this.transform.position + new Vector3(0.0f, cube.transform.localScale.y / 2.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionStay (Collision collision) {
		if (collision.rigidbody) {
			if (collision.transform.position.y < this.transform.position.y)
				collision.rigidbody.AddForce(Vector3.down * 50.0f * bounciness);
			else
        		collision.rigidbody.AddForce(Vector3.up * 50.0f * bounciness);
			
			if (drop.Jumper == null) {
				drop.Jumper = collision.gameObject;
			}
        }
	}
}
