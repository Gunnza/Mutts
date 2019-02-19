using UnityEngine;
using System.Collections;

public class Invincable : MonoBehaviour {
	

	int blinkTime = 3;            //How long the sphere will blink


	// Update is called once per frame
	void Update () {
	
	}

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
	
}