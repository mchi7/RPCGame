using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTransformChildrenChanged() {
		if (transform.childCount == 0) Destroy(gameObject);
	}
}
