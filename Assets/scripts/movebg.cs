// L1F20bscs0366
// Muhammad Nouman Ejaz
// Flappy Bird Game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movebg : MonoBehaviour
{
    public float speed = 1.1f;
    float leftside = -3.2f;
    player gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {   
        // if (game is not over) then there is the (movement of background) otherwise stop
        if (gameover.gameover == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // if obstacle (cylinder / pillar) is out of bond then they destroyed
        if (transform.position.x < leftside && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
