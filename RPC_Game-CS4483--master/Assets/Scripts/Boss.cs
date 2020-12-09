using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Mob
{
	protected int bossHp = 210;
	protected int bossCoins = 10;
	
	[SerializeField]
	Transform paperSpawnPos;
	
	[SerializeField]
	Paper paperPrefab;
	
    Color colour;
	Transform player;
	
	
	public GameObject shield;
	public delegate void bossDead();
	public static event bossDead OnbossDead; 
	
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		colour = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
		InvokeRepeating("Shoot", 2f, 2f);
    }

   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * 5f);
			//instantiate powerups
    }
	
	void Shoot() {
		Vector2 dir = (player.position - transform.position).normalized;
		Paper paper = Instantiate (paperPrefab, paperSpawnPos.position, Quaternion.identity) as Paper;
		paper.Go(3f, colour, 0.4f, dir, false, 0f);
	}
	
	public override int getHp() {
		return bossHp;
	}
	
	public override int getCoins() {
		return bossCoins;
	}
	
	protected override void kill() {
		if (OnbossDead != null) OnbossDead();
		int ranNum = Random.Range(1,3);
		if (ranNum == 1) {
			Instantiate(shield, new Vector3(0,0,0), Quaternion.identity);
		}

        SoundManager.playSound("mobDestroyed");
		base.kill();
	}
}
