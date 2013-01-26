using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public float timeInterval = 3.0f;
	public int jumpsToWin = 3;
	private PickupRemember remember = null;
	
	// Use this for initialization
	void Start()
	{
		Goal goal = (Goal)gameObject.AddComponent(typeof(Goal));
		
		if (goal == null)
			throw new MissingComponentException("Goal component not found");
		
		goal.timeInterval = timeInterval;
		goal.jumpsToWin = jumpsToWin;
		
		remember = (PickupRemember)gameObject.AddComponent(typeof(PickupRemember));
		
		if (remember == null)
			throw new MissingComponentException("PickupRemember component not found");
		
		remember.Item = null;
	}
	
	// Update is called once per frame
	void Update() {
	}
}
