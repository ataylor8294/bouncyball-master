using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playercontrols : MonoBehaviour {
	public float speed; 
	private int count;
	public Text countText;
	public Text wintext;
	private Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 Movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (Movement *speed);
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick up"))
			other.gameObject.SetActive(false);
		count = count + 1;
		setCountText ();
	}
	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8)
			wintext.text = "YOU WIN";
	}
}
	
