using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public float force;
    private PointEffector2D pointEffector;


    // Start is called before the first frame update
    void Start()
    {
        pointEffector = GetComponent<PointEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            pointEffector.forceMagnitude = force;
        }
        if(Input.GetKey(KeyCode.W))
        {
            pointEffector.forceMagnitude = -force;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            pointEffector.forceMagnitude = 0;
        }

    }
}
