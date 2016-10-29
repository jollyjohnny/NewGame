using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	//public Transform myTrans;
	private float speedRatio = 3.0f;
	private Rigidbody2D myBody;
	public Animator myAnim;

	public GameObject modelGO;
	public Camera modelCam;
	private NavMeshAgent modelNavAgent;

	public float moveThrashold = 0.01f;
	private Vector2 tempPos = Vector2.zero;
	//public float acc = 20.0f;
	void Start()
	{
		myBody = gameObject.GetComponent<Rigidbody2D> ();
		modelNavAgent = modelGO.GetComponent<NavMeshAgent> ();
		//myAnim = gameObject.GetComponentInChildren<Animator> ();
	}


	void Update()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");


		if ( h > moveThrashold || v > moveThrashold || h < -moveThrashold || v < -moveThrashold) {
			Vector2 targetPos = new Vector2 (transform.position.x + h * speedRatio * Time.deltaTime/Mathf.Sqrt(h*h+v*v), transform.position.y + v * speedRatio * Time.deltaTime/Mathf.Sqrt(h*h+v*v));
			myBody.MovePosition (targetPos);
			myAnim.SetFloat ("Speed", 1.1f);

			if (modelGO.transform.localPosition.x > 20.0f || modelGO.transform.localPosition.x < -20.0f || modelGO.transform.localPosition.z > 20.0f || modelGO.transform.localPosition.z < -20.0f) 
			{
				modelGO.transform.localPosition = new Vector3 (0.0f, modelGO.transform.position.y, 0.0f);
			}
			var dir = modelCam.transform.rotation * new Vector3(h, 0, v) * 2;
			modelNavAgent.destination = dir + modelGO.transform.position;


		} 
		else
		{
			myAnim.SetFloat ("Speed",0.0f);
		}

	}
}
