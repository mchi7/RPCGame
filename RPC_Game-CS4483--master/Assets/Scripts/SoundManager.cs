using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerShootSound;
    public static AudioClip mobDeathSound;
    public static AudioClip playerDeathSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        playerShootSound = Resources.Load<AudioClip>("playerShoot");
        mobDeathSound = Resources.Load<AudioClip>("mobDestroyed");
        playerDeathSound = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound (string clip)
    {
        switch (clip)
        {
            case "playerShoot":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            case "mobDestroyed":
                audioSrc.PlayOneShot(mobDeathSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
