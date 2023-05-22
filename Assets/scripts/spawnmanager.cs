// L1F20bscs0366
// Muhammad Nouman Ejaz
// Flappy Bird Game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject cylinder;
    player gameover;
    
    void Start()
    {
        gameover = FindObjectOfType<player>();
        InvokeRepeating("spawn", 1, 3);

    }

    void spawn()
    {
        if (gameover.gameover == false)
        {
            // if (game is not over) then there is the (unlimited spawning) of obstacles (cylinder / pillars) at random up down position
            Vector3 position = new Vector3(3, Random.Range(1.9f, 2.68f), -7.79f);
            Instantiate(cylinder, position, cylinder.transform.rotation);
        }
    }
}
