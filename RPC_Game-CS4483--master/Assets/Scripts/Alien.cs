using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Mob, IPoolObject
{
    protected float speed = 2f;
	protected int alienHp = 60;
	protected int coins = 2;

    public GameObject destroyPoint;
    Transform player;
    public float rotSpeed = 90f;
    public float maxSpeed = 5f;
    private Rigidbody2D myRigidbody;
   
    void Start()
    {
        destroyPoint = GameObject.Find("destroyPoint");
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void onObjectSpawn()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

	void Update() {
        if (player == null)
        {
            // find player ship
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
            return;

        //transform.Translate(Vector2.down * Time.deltaTime * speed);

        // rotate towards player
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

        // move forward
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        if (transform.position.y < destroyPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
	
	public override int getHp() {
		return alienHp;
	}
	
	public override int getCoins() {
		return coins;
	}
	
	public void setSpeed(float speed) {
		this.speed = speed;
	}

	
}
