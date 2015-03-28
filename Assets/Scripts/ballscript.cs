using UnityEngine;
using System.Collections;

public class ballscript : MonoBehaviour {

	public int ballSpeedV;
	public int ballSpeedH;
	public float deathY;
	private int down = -1;
	private int right = 1;
	private Rigidbody2D ball;
	private bool alive;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody2D> ();
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (transform.position.y <= deathY) {
			if(alive){
				Debug.Log("Ball Is below death line, setting alive to false");
				ball.velocity = new Vector2(0.0f, 0.0f);
			}
			alive = false;
		}
		if (alive == true) {
			float x_val = ballSpeedH * right;
			float y_val = ballSpeedV * down;
			Vector2 velocity = new Vector2 (x_val, y_val);
			ball.velocity = velocity;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "boundry"){
			Debug.Log("Ball collision with boundry");
			right = right * -1;
		}
		if (collision.gameObject.tag == "ceiling"){
			Debug.Log("Ball collision with ceiling");
			down = down * -1;
		}
		if (collision.gameObject.name == "paddle"){
			Debug.Log("Ball collision with paddle");
			down = down * -1;
		}
		if (collision.gameObject.tag == "brick") {
			Debug.Log ("Ball collsion with brick");
			down = down * -1;
			collision.gameObject.SetActive (false);
		}
	}
}
