using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{

    private float speed;
    private float rotationSpeed;
    public float speedScale = 0.2f;
    private int spinDirection;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        rotationSpeed = speed * speedScale;

        Vector2 direction = rb.velocity.normalized;

        if (direction.x > 0)
        {
            spinDirection = -1;
        }
        else if (direction.x < 0)
        {
            spinDirection = 1;
        }
        else
        {
            spinDirection = 0;
        }
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * spinDirection);
    }
}