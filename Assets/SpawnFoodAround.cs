using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFoodAround : MonoBehaviour {

    public GameObject FoodPrefab;

    //borders => we cannot cross them
    public Transform borderUp;
    public Transform borderDown;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start () {

        // Exec Spawn every 4 seconds starting at 3
        InvokeRepeating("SpawnAround", 3, 4);
	}

    void SpawnAround () {

        //generate random position (x,y)

        int x, y;

        x = (int)Random.Range(borderLeft.position.x +1, borderRight.position.x -1);

        y = (int)Random.Range(borderDown.position.y +1, borderUp.position.y -1);

        // show       object        vector         rotation (here default)
        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity); 
    }

}
