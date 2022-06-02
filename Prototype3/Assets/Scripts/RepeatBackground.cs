using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; //know where to reset background

    private float repeatWidth; 

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //get all coordinates of transform position
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //check if our current position becomes less than our starting position
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
