using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	// mouse look variables
	public float sensitivityX = 0.0001F;
	public float sensitivityY = 0.0001F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	float rotationX = 0F;
	float rotationZ = 0F;


	public float moveSpeed = 5;
	public float rotateSpeed = 1;



	// Use this for initialization
	void Start() {
		// TODO

	}



	// late update
	void LateUpdate() {
		this.applyKeyboard();
		this.applyMouse();
	}



	// checking and applying the keyboard input
	private void applyKeyboard() {
		if (Input.GetKey("w")) { // w: forward
			this.transform.localPosition += this.transform.forward * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("s")) { // s: back
			this.transform.localPosition -= this.transform.forward * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("a")) { // a: left
			this.transform.localPosition -= this.transform.right * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("d")) { // d: right
			this.transform.localPosition += this.transform.right * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("q")) { // q: rotate left
			this.transform.RotateAround(this.transform.forward, 0.05F);

		}
		if (Input.GetKey("e")) { // e: rotate right
			this.transform.RotateAround(this.transform.forward, -0.05F);
		}
	}







	// detecing and applying mouse input
	private void applyMouse() {
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
	
		this.transform.Rotate(Vector3.up, mouseX * sensitivityX);
		this.transform.Rotate(Vector3.right, -mouseY * sensitivityY);
	}




}
