using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; //reference to Rigidbody

    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true; // use to prevent player from double-jumping
    public bool gameOver = false; //must be private

    private Animator playerAnim; //reference to Animator

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio; //want to omit player audio


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerAnim = GetComponent<Animator>();
        
        Physics.gravity *= gravityModifier; 
        // physics.gravity = physics.gravity * gravityModifier

        playerAudio = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isOnGround = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            
            //trigger death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();

            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);

        }


    }
}
