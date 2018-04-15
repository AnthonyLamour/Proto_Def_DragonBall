using UnityEngine;
using System.Collections;
using UnityEngine.UI;       //to use "Text" type

public class GameController : MonoBehaviour
{
    public GameObject enemy;        //référence à notre prefab Enemy
    public Vector3 spawnValues;

    public Text scoreText;      //displays the score
    private int score;           //holds the value of the current score

    void Start()
    {
        score = 0;
        UpdateScore();
        SpawnWaves();
    }

    //instantiates our enemy prefab
    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);     //var to instantiate at a certain position, Random between -3 & 3 --> weight of our scene
        Quaternion spawnRotation = Quaternion.identity;     //no rotation
        Instantiate(enemy, spawnPosition, spawnRotation);   //instantiate our enemy
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    //displays our score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}