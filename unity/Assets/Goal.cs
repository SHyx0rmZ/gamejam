using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public float timeInterval = 0.5f;
	public int jumpsToWin = 3;
	private GameObject[] figures;
	private float[] timesFigures;
	private int clear = 0;
	
	// Use this for initialization
	void Start()
	{
		figures = GameObject.FindGameObjectsWithTag("Figuren");
		timesFigures = new float[figures.Length];
		
		for (int i = 0; i < figures.Length; ++i) {
			if ((Timerecording)figures[i].gameObject.GetComponent<Timerecording>() == null)
				throw new MissingComponentException("Timerecording component not found");
			
			timesFigures[i] = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < figures.Length; ++i) {
			for (int j = 0; j < 3; ++j) {
				float time = figures[i].gameObject.GetComponent<Timerecording>().Time;
				
				if (time != 0.0f)
					timesFigures[i] = time;
			}
		}
		
		for (int i = 0; i < figures.Length; ++i)
			if (timesFigures[i] == 0.0f)
				return;
			
		for (int i = 1; i < figures.Length; ++i)
			if (timesFigures[i - 1] > timesFigures[i] + timeInterval || timesFigures[i - 1] < timesFigures[i] - timeInterval)
				return;
		
		clear++;
		
		for (int i = 0; i < figures.Length; ++i)
			timesFigures[i] = 0.0f;
	}
	
	void OnGUI()
	{
		if(clear >= jumpsToWin) {
			GUI.Box(new Rect((Screen.width - 133) / 2, (Screen.height - 100) / 2, 133, 100), "You have won!");
		}
	}
}
