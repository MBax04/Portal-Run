using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testPortalScript : MonoBehaviour
{


    private GameObject testPortal;
    public GameObject player;

    public Vector2 rotation;
    public Vector2 location;

    public GameObject topRight;
    public GameObject bottomRight;
    public GameObject topLeft;
    public GameObject bottomLeft;

    public LayerMask canSpawnPortal;
    public LayerMask cannotSpawnPortal;
    public LayerMask testPortalCollision;
    public LayerMask portal;

    private bool topRightGood = false;
    private bool bottomRightGood = false;
    private bool topLeftGood = false;
    private bool bottomLeftGood = false;
    private bool bottomRightGood2 = false;
    private bool bottomLeftGood2 = false;
    private bool middleGood = false;
    private bool inCamera;

    private float attempts = 0f;
    private readonly float correctionDistance = 0.01f;

    public Camera mainCamera;
    private float height;
    private float width;

    public bool staticCamera;



    void Start()
    {
        testPortal = GameObject.FindWithTag("Test Portal");

        height = mainCamera.orthographicSize + 0.5f;
        width = (height - 0.5f) * mainCamera.aspect + 0.5f;
    }



    public void TestPortalPosition(ref Vector2 location, Quaternion rotation, out bool positionGood)
    {


        // Telport Test Object
        testPortal.transform.position = location;
        testPortal.transform.rotation = rotation;

        inCamera = true;
        if ((location.x > mainCamera.transform.position.x + width || location.x < mainCamera.transform.position.x - width || location.y > mainCamera.transform.position.y + height || location.y < mainCamera.transform.position.y - height) && staticCamera == false)
        {
            inCamera = false;
        }



        attempts = 0f;
        while ((topRightGood == false || bottomRightGood == false || topLeftGood == false || bottomLeftGood == false || bottomRightGood2 == false || bottomLeftGood2 == false) && attempts < 150f)
        {
            // Check conditions
            Collider2D collider1 = Physics2D.OverlapPoint(topRight.transform.position, (canSpawnPortal | cannotSpawnPortal | portal));
            if (collider1 != null)
            {
                topRightGood = false;
            }
            else
            {
                topRightGood = true;
            }
            Collider2D collider2 = Physics2D.OverlapPoint(topLeft.transform.position, (canSpawnPortal | cannotSpawnPortal | portal));
            if (collider2 != null)
            {
                topLeftGood = false;
            }
            else
            {
                topLeftGood = true;
            }
            Collider2D collider3 = Physics2D.OverlapPoint(bottomRight.transform.position, canSpawnPortal);
            if (collider3 != null)
            {
                bottomRightGood = true;
            }
            else
            {
                bottomRightGood = false;
            }
            Collider2D collider4 = Physics2D.OverlapPoint(bottomLeft.transform.position, canSpawnPortal);
            if (collider4 != null)
            {
                bottomLeftGood = true;
            }
            else
            {
                bottomLeftGood = false;
            }
            Collider2D collider5 = Physics2D.OverlapPoint(bottomRight.transform.position, testPortalCollision);
            if (collider5 != null)
            {
                bottomRightGood2 = false;
            }
            else
            {
                bottomRightGood2 = true;
            }
            Collider2D collider6 = Physics2D.OverlapPoint(bottomLeft.transform.position, testPortalCollision);
            if (collider6 != null)
            {
                bottomLeftGood2 = false;
            }
            else
            {
                bottomLeftGood2 = true;
            }
            Collider2D collider7 = Physics2D.OverlapBox(location, new Vector2(1.25f, 0.25f), testPortal.transform.eulerAngles.z, testPortalCollision);
            if (collider7 != null)
            {
                middleGood = false;
            }
            else
            {
                middleGood = true;
            }

            if (middleGood == true)
            {
                //Move until good
                if (topRightGood == false || bottomRightGood == false || bottomRightGood2 == false)
                {
                    testPortal.transform.position += -testPortal.transform.right * correctionDistance;

                }
                if (topLeftGood == false || bottomLeftGood == false || bottomLeftGood2 == false)
                {
                    testPortal.transform.position += testPortal.transform.right * correctionDistance;

                }
            }

            attempts = attempts + 1f;
        }

        // If conditions are good
        if (topRightGood == true && bottomRightGood == true && topLeftGood == true && bottomLeftGood == true && bottomRightGood2 == true && bottomLeftGood2 == true && middleGood == true && inCamera == true)
        {
            positionGood = true;
        }
        else
        {
            positionGood = false;
        }

        // Resets the corners goods to bads so that it can rerun
        topRightGood = false;
        topLeftGood = false;
        bottomRightGood = false;
        bottomLeftGood = false;
        bottomRightGood2 = false;
        bottomLeftGood2 = false;

    }
}