using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    int hp;
	
	
	void Awake() {
		hp = getHp();
	}
	
	
	public abstract int getHp();
	
	protected virtual void kill() {
		Destroy(gameObject);
	}
	
	void dealDamage(int dmg) {
		hp = Mathf.Max(0, hp-dmg);
		
		if (hp == 0) { 
			Score.score += getCoins();
            SoundManager.playSound("mobDestroyed");
			kill();
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherObj) {
		if (otherObj.transform.tag == "Paper") {
			Paper paper = otherObj.GetComponent<Paper>();
			
			if (paper.fromPlayer == true) {
				dealDamage(paper.getDealtDmg());
				Destroy(otherObj.gameObject);
			}
		}
	}
	
	public abstract int getCoins();
	
	
	
	
}
