using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public float timeInterval = 3.0f;
	private GameObject[] figuren;
	private float[] zeitwert;
	private bool clear;
	
	// Use this for initialization
	void Start () {
		figuren = GameObject.FindGameObjectsWithTag("Figuren");
		zeitwert = new float[figuren.Length];
		clear = false;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < figuren.Length; ++i) {
			zeitwert[i] = 0.0f;
			
			for (int j = 0; j < 3; ++j)
				if (figuren[i].gameObject.GetComponent<Timerecording>().Time[2] != 0.0f)
					zeitwert[i] += figuren[i].gameObject.GetComponent<Timerecording>().Time[j];
		}
		
		if (zeitwert[0] != 0.0f) {
			int k = 0;
		
			while (++k < figuren.Length) {
				if (zeitwert[0] > zeitwert[k] + timeInterval || zeitwert[0] < zeitwert[k] - timeInterval)
					break;
			}
		
			if (k == figuren.Length) {
				clear = true;
			}
		}	
	}
	
	void OnGUI()
	{
		if(clear) {
			GUI.Box(new Rect((Screen.width - 133) / 2, (Screen.height - 100) / 2, 133, 100), "You have won!");
		}
	}
}
