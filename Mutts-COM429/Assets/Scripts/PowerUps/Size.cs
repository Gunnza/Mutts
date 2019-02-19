using UnityEngine;
using System.Collections;

public class Size : MonoBehaviour {

	public int scoreValue = 25;
	private GameObject scoreManager;
	
	void Start()
	{
		scoreManager = GameObject.Find("ScoreManager");
	}
	
	void OnTriggerEnter()
	{
		scoreManager.SendMessage("AddScore", scoreValue);
		GameObject.Destroy (gameObject);	
	}
}
