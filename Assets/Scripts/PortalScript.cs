using System;
using System.Collections;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private bool canTeleport = true;

    private float orangePortalRotation;
    private float bluePortalRotation;
    private float rotationDifference;
    private float directionx;
    private float directiony;
    private float theGradient;
    private double angleInRadsD;
    private float angleInRads;
    private float angleInDegs;
    private float newAngle;
    private float force;
    private readonly float forceMultiplier = 475;
    private readonly float addedForce = 475;
    private readonly float minForce = 2750;
    private readonly float maxForce = 20000;
    public float speed;

    private CircleCollider2D circleCollider;
    private Rigidbody2D rb;

    public float velX;
    private SurfaceEffector2D se;
    private BoxCollider2D bc;

    //public LayerMask ground;
    public LayerMask portal;
    public LayerMask trigger;
    public LayerMask canSpawnPortal;
    public LayerMask cannotSpawnPortal;

    GameObject blueBall;
    GameObject orangeBall;

    public bool freezeOrange = false;
    public bool freezeBlue = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        se = GetComponent<SurfaceEffector2D>();
        se.colliderMask = canSpawnPortal | cannotSpawnPortal | trigger | portal;
        bc = GetComponent<BoxCollider2D>();

        blueBall = GameObject.FindWithTag("blueBall");
        orangeBall = GameObject.FindWithTag("orangeBall");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = rb.velocity.normalized;
        directionx = direction.x;
        directiony = direction.y;

        velX = Mathf.Abs(rb.velocity.x);

        speed = rb.velocity.magnitude;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "layerTriggerOrange" && canTeleport == true)
        {
            
            orangePortalRotation = GameObject.Find("PortalOrange").transform.rotation.eulerAngles.z;

            if (orangePortalRotation == 90 || orangePortalRotation == -90 || orangePortalRotation == 270 || orangePortalRotation == -270)
            {
                if(Mathf.Abs(rb.velocity.x) > 0.5)
                {
                    rb.drag = 0;
                    orangeBall.SetActive(false);

                    if (freezeOrange == true)
                    {
                        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    }
                }
            }

            se.colliderMask = portal | trigger;
            bc.enabled = false;

        }
        if (collision.gameObject.tag == "layerTriggerBlue" && canTeleport == true)
        {
            

            bluePortalRotation = GameObject.Find("PortalBlue").transform.rotation.eulerAngles.z;

            if (bluePortalRotation == 90 || bluePortalRotation == -90 || bluePortalRotation == 270 || bluePortalRotation == -270)
            {
                if (Mathf.Abs(rb.velocity.x) > 0.5)
                {
                    rb.drag = 0;
                    blueBall.SetActive(false);

                    if (freezeBlue == true)
                    {
                        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    }
                } 
            }

            se.colliderMask = portal | trigger;
            bc.enabled = false;

        }


        if (collision.gameObject.tag == "Blue" && canTeleport == true)
        {
            orangePortalRotation = GameObject.Find("PortalOrange").transform.rotation.eulerAngles.z;
            bluePortalRotation = GameObject.Find("PortalBlue").transform.rotation.eulerAngles.z;

            force = speed;

            Vector2 teleportPos = GameObject.FindGameObjectWithTag("OrangeChile").transform.position;

            transform.position = new Vector2(teleportPos.x, teleportPos.y);

            

            rotationDifference = orangePortalRotation - bluePortalRotation;


            theGradient = directiony / directionx;
            angleInRadsD = Math.Atan(theGradient);
            angleInRads = Convert.ToSingle(angleInRadsD);
            angleInDegs = angleInRads * (180 / Mathf.PI);
            

            angleInDegs = angleInDegs - 2 * bluePortalRotation;


            if ( theGradient <= 0 )
            {
                angleInDegs = angleInDegs + 180;
            }
            if (directiony > 0)
            {
                angleInDegs = angleInDegs + 180;
            }

            angleInDegs = 180 - angleInDegs;

            newAngle = rotationDifference + angleInDegs;

            if (bluePortalRotation == -90 || bluePortalRotation == 270)
            {
                newAngle = newAngle + 180;
            }

            Vector2 dir = Quaternion.AngleAxis(newAngle, Vector3.forward) * Vector2.right;

            rb.velocity = new Vector2(0, 0);

            force = force * forceMultiplier + addedForce;
            if (force < minForce)
            {
                force = minForce;
            }
            else if (force > maxForce)
            {
                force = maxForce;
            }

            rb.constraints = RigidbodyConstraints2D.None;
            blueBall.SetActive(true);

            rb.AddForce(dir * force);

            if (freezeBlue == true)
            {
                freezeOrange = false;
            }
            if (freezeOrange == true)
            {
                freezeBlue = false;
            }
        }

        if (collision.gameObject.tag == "Orange" && canTeleport == true) 
        { 
            
            orangePortalRotation = GameObject.Find("PortalOrange").transform.rotation.eulerAngles.z;
            bluePortalRotation = GameObject.Find("PortalBlue").transform.rotation.eulerAngles.z;

            force = speed;

            Vector2 teleportPos = GameObject.FindGameObjectWithTag("BlueChile").transform.position;

            transform.position = new Vector2(teleportPos.x, teleportPos.y);

            

            rotationDifference = bluePortalRotation - orangePortalRotation;

            theGradient = directiony / directionx;
            angleInRadsD = Math.Atan(theGradient);
            angleInRads = Convert.ToSingle(angleInRadsD);
            angleInDegs = angleInRads * (180 / Mathf.PI);

            angleInDegs = angleInDegs - 2 * orangePortalRotation;

            if (theGradient <= 0)
            {
                angleInDegs = angleInDegs + 180;
            }
            if (directiony > 0)
            {
                angleInDegs = angleInDegs + 180;
            }

            angleInDegs = 180 - angleInDegs;

            newAngle = rotationDifference + angleInDegs;

            if (orangePortalRotation == -90 || orangePortalRotation == 270 )
            {
                newAngle = newAngle + 180;
            }

            Vector2 dir = Quaternion.AngleAxis(newAngle, Vector3.forward) * Vector2.right;

            rb.velocity = new Vector2(0, 0);

            force = force * forceMultiplier + addedForce;
            if (force < minForce)
            {
                force = minForce;
            }
            else if (force > maxForce)
            {
                force = maxForce;
            }

            rb.constraints = RigidbodyConstraints2D.None;
            orangeBall.SetActive(true);

            rb.AddForce(dir * force);

            if (freezeOrange == true)
            {
                freezeBlue = false;
            }
            if (freezeBlue == true)
            {
                freezeOrange = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "layerTriggerOrange" || collision.gameObject.tag == "layerTriggerBlue") && canTeleport == true && circleCollider.IsTouchingLayers(trigger) == false)
        {
            se.colliderMask = canSpawnPortal | cannotSpawnPortal | trigger | portal;
            bc.enabled = true;

            rb.constraints = RigidbodyConstraints2D.None;
            rb.drag = 0.3f;
            orangeBall.SetActive(true);
            blueBall.SetActive(true);
        }
        if (collision.gameObject.tag == "layerTriggerOrange")
        {
            freezeOrange = true;
        }
        if (collision.gameObject.tag == "layerTriggerBlue")
        {
            freezeBlue = true;
        }
    }
}   