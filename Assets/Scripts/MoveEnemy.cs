using System.Collections;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    private bool isLeft = false;

    void Update() {
        //make the enemy go down until the enemy reached 3 on the z axis
        if (this.GetComponent<Transform>().position.z > 3)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        //once the enemy reached the limit on the z axis, it goes left until it reached -3 on the x axis
        else if (this.GetComponent<Transform>().position.x >= -3 && isLeft == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            if (this.GetComponent<Transform>().position.x < -3)
                isLeft = true;      //we know the enemy reached -3 on the x axis
        }
        //once the enemy reached -3 on the x axis, it goes right until it reached 3 on the x axis
        else if (this.GetComponent<Transform>().position.x <= 3 && isLeft == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            if (this.GetComponent<Transform>().position.x > 3)
                isLeft = false;     //we know the enemy reached 3 on the x axis
        }
    }
}
