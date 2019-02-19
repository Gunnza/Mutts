using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public ScoreManager scoremanager;
	int score = 0;
	
	//BUTTON CODE
	public Texture2D btnBack;
	public GUIStyle customButton;
	private float buttonWidth = (Screen.width/100)*25;
	private float buttonHeight = (Screen.height/100)*10;
	//BUTTON CODE
	
	void OnGUI()
	{
		GUILayout.Label ("Score: " + score.ToString("#"));
		GUILayout.Label ("Lives: " + lives.ToString("#"));
		
		if (GUI.Button (new Rect(Screen.width-buttonWidth, Screen.height-buttonHeight, buttonWidth, buttonHeight), btnBack, customButton))
		{
			// Change the current state
			Application.LoadLevel ("MainMenu");
		}
	}	
	
	public void AddScore(int scoreAmount)
	{
		score += scoreAmount;
	}
}
