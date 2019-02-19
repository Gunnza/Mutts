using UnityEngine;
using System.Collections;

public class ObstacleSmall : MonoBehaviour {
	
	private GameObject dog;
	
	// Use this for initialization
	void Start ()
	{
		dog = GameObject.Find("dog");
	}
	
	// Update is called once per frame
	void Update ()
	{}
	
	void OnCollisionEnter()
	{
		dog.SendMessage("Fail");
	}
}
