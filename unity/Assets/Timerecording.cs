using UnityEngine;
using System.Collections;

public class Timerecording : MonoBehaviour {
	
	
	public float[] time =new float[3];
	float timeTime;
	public int count=0;
	bool plus =false;
	// Use this for initialization
	void Awake () {
		this.transform.tag = "Figuren";
	}

	void Update()
	{
		if(plus)
		{
			plus =false;
			count+=1;
		}
		if(count >= time.Length)
		{
			count =0;
		}
	}
	void OnCollisionEnter()
	{
	 	timeTime =Time.time;
		
		time[count] = timeTime;
		plus =true;
		//Debug.Log(time[count]+" "+transform.name + " "+count +" "+ plus);
		
	}
}
