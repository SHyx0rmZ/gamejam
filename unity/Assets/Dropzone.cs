using UnityEngine;
using System.Collections;

public class Dropzone : MonoBehaviour {
	private bool down = false;
	private bool last = false;
	private PickupRemember remember = null;
	private GameObject jumper = null;

	public GameObject Jumper {
		get {
			return this.jumper;
		}
		set {
			jumper = value;
		}
	}	
	// Use this for initialization
	void Start () {
		remember = Camera.main.GetComponent<PickupRemember>();
		
		if (remember == null)
			throw new MissingComponentException("PickupRemember component not found in main camera");
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit = new RaycastHit ();
		
		if (this.collider.Raycast (new Ray (Camera.main.ScreenToWorldPoint (Input.mousePosition), Camera.main.transform.forward), out hit, 1000.0f)) {
			last = down;
			down = Input.GetMouseButtonDown (0) || Input.GetMouseButton (0);
			Vector3 position = this.transform.position + new Vector3 (0f, 6.0f - this.transform.localScale.y / 2.0f, 0.0f);
			position.y = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			Vector3 posmouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (jumper != null)
				posmouse.z = jumper.transform.position.z;

			if (!last && down) {
				if (remember.Item == null && jumper != null && (posmouse - jumper.transform.position).magnitude < 1.0) {
					remember.Item = jumper;
					jumper = null;
				} else if (remember.Item != null && jumper != null && (posmouse - jumper.transform.position).magnitude < 1.0) {
					GameObject temp = jumper;
					jumper = remember.Item;
					remember.Item.transform.position = position;
					remember.Item.rigidbody.velocity = Vector3.zero;
					remember.Item = temp;
				} else if (remember.Item != null && jumper == null) {
					remember.Item.transform.position = position;
					remember.Item.rigidbody.velocity = Vector3.zero;
					remember.Item = null;
					jumper = remember.Item;
				}
			}
		}
	}
}
