using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {
	public Transform target;

	private Vector3 lastTargetPos;
	private Vector3 offSet;

	// Use this for initialization
	void Start () {
		offSet = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		
			transform.position = target.position + offSet;

	}
}
