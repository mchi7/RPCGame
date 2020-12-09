using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll: MonoBehaviour
{
    
	public float speed = 1f;
	public float fixedPosition;
	
	public Vector3 startingPosition;
	
	void Start() {
		startingPosition = transform.position;
	}
	
	void FixedUpdate() {
		float newPos = Mathf.Repeat(Time.time * speed, fixedPosition);
		transform.position = startingPosition + Vector3.down * newPos;
	}
	
}
