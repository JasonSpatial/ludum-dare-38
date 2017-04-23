using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {

	public int scrollSpeed;

	private Vector3 startPosition;
	
	void Start () {
		startPosition = transform.position;
		print("start position" + startPosition);
	}
	
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 1000);
		transform.position = startPosition + Vector3.left * newPosition;
		print("new position" + transform.position);
	}
}
