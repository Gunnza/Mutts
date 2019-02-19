using UnityEngine;
using System.Collections;

public class Fast : MonoBehaviour {
	
	//Public
	public int scoreValue = 25;
	//Local
	//float powerupSpeed = 10.0f;
	//Private
	private GameObject scoreManager;
	private GameObject powerup;
	
	
	void Start()
	{
		scoreManager = GameObject.Find("ScoreManager");
		powerup = GameObject.Find("dog");
	}
	
	void OnTriggerEnter()
	{
		scoreManager.SendMessage("AddScore", scoreValue);
		powerup.SendMessage("SpeedPowerup");
		GameObject.Destroy (gameObject);	
	}
}