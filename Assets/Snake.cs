using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    //up == default
    Vector2 direction = Vector2.zero;

    bool ate = false;

    public GameObject TailPrefab;

    public Component Score; 

    // track of snake elements
    List<Transform> tail = new List<Transform>();

    public static int score = 0;

    // to control how fast snake is
    public float velocity = 0.2f; 

	// Use this for initialization
	void Start () {

        // moving every velocity second
        //InvokeRepeating("Moving", velocity, velocity);   

        StartCoroutine(Faster());

    }
	
	// Update is called once per frame
	void Update () {

        // update score
        Score.GetComponent<TMPro.TextMeshProUGUI>().text = "" + score; 

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

    IEnumerator Faster()
    {
        while(true)
        {
            Moving();
            yield return new WaitForSeconds(velocity);
        }
    }

    void Moving () {

        // save current position
        Vector2 headposition = transform.position; 

        // change direction
        transform.Translate(direction);

        if (ate)
        {
            // load prefab
            GameObject tailelement = (GameObject)Instantiate(TailPrefab, headposition, Quaternion.identity);

            // insert at end of snake
            tail.Insert(0, tailelement.transform);

            // raise score value and velocity
            score += 1;
            velocity -= 0.01f; 

            ate = false; 
        }

        if (tail.Count > 0)  // if==0 => snake has only head
        {
            // Move last element to place where head was before changing direction
            // gap will be filled and movement will be smooth
            tail.Last().position = headposition;

            // fix sequence of tail

            // Insert first 'tail'
            tail.Insert(0, tail.Last());
            // Remove last
            tail.RemoveAt(tail.Count - 1); 
        }


    }

    void OnTriggerEnter2D( Collider2D coll)
    {
        if ( coll.name.StartsWith("pizza"))
        {
            // eating
            ate = true;
            Destroy(coll.gameObject); 
        }
        else
        {
            // snake dead == restart game
            SceneManager.LoadScene("gameover");
            score = 0; 
        }
    }
}
