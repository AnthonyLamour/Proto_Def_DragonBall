using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Mouve : MonoBehaviour {

	public float speed;
	public AudioClip Tir1;
	public AudioClip Tir2;
	public AudioClip Tir3;
	public AudioClip Tir4;
	public AudioClip Tir5;
	public GameObject Cible;
	private float hazard;

    void Start ()
    {
		hazard=Random.Range(1,5);
		if (hazard==5){
			Cible.GetComponent<AudioSource>().clip=Tir5;
		}else if (hazard==4){
			Cible.GetComponent<AudioSource>().clip=Tir4;
		}else if (hazard==3){
			Cible.GetComponent<AudioSource>().clip=Tir3;
		}else if (hazard==2){
			Cible.GetComponent<AudioSource>().clip=Tir2;
		}else {
			Cible.GetComponent<AudioSource>().clip=Tir1;
		}
		Cible.GetComponent<AudioSource>().Play();
        Cible.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
