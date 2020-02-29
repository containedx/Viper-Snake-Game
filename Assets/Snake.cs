using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class Snake : MonoBehaviour {

    //up == default
    Vector2 direction = Vector2.zero; 

	// Use this for initialization
	void Start () {

        // moving every 300ms
        InvokeRepeating("Moving", 0.3f, 0.3f);
		
	}
	
	// Update is called once per frame
	void Update () {

        // on key press change direction 

        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector2.up;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector2.down;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector2.right;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector2.left;

    }

    void Moving () {

        transform.Translate(direction);


    }
}
