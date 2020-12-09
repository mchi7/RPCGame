using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Mob
{
    protected float speed = 2f;
	protected int alienHp = 110;
	protected int coins = 2; 
	
	void Update() {
		transform.Translate(Vector2.down * Time.deltaTime * speed);
	}
	
	public override int getHp() {
		return alienHp;
	}
	
	public override int getCoins() {
		return coins;
	}

	
}
