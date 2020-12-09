using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour { 

    public static int ammo = 20;
    Text ammoTxt;

    // Start is called before the first frame update
    void Start()
    {
        ammoTxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoTxt.text = "Ammo: " + ammo.ToString();
    }
}
