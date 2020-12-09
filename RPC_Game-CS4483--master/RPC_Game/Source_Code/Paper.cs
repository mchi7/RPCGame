using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{	
	int paperDamage = 30;
	
	public bool fromPlayer = false;
	Vector2 paperDir;
	
	float paperSpeed;
	Color colour;
	
    // Start is called before the first frame update
    public void Go(float speed, Color thisColour, float scale, Vector2 dir, bool player)
    {
		paperSpeed = speed;
		colour = thisColour;
		GetComponent<SpriteRenderer>().color = colour;
    	
		transform.localScale *= scale;
		paperDir = dir;
		fromPlayer = player;
		
	}
	
	public int getDealtDmg() {
		return paperDamage;
	}
	
    // Update is called once per frame
    void Update()
    {
        transform.Translate (paperDir * Time.deltaTime * paperSpeed);
		
		float yPos = GameManager.TR.y;
		if (transform.position.y >= yPos) Destroy(gameObject);
	}
}
