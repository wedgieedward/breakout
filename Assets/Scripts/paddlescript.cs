using UnityEngine;
using System.Collections;

public class paddlescript : MonoBehaviour {

	public int speed;
	public float rightBoundry;
	public float leftBoundry;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		float horizonal = Input.GetAxis ("Horizontal");
		float x_val = transform.position.x + (horizonal * speed  * Time.deltaTime);

		// make sure we do not leave the play area
		x_val = Mathf.Max (x_val, leftBoundry);
		x_val = Mathf.Min (x_val, rightBoundry);

		// set the paddle position
		transform.position = new Vector2 (x_val, transform.position.y);

	}
}
