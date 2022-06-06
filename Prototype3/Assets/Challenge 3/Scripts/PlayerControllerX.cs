using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added
using UnityEngine.UI; //added


public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    public float gravityModifier; //private to public, remove =1.5f
    
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    //private float upperBound = 12.5f; //prevent balloon from flying too high
    private float topBound = 15.0f;
    public float bounceHeight = 5.0f; //set bounce height when balloon touches ground

    //public GameObject gameOverScreen;
    public GameOverScreenX gameOverScreen;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver /* && transform.position.y < upperBound*/)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            gameObject.SetActive(gameOverScreen);
            
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        //check if balloon touches ground, bounce and add sound
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * bounceHeight, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }

}
