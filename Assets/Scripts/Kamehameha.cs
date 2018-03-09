using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamehameha : MonoBehaviour {
	
	public GameObject Cible;
	public GameObject Perso;
	private Transform spawnPoint;
	
	void Start(){
		Perso=GameObject.Find("Player");
	}
	
	void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("KillZone"))
        {
            Destroy(Cible);
        }
    }
	
	void Update ()
    {
		if (Cible){
			spawnPoint=Perso.GetComponent<Transform>();
			Cible.GetComponent<Transform>().localScale = Cible.GetComponent<Transform>().localScale+new Vector3(0, 0, 0.1F);
			transform.position = spawnPoint.position-new Vector3(0, 0, Cible.GetComponent<Transform>().localScale.z/2F);
		}
    }
}
