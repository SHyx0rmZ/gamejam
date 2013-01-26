using UnityEngine;
using System.Collections;

public class trampoline : MonoBehaviour {
	public float bounciness = 10.0f;
	public GameObject jumper = null;
	GameObject cube;
	Dropzone drop;
	
	// Use this for initialization
	void Start () {
		cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		
		if (cube == null)
			throw new UnityException("Could not create primitive");
		
		drop = (Dropzone)cube.AddComponent(typeof(Dropzone));
		
		if (drop == null)
			throw new MissingComponentException("Dropzone component not found");
		
		drop.jumper = jumper;
		cube.layer = 9;
		//modbouncy *= System.Math.Abs(modbouncy);
		//modbouncy /= 2.0f;
		////modbouncy += 5.0f;
		////modbouncy = 5.0f;
		cube.transform.localScale = this.transform.lossyScale + new Vector3(0.0f, 5.0f, 0.0f);
		cube.transform.position = this.transform.position + new Vector3(0.0f, cube.transform.localScale.y / 2.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//RaycastHit hit = new RaycastHit();
		//if (cube.collider.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward), out hit, 1000.0f))
		//	cube.layer = (cube.layer == 9 ? 8 : 9);
	}
	
	void OnCollisionStay (Collision collision) {
		if (collision.rigidbody) 
		{
        	collision.rigidbody.AddForce(Vector3.up * 50.0f * bounciness);
			
			if (drop.jumper == null)
			{
				drop.jumper = collision.gameObject;
			}
        }
	}
}
