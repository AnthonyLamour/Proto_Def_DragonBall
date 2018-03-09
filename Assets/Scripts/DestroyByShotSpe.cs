using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShotSpe : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("ZoneDeJeu") || other.CompareTag ("Player") || other.CompareTag ("KillZone"))
        {
            return;
        }

        Destroy (other.gameObject);
    }
}
