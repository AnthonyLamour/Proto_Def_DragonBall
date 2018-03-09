using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {

	public float speed;
	public GameObject Cible;
	public GameObject SriptMouv;
	public Material CoteG;
	public Material FaceH;
	public Material CoteD;
	public Material FaceB;
	public int Ki;
	private Material[] Tab;
	private bool isMouveLeft;
	private bool isMouveRight;
	private bool isMouveUp;
	private bool isMouveDown;
    public Boundary ZoneDeJeu;
	
	//public AudioClip Genkidama;
	public AudioClip Dash1;
	public AudioClip kamehameha;
	public GameObject shot;
	public GameObject shotSpeNiv3;
	public GameObject shotSpeNiv2;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
	
	void Start()
	{
		Tab=SriptMouv.GetComponent<MeshRenderer>().materials;
		isMouveLeft=false;
		isMouveDown=false;
		isMouveUp=false;
		isMouveRight=false;
	}

	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
		
		if ((Input.GetButton("Fire2")) && Ki==3)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shotSpeNiv3, shotSpawn.position, shotSpawn.rotation);
			/*Cible.GetComponent<AudioSource>().clip=Genkidama;
			Cible.GetComponent<AudioSource>().Play();*/
			Ki=0;
        }
		
		if ((Input.GetButton("Fire2")) && Ki==2)
        {
			nextFire = Time.time + fireRate;
			Instantiate(shotSpeNiv2, shotSpawn.position, shotSpawn.rotation);
			SriptMouv.GetComponent<AudioSource>().clip=kamehameha;
			SriptMouv.GetComponent<AudioSource>().Play();
			Ki=0;
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		
		if (moveHorizontal<0){
			isMouveDown=false;
			isMouveUp=false;
			isMouveRight=false;
			Tab[0]=CoteG;
			SriptMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveLeft){
				Cible.GetComponent<AudioSource>().clip=Dash1;
				Cible.GetComponent<AudioSource>().Play();
				isMouveLeft=true;
			}
		}else if (moveHorizontal>0){
			isMouveDown=false;
			isMouveUp=false;
			isMouveLeft=false;
			Tab[0]=CoteD;
			SriptMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveRight){
				Cible.GetComponent<AudioSource>().clip=Dash1;
				Cible.GetComponent<AudioSource>().Play();
				isMouveRight=true;
			}
		}else if (moveVertical<0){
			isMouveLeft=false;
			isMouveUp=false;
			isMouveRight=false;
			Tab[0]=FaceB;
			SriptMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveDown){
				Cible.GetComponent<AudioSource>().clip=Dash1;
				Cible.GetComponent<AudioSource>().Play();
				isMouveDown=true;
			}
		}else {
			if (moveVertical>0){
				isMouveDown=false;
				isMouveLeft=false;
				isMouveRight=false;
			}
			Tab[0]=FaceH;
			SriptMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveUp && moveVertical>0){
				Cible.GetComponent<AudioSource>().clip=Dash1;
				Cible.GetComponent<AudioSource>().Play();
				isMouveUp=true;
			}
		}
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        Cible.GetComponent <Rigidbody>().velocity = movement * speed;

        Cible.GetComponent <Rigidbody>().position = new Vector3 
        (
            Mathf.Clamp (Cible.GetComponent <Rigidbody>().position.x, ZoneDeJeu.xMin, ZoneDeJeu.xMax), 
            0.0f, 
            Mathf.Clamp (Cible.GetComponent <Rigidbody>().position.z, ZoneDeJeu.zMin, ZoneDeJeu.zMax)
        );
    }
}
