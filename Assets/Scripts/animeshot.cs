using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animeshot : MonoBehaviour {


	public Material shot1;
	public Material shot2;
	public Material shot3;
	public Material shot4;
	public GameObject SpritShot;
	private Material[] Tab;
	private int test;
	private float attenteanime;
	private float nextsprit;
	
	void Start () {
		Tab=SpritShot.GetComponent<MeshRenderer>().materials;
		test=4;
		attenteanime=0.1F;
	}
	
	void Update () {
		if (test==4 && Time.time > nextsprit){
			Tab[0]=shot1;
			SpritShot.GetComponent<MeshRenderer>().materials=Tab;
			test=1;
			nextsprit = Time.time + attenteanime;
		}else if (test==3 && Time.time > nextsprit){
			Tab[0]=shot2;
			SpritShot.GetComponent<MeshRenderer>().materials=Tab;
			test=4;
			nextsprit = Time.time + attenteanime;
		}else if (test==2 && Time.time > nextsprit){
			Tab[0]=shot3;
			SpritShot.GetComponent<MeshRenderer>().materials=Tab;
			test=3;
			nextsprit = Time.time + attenteanime;
		}else if (test==1 && Time.time > nextsprit){
			Tab[0]=shot4;
			SpritShot.GetComponent<MeshRenderer>().materials=Tab;
			test=2;
			nextsprit = Time.time + attenteanime;
		}
		
	}
}
