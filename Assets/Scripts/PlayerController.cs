using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;
	public GUIText countText;
	public float JumpSpeed = 100.0f;
	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();
		print (Vector3.up * JumpSpeed);
	}
	public void Jump() { 
				rigidbody.AddForce (Vector3.up * JumpSpeed);	
				print (Vector3.up * JumpSpeed);

		}
	
	// Update is called once per frame
	void FixedUpdate () {

				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");
				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				rigidbody.AddForce (movement * speed * Time.deltaTime);
			if (Input.GetButtonDown ("Jump")) 
			{
				Jump ();
			}

	}



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText ();
		}

	} 
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}
