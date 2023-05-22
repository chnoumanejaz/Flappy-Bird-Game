// L1F20bscs0366
// Muhammad Nouman Ejaz
// Flappy Bird Game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    Rigidbody rb;
    
    // force when space press
    public float force = 2;
    int counter = 0;
    // to check game over
    bool onground = false;
    public bool gameover = false;

    // for audio use
    AudioSource audiosource;
    public AudioClip jumpsound;
    public AudioClip crashsound;

    // for text when game over
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI score;
    public TextMeshProUGUI EndScore;

    // welcome messages
    public TextMeshProUGUI pressmsg;
    public TextMeshProUGUI gooon;

    public Button playAgain;
    
    // to calculate scores
    float scoore = -0.9f;
    float scorepersec;
    
    void Start()
    {
        // getting components of (audio source) an (rigid body)
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();

        // maintaning scores to calculate properly if the bird crosses the obstacles (cylinders / pillars)
        scorepersec = 0.37f;
    }

    
    void Update()
    {
           // when space press
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            
            counter++;
            if (counter == 3)
            {
                pressmsg.gameObject.SetActive(false);
            }
            if(counter == 5 && gameover == false)
            {
                gooon.gameObject.SetActive(true);
            }
            if (counter == 8)
            {
                gooon.gameObject.SetActive(false);
            }
          
           if(gameover == false)
           {
               // play sound and jump when (game is not over yet)
                 audiosource.PlayOneShot(jumpsound, 1.0f);
                 rb.AddForce(Vector3.up * force, ForceMode.Impulse);
           }
        }

        // maintainig the position on y-axis to controll (over jump) and (over down)
        if (transform.position.y > 3.02f)
        {
            transform.position = new Vector3(transform.position.x, 3.02f , transform.position.z);
        }
        if (transform.position.y < -1.0f)
        {
            // if onground true it means the bird is (not in the camera) or (not visible) so then (game will over)
            onground = true;
            if (onground == true)
            {
                // (Game Over) and (Restart) Message appear if game Ends.
                gameOver.gameObject.SetActive(true);
                playAgain.gameObject.SetActive(true);
                pressmsg.gameObject.SetActive(false);
                gooon.gameObject.SetActive(false);
                

                // When the game End -- The scores show in center as a (total score) and the other one will be hidden
                EndScore.gameObject.SetActive(true);
                score.gameObject.SetActive(false);

                gameover = true;
            }
            // if game not over then normal positions work
            transform.position = new Vector3(transform.position.x, -1.0f, transform.position.z);
        }
        
        if(gameover == false)
        {
            // if game is (not over) then score counts with time and (when the bird cross the obstacles) (cylinder / pilar)
            score.text = "Scores: " + (int)scoore;
            scoore += scorepersec * Time.deltaTime;

            // calculating to show (Total scores) at the end in the center
            EndScore.text = "Total Score: " + (int)scoore;
        }
    }

    private void OnCollisionEnter(Collision Collision)
    {
      
        // if bird collide with obstacle (cylinder / pillar)
        if (Collision.gameObject.CompareTag("obstacle"))
        {
            // (Game Over) and (Restart) Message appear if game Ends.
            gameOver.gameObject.SetActive(true);
            playAgain.gameObject.SetActive(true);
            gooon.gameObject.SetActive(false);

            // When the game End -- The scores show in center as a (total score) and the other one will be hidden
            EndScore.gameObject.SetActive(true);
            score.gameObject.SetActive(false);

            // plays the crash sound and end the game
            audiosource.PlayOneShot(crashsound, 1.0f);
            gameover = true;
            Debug.Log("Game Over..! ");
        }
    }

    // used to restart the game if game ends
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}