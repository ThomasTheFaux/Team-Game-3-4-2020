using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Purpose... 
    //  + Player Camera Looking
    //  + Taking in mouse as input
    //
    //Script By Thomas Joyce

public class PlayerCameraLook : MonoBehaviour {
	
	float mouseSens = .7f;																				//mouse sensitivity
	float mouseSmoo = 2f;																				//mouse smoothing
	float minY = -70;																					//min angle for camera to look down
	float maxY = 80;																					//max angle for camera to look up
	Vector2 mouseLook;																					//vector for looking with the mouse
	Vector2 smoothVect;																					//vector that smooths mouse movements
	GameObject player;																					//player gameobject

	void Start(){
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		player = this.transform.parent.gameObject;														//assigns player to the parent gameobject				
	}
	
	void Update(){
		playerLook();
	}

	void playerLook(){
		var mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));			//records inputs from cursor

		mouseDir = Vector2.Scale(mouseDir, new Vector2(mouseSens * mouseSmoo, mouseSens * mouseSmoo));	//calculates direction of mouse
		smoothVect.x = Mathf.Lerp(smoothVect.x, mouseDir.x, .75f/ mouseSmoo);							//smooths x axis of smoothVect (added slightly slow multiplier)
		smoothVect.y = Mathf.Lerp(smoothVect.y, mouseDir.y, 1f/ mouseSmoo);								//smooths y axis of smoothVect
		mouseLook += smoothVect;																		//sets the mouse looking values
		mouseLook.y = Mathf.Clamp (mouseLook.y, minY, maxY); 

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);					//rotates camera vertically			
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);		//rotates player horizonally
	}
}
