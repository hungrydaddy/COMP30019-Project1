using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	// mouse look variables
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	float rotationX = 0F;


	public float moveSpeed = 5;


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
			this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z + 1);
		}
		if (Input.GetKey("e")) { // e: rotate right
			this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z - 1);
		}
	}







	// detecing and applying mouse input
	private void applyMouse() {

		// getting input values
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		// calculating global euler angles
		float globalRotationX = rotationX * Mathf.Cos(Mathf.Deg2Rad * this.transform.localEulerAngles.z) - rotationY * Mathf.Sin(Mathf.Deg2Rad * this.transform.localEulerAngles.z);
		float globalRotationY = rotationY * Mathf.Cos(Mathf.Deg2Rad * this.transform.localEulerAngles.z) + rotationX * Mathf.Sin(Mathf.Deg2Rad * this.transform.localEulerAngles.z);

		// applying to the local euler angles
		this.transform.localEulerAngles = new Vector3(-globalRotationY, globalRotationX, this.transform.localEulerAngles.z);
	}



}
