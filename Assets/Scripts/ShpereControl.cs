using UnityEngine;
using System.Collections;

public class ShpereControl : MonoBehaviour {
	
	private Vector3 speed=new Vector3(0,0,8.0f);
	
	private GameObject cube;
	
	private CharacterController controller;
	
    // Use this for initialization
	void Start () {
		cube=GameObject.Find("Capsule");
		controller=GetComponent<CharacterController>();
	}
	
	public float rayCastLength=5.0f;
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime);
		if(Input.GetKeyDown(KeyCode.W))
		{
			transform.Rotate(0, 0, 0);
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			transform.Rotate(0, 180, 0);
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			transform.Rotate(0, 90, 0);
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			transform.Rotate(0, -90, 0);
		}

		if(Input.GetMouseButtonDown(0))
		{
			transform.Translate(Vector3.down*-0.45f,Space.World);
			controller.height=0.9f;
			transform.FindChild("Man").gameObject.animation.Play("jump_pose");
		}

		if(Input.GetMouseButtonUp(0))
		{
			transform.Translate(Vector3.up*0.45f,Space.World);
			controller.height=1.8f;
			transform.FindChild("Man").gameObject.animation.Play("run");
		}

		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward,out hit,rayCastLength))
		{
			if(hit.collider.gameObject.tag=="Wall")
			{
				speed=Vector3.zero;
			}
			if(hit.collider.gameObject.tag=="Fires")
			{
				Debug.Log("Fires");
			}
			//Debug.Log(hit.collider.gameObject);
		}
		else
		{
			speed=new Vector3(0,0,8.0f);
		}
	}
	
	void OnJump()
	{
		transform.FindChild("Man").gameObject.animation.Play("jump_pose");
		//controller.height=1;
	}
	
	void OnFall()
	{
		Debug.Log("Fall");
	}
	
	void OnLand()
	{
		//controller.height=2;
		transform.FindChild("Man").gameObject.animation.Play("run");

	}
	
	/*
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Debug.Log(hit.gameObject.tag);
		if(hit.gameObject.tag=="Wall")
		{
			Debug.Log(cube.name);
		}
		//Debug.Log(cube.transform.position);
	}
	*/
}
