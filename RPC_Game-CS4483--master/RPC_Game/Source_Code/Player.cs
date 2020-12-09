using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{	[SerializeField]
	Transform spawnPos;
	
	[SerializeField]
	Paper paperPrefab;
	
	protected float halfTri;
    protected float halfTri2;
    // Start is called before the first frame update
    void Start()
    {
        halfTri = transform.localScale.x/2;
        halfTri2 = (transform.localScale.y / 2);
		
		Paper();
		InvokeRepeating("Paper", 0.4f, 0.1f);
	}
	
	void Paper() {
		Paper PaperInst = Instantiate(paperPrefab);
		
		PaperInst.Go(2f, new Color(1f,1f,1f,1f), 0.25f, Vector2.up, true);
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

    }
	
	void OnTriggerEnter2D(Collider2D otherObj) {
		if (otherObj.transform.tag == "Mob") {
			Destroy(gameObject);
			
		}
	}
}
