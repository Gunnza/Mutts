using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	// Using enums to quickly associate readable menu states
	enum  MenuState
	{
		Main,
		LoadLevel,
		Options,
		Credits,
	};
	
	//Used to set the current menu state
	private MenuState currentState = MenuState.Main;
	
	// Options for muting he sound
	private bool toggleMute = false;
	// Options for changing the sound level
	
	//String for the credits menu
	string creditText = "Credits\n Christopher McGovern.";
	//Used to handle the scrolling location of the text
	Vector2 scrollVector = Vector2.zero;
	
	public Texture2D btnCredits;
	public Texture2D btnExit;
	public Texture2D btnLoadLevel;
	public Texture2D btnOptions;
	public Texture2D btnBack;
	public Texture2D backTexture;
	public Texture2D backTexture2;
	
	public GUIStyle customButton;
	public GUIStyle slider;
	
	public GUISkin header;
	public GUISkin Slide;
	public GUISkin level;
	
	private float buttonWidth = (Screen.width/100)*25;
	private float buttonHeight = (Screen.height/100)*10;
	
	// USed to specify the number of levels in the game
	public int numberOfLevels;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Renders our Main GUI
	/// </summary>
	private void RenderMain()
	{
		//DrawBackground
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backTexture);
		
		float xPos = (Screen.width/100)*1;
		float yPos = (Screen.height/100)*80;
		
		if (GUI.Button (new Rect(xPos, yPos, buttonWidth, buttonHeight), btnLoadLevel, customButton))
		{
			// Change the Current State
			currentState = MenuState.LoadLevel;
		}
		
		xPos = xPos + buttonWidth;
		
		if (GUI.Button (new Rect(xPos, yPos, buttonWidth, buttonHeight), btnOptions, customButton))
		{
			// Change the Current State
			currentState = MenuState.Options;
		}
		
		xPos = xPos + buttonWidth;
		
		if (GUI.Button (new Rect(xPos, yPos, buttonWidth, buttonHeight), btnCredits, customButton))
		{
			// Change the Current State
			currentState = MenuState.Credits;
		}
		
		xPos = xPos + buttonWidth;
		
		// Quit the game when Exit is pressed
		if (GUI.Button (new Rect(xPos, yPos, buttonWidth, buttonHeight), btnExit, customButton))
		{
			// Change the current state
			Application.Quit ();
		}
	}
	
	// OnGUI will render any gui elements
	void OnGUI()
	{
		// Use switch instead of "if/else if" statements as a performance consideration
		switch(currentState)
		{
		case MenuState.Main:
			RenderMain ();
			break;
			
		case MenuState.LoadLevel:
			RenderLoadLevel();
			break;
			
		case MenuState.Options:
			RenderOptions ();
			break;
			
		case MenuState.Credits:
			RenderCredits();
			break;
		}
	}
		
	/// <summary>
	/// Renders our Load Level GUI
	/// </summary>
	private void RenderLoadLevel()
	{
		
		//DrawBackground
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backTexture2);
		
		GUI.skin = header;
		header.box.fontSize = (Screen.height/100)*5;
		GUI.Box (new Rect((Screen.width/2)-(((Screen.width/100)*80)/2), (Screen.height/2)-(((Screen.height/100)*80)/2), (Screen.width/100)*80, (Screen.height/100)*80), "Select a Level");
		
		GUI.skin = level;
		
		float xPos = (Screen.width/100)*15;
		float space = 30;
		
		float yPos = (Screen.height/100)*20;
		float row = 5;
		
		//int i = 1;
		
		for (int i = 1; i <= numberOfLevels; i++)
		{
			if (GUI.Button (new Rect(xPos, yPos, (Screen.width/100)*10, (Screen.height/100)*10), "Level " + i.ToString()))
			{
				// Call to load the level using its name
				Application.LoadLevel ("Level" + i.ToString());
			}
			
			if (i == row)
			{
				space = 15;
				yPos = yPos + (Screen.height/100)*(space);
				
				row = row + 5;
			}
			
			xPos = (Screen.width/100)*space;
			space = space + 15;
		}
		
		//We don't want to be stuck in the load level menu so allow us to return
		if (GUI.Button (new Rect((Screen.width/2)-(buttonWidth/2), (Screen.height/2)+ (Screen.height/10)*2 + (buttonHeight/2), buttonWidth, buttonHeight), btnBack, customButton))
		{
			// Change the current state
			currentState = MenuState.Main;
		}
	}
	
	/// <summary>
	/// Renders our Opions GUI
	/// </summary>
	private void RenderOptions()
	{
		
		//DrawBackground
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backTexture2);
		
		GUI.skin = header;
		header.box.fontSize = (Screen.height/100)*5;
		GUI.Box (new Rect((Screen.width/2)-(((Screen.width/100)*70)/2), (Screen.height/2)-(((Screen.height/100)*70)/2), (Screen.width/100)*70, (Screen.height/100)*70), "Options");		
		
		header.toggle.fontSize = (Screen.height/100)*4;
		// Toggle box for muting the sound
		toggleMute = GUI.Toggle(new Rect((Screen.width/2)-60, (Screen.height/2)-((Screen.height/100)*15), 120, (Screen.height/100)*5), toggleMute, "Mute");
		if (toggleMute == true)
		{
			AudioListener.volume = 0;
		}
		
		header.label.fontSize = (Screen.height/100)*4;
		// Label for he sound level
		GUI.Label (new Rect((Screen.width/2)-60, (Screen.height/10)*5, 120, (Screen.height/100)*5), "Music Level");
		
		// Slider for adjusting the sound level
		GUI.skin = Slide;
		AudioListener.volume = GUI.HorizontalSlider(new Rect((Screen.width/2)-(((Screen.width/100)*65)/2), (Screen.height/10)*5 + (Screen.height/100)*10, (Screen.width/100)*65, 20), AudioListener.volume, 0, 1f);
		
		// We don't want to be stuck in the load level menu so allow us to return
		if (GUI.Button (new Rect((Screen.width/2)-(buttonWidth/2), (Screen.height/2)+ (Screen.height/10)*2 + (buttonHeight/3), buttonWidth, buttonHeight), btnBack, customButton))
		{
			// Change the current state
			currentState = MenuState.Main;
		}
	}
	
	/// <summary>
	/// Renders our Credits GUI
	/// </summary>
	private void RenderCredits()
	{
		
		//DrawBackground
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backTexture2);
		
		GUI.skin = header;
		header.box.fontSize = (Screen.height/100)*5;
		GUI.Box (new Rect((Screen.width/2)-(((Screen.width/100)*70)/2), (Screen.height/2)-(((Screen.height/100)*70)/2), (Screen.width/100)*70, (Screen.height/100)*70), "Credits");
		
		// Start the scroll view and store the scrolling vector if moved
		scrollVector = GUI.BeginScrollView (new Rect((Screen.width/2)-(((Screen.width/100)*60)/2), (Screen.height/2)-(((Screen.height/100)*50)/2) - (((Screen.height/100)*50)/15), (Screen.width/100)*60, (Screen.height/100)*50), scrollVector, new Rect(0, 0, 400, 400));
			
		// Add the text to the scroll view
		creditText = GUI.TextArea (new Rect(0, 0, (Screen.width/100)*60, (Screen.height/100)*50), creditText);
		
		// End the scroll view
		GUI.EndScrollView();
		
		// We don't want to be stuck in the load level menu so allow us to return
		if (GUI.Button (new Rect((Screen.width/2)-(buttonWidth/2), (Screen.height/2)+ (Screen.height/10)*2 + (buttonHeight/3), buttonWidth, buttonHeight), btnBack, customButton))
		{
			// Change the current state
			currentState = MenuState.Main;
		}
	}
}