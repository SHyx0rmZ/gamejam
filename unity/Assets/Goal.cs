using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	public float abweichung= 3.0f;
	GameObject[] figuren;
	float[] zeitwert;
	bool clear;
	
	// Use this for initialization
	void Start () {
		figuren = GameObject.FindGameObjectsWithTag("Figuren");
		zeitwert = new float[figuren.Length];
		clear = false;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < figuren.Length; ++i)
		{
			zeitwert[i] = 0.0f;
			
			for (int j = 0; j < 3; ++j)
				if (figuren[i].gameObject.GetComponent<Timerecording>().time[2] != 0.0f)
					zeitwert[i] += figuren[i].gameObject.GetComponent<Timerecording>().time[j];
		}
		
		if (zeitwert[0] != 0.0f)
		{
			int k = 0;
		
			while (++k < figuren.Length)
			{
				if (zeitwert[0] > zeitwert[k] + abweichung || zeitwert[0] < zeitwert[k] - abweichung)
					break;
			}
		
			if (k == figuren.Length)
			{
				clear = true;
			}
		}	
	}
	
	void OnGUI()
	{
		if(clear)
		{
			GUI.Box(new Rect(100,100,100,100), "You won!");
		}
	}
}
