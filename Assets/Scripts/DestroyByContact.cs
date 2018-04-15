using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue;                  //number of points gained whenever the player destroys an enemy
    private GameController gameController;   //holds a reference to the instance of our gameController, allows us to call the "AddScore" function when an enemy is destroyed

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");     //each instance of enemy will find its reference to our Game Controller script
        //if we found a reference to our gameController object
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();       //set the reference to the script held in the Game Controller Object
        //if we haven't find it
        if (gameController == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZoneDeJeu")
        {
            return;
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);  //destroy the bolt
        Destroy(gameObject);        //destroy the enemy
    }
}