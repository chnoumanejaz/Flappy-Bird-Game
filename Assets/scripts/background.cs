// L1F20bscs0366
// Muhammad Nouman Ejaz
// Flappy Bird Game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    Vector3 start_position;
    float repeat;
    void Start()
    {
        // just to repeat the background for unlimited movement
        start_position = transform.position;
        repeat = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < start_position.x - repeat)
        {
            transform.position = start_position;
        }
    }
}
