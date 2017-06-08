using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera camera;
	public int scrollSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//perhaps increase scroll speed based on current cameraheight (y)
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - scrollSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
			camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + scrollSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			camera.transform.position = new Vector3 (camera.transform.position.x + scrollSpeed * Time.deltaTime, camera.transform.position.y, camera.transform.position.z);
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			camera.transform.position = new Vector3 (camera.transform.position.x - scrollSpeed * Time.deltaTime, camera.transform.position.y, camera.transform.position.z);
		}
		//Zoom in
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
			if (camera.transform.position.y > 5) {
				camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y - 1, camera.transform.position.z);
			}
		} 
		//Zoom out
		if(Input.GetAxis ("Mouse ScrollWheel") < 0f) {
			if (camera.transform.position.y < 20) {
				camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y + 1, camera.transform.position.z);
			}
		}
	}
}
