using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	// mouse look variables
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5;
	public float sensitivityY = 5;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;




	public float moveSpeed = 5;




	// Use this for initialization
	void Start() {
		
	}



	// late update
	void LateUpdate() {
		this.applyKeyboard();

		if (!Input.mousePresent) { //if no mouse, do nothing
			return;
		} else {
			this.applyMouse();
		}
	}



	// checking and applying the keyboard input
	private void applyKeyboard() {
		if (Input.GetKey("w")) { // w: forward
			
			this.transform.localPosition += transform.forward * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("s")) { // s: back
			this.transform.localPosition -= transform.forward * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("a")) { // a: left
			this.transform.localPosition -= transform.right * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("d")) { // d: right
			this.transform.localPosition += transform.right * Time.smoothDeltaTime * moveSpeed;
		}
		if (Input.GetKey("q")) { // q: rotate left
			this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 1);
		}
		if (Input.GetKey("e")) { // e: rotate right
			this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - 1);
		}
	}




	// detecing and applying mouse input
	private void applyMouse() {
		if (axes == RotationAxes.MouseXAndY) { // both horizontal and vertical
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			this.transform.localEulerAngles = new Vector3(-rotationY, rotationX, transform.localEulerAngles.z);
		} else if (axes == RotationAxes.MouseX) { // if horizontal
			this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Input.GetAxis("Mouse X") * sensitivityX, transform.localEulerAngles.z);
		} else if (axes == RotationAxes.MouseY) { // if vertical
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			this.transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
	}



}
