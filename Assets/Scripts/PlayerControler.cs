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
	public GameObject SpritMouv;
	public Material CoteG;
	public Material FaceH;
	public Material CoteD;
	public Material FaceB;
	private Material[] Tab;
	private bool isMouveLeft;
	private bool isMouveRight;
	private bool isMouveUp;
	private bool isMouveDown;
    public Boundary ZoneDeJeu;
	
	public float TailleBar;
	public AudioClip Genkidama;
	public AudioClip Dash1;
	public AudioClip Dash2;
	public AudioClip Dash3;
	public AudioClip kamehameha;
	public GameObject shot;
	public GameObject shotSpeNiv3;
	public GameObject shotSpeNiv2;
    public Transform shotSpawn;
    public float fireRate;
	private float hazard;
    private float nextFire;
	private GameObject Ki1;
	private GameObject Ki2;
	private GameObject Ki3;
	private Vector3 RefPoint;
	
	void Start()
	{
		Tab=SpritMouv.GetComponent<MeshRenderer>().materials;
		isMouveLeft=false;
		isMouveDown=false;
		isMouveUp=false;
		isMouveRight=false;
		Ki1=GameObject.Find("KiNiv1");
		Ki2=GameObject.Find("KiNiv2");
		Ki3=GameObject.Find("KiNiv3");
		RefPoint=new Vector3(4F, 6F, 4F);
	}

	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
		
		if ((Input.GetButton("Fire2")) && Ki1.GetComponent<Transform>().localScale.x==TailleBar && Ki2.GetComponent<Transform>().localScale.x==TailleBar && Ki3.GetComponent<Transform>().localScale.x==TailleBar)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shotSpeNiv3, shotSpawn.position, shotSpawn.rotation);
			SpritMouv.GetComponent<AudioSource>().clip=Genkidama;
			SpritMouv.GetComponent<AudioSource>().Play();
			Ki1.GetComponent<Transform>().localScale=new Vector3(0.5F, 0.3F, 1F);
			Ki2.GetComponent<Transform>().localScale=new Vector3(0.5F, 0.3F, 1F);
			Ki3.GetComponent<Transform>().localScale=new Vector3(0.5F, 0.3F, 1F);
			Ki1.GetComponent<Transform>().position = RefPoint+new Vector3(Ki1.GetComponent<Transform>().localScale.x/2F, 6F, 0);
			Ki3.GetComponent<Transform>().position = RefPoint+new Vector3(Ki2.GetComponent<Transform>().localScale.x/2F, 4.9F, 0);
        }else if ((Input.GetButton("Fire2")) && Ki1.GetComponent<Transform>().localScale.x==TailleBar && Ki2.GetComponent<Transform>().localScale.x==TailleBar)
        {
			nextFire = Time.time + fireRate;
			Instantiate(shotSpeNiv2, shotSpawn.position, shotSpawn.rotation);
			SpritMouv.GetComponent<AudioSource>().clip=kamehameha;
			SpritMouv.GetComponent<AudioSource>().Play();
			Ki1.GetComponent<Transform>().localScale=new Vector3(0.5F, 0.3F, 1F);
			Ki2.GetComponent<Transform>().localScale=new Vector3(0.5F, 0.3F, 1F);
			Ki1.GetComponent<Transform>().position = RefPoint+new Vector3(Ki1.GetComponent<Transform>().localScale.x/2F, 6F, 0);
			Ki2.GetComponent<Transform>().position = RefPoint+new Vector3(Ki2.GetComponent<Transform>().localScale.x/2F, 4.9F, 0);
        }
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		hazard=Random.Range(1,3);
		
		if (moveHorizontal<0){
			isMouveDown=false;
			isMouveUp=false;
			isMouveRight=false;
			Tab[0]=CoteG;
			SpritMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveLeft){
				if (hazard==1){
					Cible.GetComponent<AudioSource>().clip=Dash1;
				}else if (hazard==3){
					Cible.GetComponent<AudioSource>().clip=Dash3;
				}else{
					Cible.GetComponent<AudioSource>().clip=Dash2;
				}
				Cible.GetComponent<AudioSource>().Play();
				isMouveLeft=true;
			}
		}else if (moveHorizontal>0){
			isMouveDown=false;
			isMouveUp=false;
			isMouveLeft=false;
			Tab[0]=CoteD;
			SpritMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveRight){
				if (hazard==1){
					Cible.GetComponent<AudioSource>().clip=Dash1;
				}else if (hazard==3){
					Cible.GetComponent<AudioSource>().clip=Dash3;
				}else{
					Cible.GetComponent<AudioSource>().clip=Dash2;
				}
				Cible.GetComponent<AudioSource>().Play();
				isMouveRight=true;
			}
		}else if (moveVertical<0){
			isMouveLeft=false;
			isMouveUp=false;
			isMouveRight=false;
			Tab[0]=FaceB;
			SpritMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveDown){
				if (hazard==1){
					Cible.GetComponent<AudioSource>().clip=Dash1;
				}else if (hazard==3){
					Cible.GetComponent<AudioSource>().clip=Dash3;
				}else{
					Cible.GetComponent<AudioSource>().clip=Dash2;
				}
				Cible.GetComponent<AudioSource>().Play();
				isMouveDown=true;
			}
		}else if (moveVertical>0){
			isMouveDown=false;
			isMouveLeft=false;
			isMouveRight=false;
			Tab[0]=FaceH;
			SpritMouv.GetComponent<MeshRenderer>().materials=Tab;
			if (!isMouveUp){
				if (hazard==1){
					Cible.GetComponent<AudioSource>().clip=Dash1;
				}else if (hazard==3){
					Cible.GetComponent<AudioSource>().clip=Dash3;
				}else{
					Cible.GetComponent<AudioSource>().clip=Dash2;
				}
				Cible.GetComponent<AudioSource>().Play();
				isMouveUp=true;
			}
		}else{
			isMouveDown=false;
			isMouveLeft=false;
			isMouveRight=false;
			isMouveUp=false;
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
