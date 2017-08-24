using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	public float minutesInDay = 1.0f;

	float timer;
	float percentageOfDay;
	float turnSpeed;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkTime ();
		UpdateLights ();

		turnSpeed = 360.0f / (minutesInDay * 60.0f) * Time.deltaTime;
		transform.RotateAround (transform.position, transform.right, turnSpeed);
	}

	void UpdateLights() {
		Light l = this.GetComponent<Light> ();

		if (this.gameObject.name == "SunLight") {
			if (isNight ()) {
				if (l.intensity > 0.0f) {
					l.intensity -= 0.05f;
				}
			} else {
				if (l.intensity < 1.0f) {
					l.intensity += 0.05f;
				}
			}
		} else {
			l.intensity = 1.0f;
		}
		//Debug.Log (l.intensity);
	}

	bool isNight() {
		bool c = false;
		if (percentageOfDay > 0.5f) {
			c = true;
		}

		return c;
	}

	void checkTime(){
		timer += Time.deltaTime;
		percentageOfDay = timer / (minutesInDay * 60.0f);
		if (timer > (minutesInDay * 60.0f)) {
			timer = 0.0f;
		}
	}
}
