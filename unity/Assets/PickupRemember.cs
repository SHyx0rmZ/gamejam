using UnityEngine;
using System.Collections;

public class PickupRemember : MonoBehaviour {
	private GameObject item = null;

	public GameObject Item {
		get {
			return this.item;
		}
		set {
			if (item != null)
				item.layer = 1;
			
			item = value;
			
			if (value != null)
				value.layer = 9;
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (item != null) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			item.transform.position = new Vector3(mouse.x, mouse.y, 0.0f);
		}
	}
}
