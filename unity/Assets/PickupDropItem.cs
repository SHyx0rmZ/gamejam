using UnityEngine;
using System.Collections;

public class PickupDropItem : MonoBehaviour {
	private bool down = false;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver() {
		if (!down && Input.GetMouseButton(0))
		{
			/*PickupRemember remember = Camera.main.GetComponent<PickupRemember>();
			
			if (remember == null)
				throw new MissingComponentException("PickupRemember component not found in main camera");
			
			if (remember.item == null)
			{
				remember.item = this;
			}
			else
			{
				Debug.Log("replace?");
				
				RaycastHit hit = new RaycastHit();
				
				if (Physics.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward), out hit, 1000.0f))
				{
					if (hit.collider == null)
						throw new UnityException("No item to swap with");
					else
						Debug.Log(hit.collider);
				}
			}*/
		}
	}
	
	// Update is called once per frame
	void Update () {
		down = Input.GetMouseButton(0);
	}
}
