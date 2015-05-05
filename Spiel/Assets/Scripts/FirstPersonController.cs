using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	public float jumpSpeed = 5;

	float verticalRotation = 0;

	float verticalVelocity = 0;
	CharacterController characterController;

	// Use this for initialization
	void Start () {

	
		characterController = GetComponent<CharacterController>();	


	}
	
	// Update is called once per frame
	void Update () {
		 
		//Rotation

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);


		//Movement

	
		float fowardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		//Gravity
		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		//Jumping

		if (characterController.isGrounded && Input.GetButton ("Jump")) {
		
			verticalVelocity = jumpSpeed;
		}


		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity , fowardSpeed);

		speed = transform.rotation * speed; 


		characterController.Move (speed * Time.deltaTime);
	
	}
}
