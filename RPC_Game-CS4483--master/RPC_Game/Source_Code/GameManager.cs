using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Player player;
	public static Vector2 BL;
	public static Vector2 TR;
	public GameObject wave;
	
	public Alien alien;
	
	
   // Start is called before the first frame update
    void Start()
    {
		BL = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0));
		TR = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));
		
		Instantiate(player);
		
		repeatSpawn();
	}

    // Update is called once per frame
	
	void spawnAliens() {
		
		GameObject aliens = Instantiate(wave, Vector2.zero, Quaternion.identity, transform);
		
		for (int i = 0; i < 5; i++) {
			float x = (i + 0.5f)/5;
			
			Vector2 xyPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * x, Screen.height));
			xyPos = xyPos + Vector2.up * alien.transform.localScale.y;
			
			Instantiate(alien, xyPos, Quaternion.identity, aliens.transform);
		}
	}
	
	void repeatSpawn()
    {
      InvokeRepeating("spawnAliens", 2, 3);	  
    }
}
