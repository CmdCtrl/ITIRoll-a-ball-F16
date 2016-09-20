using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject ground;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - ground.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = ground.transform.position + offset;
	}
}
