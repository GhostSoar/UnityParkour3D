using UnityEngine;
using System.Collections;

public class DiceMotor : MonoBehaviour {
	public Transform explosionPrefab;
	
	private float lifeTime=3.0f;
	
	void Awake()
	{}
	
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Time.time>(creationTime+lifeTime))
		{
			Destroy(gameObject);
			Instantiate(explosionPrefab,transform.position,Quaternion.identity);
		}
		*/
	}
	
	void OnCollisionEnter()
	{
		Destroy(gameObject);
		Instantiate(explosionPrefab,transform.position,Quaternion.identity);
	}
}
