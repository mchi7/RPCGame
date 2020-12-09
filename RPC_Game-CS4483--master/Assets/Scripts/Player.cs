using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{	[SerializeField]
	Transform spawnPos;
	
	[SerializeField]
	Paper paperPrefab;
	
	protected float halfTri;
    protected float halfTri2;
    protected float nextFire = 0.0f;
	
	
	int shieldHit = 0;
	public bool hasShield = false;
	
    // Start is called before the first frame update
    void Start()
    {
        halfTri = transform.localScale.x/2;
        halfTri2 = (transform.localScale.y / 2);

	}


    void paperMaker() {

		Paper PaperInst = Instantiate(paperPrefab);
		
		PaperInst.Go(2f, new Color(1f,1f,1f,1f), 0.25f, Vector2.up, true,0.5f);
		PaperInst.transform.position = spawnPos.position;
        SoundManager.playSound("playerShoot");
	}


    // upgraded version of the default weapon
    void paperMaker2()
    {

        Paper PaperInst = Instantiate(paperPrefab);
        Paper PaperInst2 = Instantiate(paperPrefab, spawnPos.position, Quaternion.LookRotation(Vector3.forward, new Vector2(-1, 3)));
        Paper PaperInst3 = Instantiate(paperPrefab, spawnPos.position, Quaternion.LookRotation(Vector3.forward, new Vector2(1, 3)));
        PaperInst.Go(2f, new Color(1f, 1f, 1f, 1f), 0.25f, Vector2.up, true, 0.5f);
        PaperInst2.Go(2f, new Color(1f, 1f, 1f, 1f), 0.25f, Vector2.up, true, 0.5f);
        PaperInst3.Go(2f, new Color(1f, 1f, 1f, 1f), 0.25f, Vector2.up, true, 0.5f);
        PaperInst.transform.position = spawnPos.position;
    }
 




    // Update is called once per frame
    void Update()
    {
       
		float playerSpeed = 7f;
		
		
 
		float fullMove = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
		
		if (transform.position.x + halfTri >= GameManager.TR.x) {
			if (fullMove > 0) fullMove = 0;
		}else{
			if (transform.position.x - halfTri <= GameManager.BL.x) {
				if (fullMove < 0) fullMove = 0;
			}
		}
		
		transform.Translate (fullMove * Vector2.right);
        
        float fowardMove=Input.GetAxis("Vertical") *Time.deltaTime *playerSpeed;
        Vector3 pos = transform.position;

        if (transform.position.y + halfTri2 >= GameManager.TR.y)
        {
            if (fowardMove > 0) fowardMove = 0;
        }
        else
        {
            if (transform.position.y - halfTri <= GameManager.BL.y)
            {
                if (fowardMove < 0) fowardMove = 0;
            }
        }

        pos.y += fowardMove;

        transform.position = pos;


        //Controlled weapon firing
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (Ammo.ammo > 0)
            {
                nextFire = Time.time + Paper.firingRate;
                paperMaker();
                Ammo.ammo--;
            }

            if (Ammo.ammo == 0)
            {
                StartCoroutine(reload());
            }
        }

    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(2);
        Ammo.ammo = 20;
    }
	
	void OnTriggerEnter2D(Collider2D otherObj) { //collision detection
		if (otherObj.transform.tag == "Mob") {

			
			if (shieldHit > 0 || hasShield == false) {
				Destroy(gameObject);
				
				SoundManager.playSound("explosion");
				Destroy(gameObject);
				Ammo.ammo = 20;
				SceneManager.LoadScene("GameOver");
			}else{
				shieldHit ++;
			}

            
		

		}else if (otherObj.transform.tag == "Paper") { //paper/projectile
			Paper projectile = otherObj.GetComponent<Paper>(); //get the paper object
			
			if (projectile.fromPlayer == false) {

				if (shieldHit > 0) {
					Destroy(gameObject);
					SoundManager.playSound("explosion");
					Destroy(gameObject);
					Ammo.ammo = 20;
					SceneManager.LoadScene("GameOver");
				}else{
					shieldHit ++;
				}

                

			}
		}
	}
	
	public void setShieldHit(int s) {
		shieldHit = s;
	}
	
	public void setShield(bool shield) {
		hasShield = shield;
	}
	
}

