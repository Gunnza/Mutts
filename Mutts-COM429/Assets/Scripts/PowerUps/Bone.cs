using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour {
	
	public int scoreValue = 10;
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
