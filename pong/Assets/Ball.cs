using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    private int score = 0; //スコア計算用変数
    Text text; //Text用変数

    public float speed = 30;

    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        text = GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D col) {
	    // Note: 'col' holds the collision information. If the
	    // Ball collided with a racket, then:
	    //   col.gameObject is the racket
	    //   col.transform.position is the racket's position
	    //   col.collider is the racket's collider
	    
	    // Hit the left Racket?
	    if (col.gameObject.name == "RacketLeft") {
	        // Calculate hit Factor
	        float y = hitFactor(transform.position,
	                            col.transform.position,
	                            col.collider.bounds.size.y);

	        // Calculate direction, make length=1 via .normalized
	        Vector2 dir = new Vector2(1, y).normalized;

	        // Set Velocity with dir * speed
	        GetComponent<Rigidbody2D>().velocity = dir * speed;
	    }

	    // Hit the right Racket?
	    if (col.gameObject.name == "RacketRight") {
	        // Calculate hit Factor
	        float y = hitFactor(transform.position,
	                            col.transform.position,
	                            col.collider.bounds.size.y);

	        // Calculate direction, make length=1 via .normalized
	        Vector2 dir = new Vector2(-1, y).normalized;
	        
	        // Set Velocity with dir * speed
	        GetComponent<Rigidbody2D>().velocity = dir * speed;
	    }

	    if (col.gameObject.name == "WallLeft") {
	    	// Update();
	    	GetComponent<Detonator>().Explode();
	    	GetComponent<Transform>().transform.position = new Vector3(3, 0, 0);
	    	GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	    }
	    if (col.gameObject.name == "WallRight") {
	    	GetComponent<Detonator>().Explode();
	    	GetComponent<Transform>().transform.position = new Vector3(3, 0, 0);
	    	GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
	    }
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketHeight) {
	    // ascii art:
	    // ||  1 <- at the top of the racket
	    // ||
	    // ||  0 <- at the middle of the racket
	    // ||
	    // || -1 <- at the bottom of the racket
	    return (ballPos.y - racketPos.y) / racketHeight;
	}

	// void Awake (){
	// 	text = GetComponent <Text> ();
	// 	score = 0;
	// }

	void Update (){
		text.text = "Score: " + score;
	}

}