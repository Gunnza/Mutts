using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	//Movement
	public float startSpeed = 10.0f;
	public float currentSpeed;
	public int lives = 3;
	public float Invincablity = 2.0f;
	//Jumping
	public Vector3 jumpVelocity;
	private bool touchingPlatform;
	//Powerup
	public int doubleSpeedTime = 10;
	private float countdownSeconds;
	//Speed
	private bool doubleSpeed = false;
	//Size
	private bool doubleSize = false;
	//Score
	private GameObject scoreManager;
	
	//Victory/Fail Screen
	public Texture2D victory;
	public Texture2D fail;
	private bool isVictory = false;
	private bool isFail = false;
	
	void Start()
	{
		currentSpeed = startSpeed;
		countdownSeconds = (float) doubleSpeedTime;
		scoreManager = GameObject.Find("ScoreManager");
		//scoreManager.SendMessage("AddScore", 10);
	}
	
	void Update ()
	{
		if(doubleSpeed)
		{
			countDown();
		}
		transform.Translate(currentSpeed * Time.deltaTime, 0f, 0f);
		
		//while(ObstacleSmall.collision != true)
		//{
		//	distanceTraveled = transform.localPosition.x;
			
			//Adds distance traveled to score
			//distance = Mathf.FloorToInt(distanceTraveled);
			//distance = distance / 100;	//Edit to change how much gets added
			//ScoreManager.score += distance;
		//}
		
		if((Input.GetButtonDown("Jump")) && (touchingPlatform))
		{
			rigidbody.AddForce (jumpVelocity, ForceMode.VelocityChange);
		}
	}
	
	void OnCollisionEnter()
	{
		touchingPlatform = true;
	}
	
	void OnCollisionExit()
	{
		touchingPlatform = false;
	}
	
	void SpeedPowerup()
	{
		currentSpeed *= 2; 
		doubleSpeed = true;
	}
	
	void SizePowerup()
	{
		
	}
	
	void countDown()
	{
		countdownSeconds -= Time.deltaTime;
		if(countdownSeconds<=0)
		{
			currentSpeed = startSpeed;
			doubleSpeed =false;
			countdownSeconds = doubleSpeedTime;
		}
	}
	
	void Victory()
	{
		isVictory = true;
		currentSpeed = 0.0f;
	}
	
	void Fail()
	{
		lives--;
		Invincablity-=Time.deltaTime;
		if(Invincablity<=0)
			
		if (lives <=0)
			isFail = true;
		if (isFail = true)
				currentSpeed = 0.0f;
	}
	
	int blinkTime = 3;            //How long the sphere will blink
 
	void  blink() 
	{
    yield return new WaitForSeconds(1); // The initial delay that you passed to InvokeRepeating
    	while (blinkTime > 0)
		    {
		        blinkTime--;
		        yield return new WaitForSeconds(0.5);
		        renderer.enabled = false;
		        yield return new WaitForSeconds(0.5);
		        renderer.enabled = true;
		    }
		    yield return new WaitForSeconds(1); // wait another sec.
		
	}
			
void OnGUI()
	{
		float width = (Screen.width/100)*60;
		float height = (Screen.height/100)*20;
		
		if(isVictory)
		{
			GUI.DrawTexture(new Rect ((Screen.width/2)-(width/2), (Screen.height/2)-(height/2), width, height), victory);
		}
		
		if(isFail)
		{
			GUI.DrawTexture(new Rect ((Screen.width/2)-(width/2), (Screen.height/2)-(height/2), width, height), fail);
		}
		
	}
}
