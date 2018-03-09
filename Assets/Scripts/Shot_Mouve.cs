using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mouve : MonoBehaviour {

	public float speed;
	public GameObject Cible;

    void Start ()
    {
        Cible.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
