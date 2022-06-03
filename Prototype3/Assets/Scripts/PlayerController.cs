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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerAnim = GetComponent<Animator>();
        
        Physics.gravity *= gravityModifier; 
        // physics.gravity = physics.gravity * gravityModifier

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //isOnGround = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }


    }
}
