using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	//public Text winText;
	public bool isGrounded = true;
	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		//winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) 
		{
			rb.velocity = new Vector3(0, 4, 0);
			isGrounded = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.CompareTag ("pickup")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText()
	{
		countText.text = "P1 Score: " + count.ToString ();
		//if (count >= 16) 
		//{
		//	winText.text = "Player 1 Wins!";
		//}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "ground")
		{
			isGrounded = true;
		}

		if (col.gameObject.CompareTag ("wall"))
		{
			if( count > 0)
			{
				count = count - 1;
				SetCountText ();
			}
		}

		if (col.gameObject.CompareTag ("player2")) 
		{
			//COLLISION ON ALTITUDE CHECK
		}
	}
	public void resetButton()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
