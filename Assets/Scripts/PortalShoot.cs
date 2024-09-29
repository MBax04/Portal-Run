using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalShoot : MonoBehaviour
{
    BoxCollider2D bluePortalCollider;
    BoxCollider2D orangePortalCollider;

    public LayerMask canSpawnPortal;
    public LayerMask cannotSpawnPortal;

    private GameObject bluePortal;
    private GameObject orangePortal;
    private GameObject testPortal;

    private GameObject testPortalCollisionBlue;
    private GameObject testPortalCollisionOrange;

    private GameObject blueLaser;
    private GameObject orangeLaser;
    private GameObject redLaser;
    private LineRenderer blueLaserRenderer;
    private LineRenderer orangeLaserRenderer;
    private LineRenderer redLaserRenderer;

    public Material greenLaserTexture1;
    public Material greenLaserTexture2;
    public Material purpleLaserTexture1;
    public Material purpleLaserTexture2;

    private bool positionGood = false;
    public bool shootOrangeBool;

    private BoxCollider2D blueTrigger;
    private BoxCollider2D orangeTrigger;

    public AudioSource audioLaserShoot;


    void Start()
    {
        bluePortal = GameObject.FindWithTag("Blue");
        orangePortal = GameObject.FindWithTag("Orange");
        testPortal = GameObject.FindWithTag("Test Portal");

        testPortalCollisionBlue = GameObject.FindWithTag("BlueTestCollider");
        testPortalCollisionOrange = GameObject.FindWithTag("OrangeTestCollider"); 

        bluePortalCollider = testPortalCollisionBlue.GetComponent<BoxCollider2D>();
        orangePortalCollider = testPortalCollisionOrange.GetComponent<BoxCollider2D>();

        blueLaser = GameObject.FindWithTag("blueLaser");
        orangeLaser = GameObject.FindWithTag("orangeLaser");
        redLaser = GameObject.FindWithTag("redLaser");

        blueLaserRenderer = blueLaser.GetComponent<LineRenderer>();
        orangeLaserRenderer = orangeLaser.GetComponent<LineRenderer>();
        redLaserRenderer = redLaser.GetComponent<LineRenderer>();

        blueTrigger = GameObject.FindWithTag("layerTriggerBlue").GetComponent<BoxCollider2D>();
        orangeTrigger = GameObject.FindWithTag("layerTriggerOrange").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, transform.position * 100f, Color.green, 10, false);

        if (Input.GetMouseButtonDown(0) && PauseMenu.gamePaused == false)
        {
            shootBlue();
            
        }
        else if (Input.GetMouseButtonDown(1) && PauseMenu.gamePaused == false && shootOrangeBool == true)
        {
            shootOrange();
        }
            shootRed();
    }


    void shootBlue()
    {
        audioLaserShoot.Play();

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        RaycastHit2D shoot = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, (canSpawnPortal | cannotSpawnPortal));
        Debug.DrawRay(transform.position, direction * 100f, Color.green, 1, false);

        laserBlue(shoot.point);


        if (shoot.collider.tag == "canSpawnPortal")
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, shoot.normal);
            Vector2 location = shoot.point;

            // Disable Portal Collider
            bluePortalCollider.enabled = false;

            // call the Test portal script
            testPortal.GetComponent<testPortalScript>().TestPortalPosition(ref location, rotation, out bool positionGood);

            // enable Portal Collider
            bluePortalCollider.enabled = true;

            // Teleport Portal if position is good
            if (positionGood == true)
            {
                bluePortal.transform.position = testPortal.transform.position;
                bluePortal.transform.rotation = rotation;
                orangeTrigger.enabled = true;
                GameObject.Find("SpriteInfrontGreen").SendMessage("GreenAppear");
            } 
        }
    }

    void shootOrange()
    {
        audioLaserShoot.Play();

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        RaycastHit2D shoot = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, (canSpawnPortal | cannotSpawnPortal));
        Debug.DrawRay(transform.position, direction * 100f, Color.green, 1, false);

        laserOrange(shoot.point);

        if (shoot.collider.tag == "canSpawnPortal")
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, shoot.normal);
            Vector2 location = shoot.point;

            // Disable Portal Collider
            orangePortalCollider.enabled = false;

            // call the Test portal script
            testPortal.GetComponent<testPortalScript>().TestPortalPosition(ref location, rotation, out bool positionGood);

            // Disable Portal Collider
            orangePortalCollider.enabled = true;

            // Teleport Portal
            if (positionGood == true)
            {
                orangePortal.transform.position = testPortal.transform.position;
                orangePortal.transform.rotation = rotation;
                blueTrigger.enabled = true;
                GameObject.Find("SpriteInfrontPurple").SendMessage("PurpleAppear");
            }           
        }  
    }

    void laserBlue(Vector2 shootLocation)
    {
        StartCoroutine(laserAnim());
        

        IEnumerator laserAnim()
        {
            redLaserRenderer.enabled = false;

            blueLaserRenderer.enabled = true;
            blueLaserRenderer.material = greenLaserTexture1;

            blueLaserRenderer.SetPosition(0, blueLaser.transform.position);
            blueLaserRenderer.SetPosition(1, shootLocation);

            yield return new WaitForSeconds(0.25f);
            blueLaserRenderer.material = greenLaserTexture2;
            yield return new WaitForSeconds(0.1f);
            blueLaserRenderer.enabled = false;

            redLaserRenderer.enabled = true;
        }
    }

    void laserOrange(Vector2 shootLocation)
    {
        StartCoroutine(laserAnim());


        IEnumerator laserAnim()
        {
            redLaserRenderer.enabled = false;

            orangeLaserRenderer.enabled = true;
            orangeLaserRenderer.material = purpleLaserTexture1;

            orangeLaserRenderer.SetPosition(0, orangeLaser.transform.position);
            orangeLaserRenderer.SetPosition(1, shootLocation);

            yield return new WaitForSeconds(0.25f);
            orangeLaserRenderer.material = purpleLaserTexture2;
            yield return new WaitForSeconds(0.1f);
            orangeLaserRenderer.enabled = false;

            redLaserRenderer.enabled = true;
        }
    }

    void shootRed()
    {
        if (PauseMenu.gamePaused == false)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(
                mousePos.x - transform.position.x,
                mousePos.y - transform.position.y
            );

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, (canSpawnPortal | cannotSpawnPortal));
            redLaserRenderer.SetPosition(0, redLaser.transform.position);
            redLaserRenderer.SetPosition(1, shoot.point);
        }
    }
}
