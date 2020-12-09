using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	char type;
	protected float speed = 2f;
	
	float timeLeft = 5.0f;
	
	public GameObject destroyPoint;
	
	protected virtual void kill()
	{
		Destroy(gameObject);
	}

	void Update() {
		transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y < destroyPoint.transform.position.y)
        {
           kill();
        }
		
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) kill();
    }

	void OnTriggerEnter2D(Collider2D otherObj)
	{
		if (otherObj.transform.tag == "Player")
		{
			Player player = otherObj.GetComponent<Player>();
			kill(); //destroy object
			//gain benefits
			//shield example
			player.setShieldHit(0); //reset hit count
			player.setShield(true);
			
		}


	}
}