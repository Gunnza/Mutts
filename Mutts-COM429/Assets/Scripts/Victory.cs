using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {
	
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
		dog.SendMessage("Victory");
		
		if (audio.isPlaying)
			audio.volume = 0;
	}
}
