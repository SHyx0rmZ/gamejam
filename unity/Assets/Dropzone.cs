using UnityEngine;
using System.Collections;

public class Dropzone : MonoBehaviour {
	private bool down = false;
	private bool last = false;
	private PickupRemember remember = null;
	public GameObject jumper = null;
	
	// Use this for initialization
	void Start () {
		remember = Camera.main.GetComponent<PickupRemember>();
		
		if (remember == null)
			throw new MissingComponentException("PickupRemember component not found in main camera");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		if (this.collider.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward), out hit, 1000.0f))
		{
		last = down;
		down = Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);
		if (!last && down)
		{
			if (remember.item == null && jumper != null)
			{
				remember.item = jumper;
				jumper = null;
			}
			else if (remember.item != null && jumper != null)
			{
				GameObject temp = jumper;
				jumper = remember.item;
				remember.item.transform.position = this.transform.position + new Vector3(0.0f, this.transform.localScale.y / 2.0f - 1.0f, 0.0f);
				remember.item.rigidbody.velocity = Vector3.zero;
				remember.item = temp;
			}
			else if (remember.item != null && jumper == null)
			{
				remember.item.transform.position = this.transform.position + new Vector3(0.0f, this.transform.localScale.y / 2.0f - 1.0f, 0.0f);
				remember.item.rigidbody.velocity = Vector3.zero;
				remember.item = null;
				jumper = remember.item;
			}
		}
		}
	}
}
