using UnityEngine;
using System.Collections;
public class FirstPersonController : MonoBehaviour {
	
	public float moveSpeed = 10.0f;
	public float mouseSensitivety = 2.0f;
	
	// Update is called once per frame
	void Update () {
		
		float moveVertical = Input.GetAxis ("Vertical")*moveSpeed;
		float moveHorizontal = Input.GetAxis ("Horizontal")*moveSpeed;
		//Rotation
		float rotLeftRight = Input.GetAxis ("Mouse X")*mouseSensitivety;
		
		transform.Rotate (0,rotLeftRight,0);
		
		Vector3 speed = new Vector3 (moveHorizontal,0,moveVertical);
		speed = transform.rotation * speed; 
		
		CharacterController cc = GetComponent<CharacterController> ();
		cc.SimpleMove (speed);
	}
}
