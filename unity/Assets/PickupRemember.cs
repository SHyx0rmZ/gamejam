using UnityEngine;
using System.Collections;

public class PickupRemember : MonoBehaviour {
	public GameObject item = null;

	// Use this for initialization
	void Start () {
	}
	
	void SetItem(GameObject item)
	{
		if (this.item != null)
			this.item.layer = 1;
		
		this.item = item;
		
		if (item != null)
			item.layer = 9;
	}
	
	// Update is called once per frame
	void Update () {
		if (item != null)
		{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			item.transform.position = new Vector3(mouse.x, mouse.y, 0.0f);
		}
	}
}
