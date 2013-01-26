using UnityEngine;
using System.Collections;

public class Timerecording : MonoBehaviour {
	private float[] time = new float[3];
	private float timeTime;
	private int count = 0;
	private bool plus = false;

	public int Count {
		get {
			return this.count;
		}
	}

	public float[] Time {
		get {
			return this.time;
		}
	}	
	// Use this for initialization
	void Awake () {
		this.transform.tag = "Figuren";
	}

	void Update()
	{
		if (plus) {
			plus = false;
			count += 1;
		}
		
		if (count >= time.Length) {
			count = 0;
		}
	}
	
	void OnCollisionEnter()
	{
	 	timeTime = UnityEngine.Time.time;
		time[count] = timeTime;
		plus = true;
	}
}
