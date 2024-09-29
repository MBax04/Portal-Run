using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    private int level;
    public Jetpack jetpack;
    Scene scene;
    public Rigidbody2D rb;
    private float smoothSpeed = 0.2f;
    public float shrinkSpeed;
    public float rotateSpeed;
    private Transform target;
    private bool move = false;

    public GameObject sprite;
    public GameObject headEmpty;

    public AudioSource audioExplosion;
    public ParticleSystem deathParticles;

    private bool dead = false;

    private void Start()
    {
        //Time.timeScale = 0.125f;
        target = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (move == true)
        {
            Vector3 desiredPosition = target.position;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;

            Quaternion newAngle = Quaternion.Euler(0, 0, sprite.transform.localEulerAngles.z + rotateSpeed);

            sprite.transform.rotation = newAngle;
            headEmpty.transform.rotation = newAngle;

            if (transform.localScale.x >= 0)
            {
                transform.localScale -= new Vector3(shrinkSpeed / 10f, shrinkSpeed / 10f);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            dead = true;
            Reset(); ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (MainMenu.speedRunByLevel == true)
            {
                scene = SceneManager.GetActiveScene();
                level = scene.buildIndex;
                SceneManager.LoadScene("LevelFinish");
                MainMenu.speedRunByLevel = false;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                jetpack.jetpackBool = false;
                headEmpty.GetComponent<FollowMouse>().enabled = false;

                move = true;




                StartCoroutine(FinishWait());

                IEnumerator FinishWait()
                {
                    // After a delay for the aniamtion to play the level is reset
                    yield return new WaitForSeconds(0.35f);

                    scene = SceneManager.GetActiveScene();
                    level = scene.buildIndex;
                    SceneManager.LoadScene(level + 1);
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
            GameObject.Find("Canvas").SendMessage("Resume");
            if(MainMenu.speedRunByLevel == true)
            {
                GameObject.Find("GlobalObject").SendMessage("RestartTimer");
            }
        }
        /* if (Input.GetKeyDown(KeyCode.Comma))
        {
            scene = SceneManager.GetActiveScene();
            level = scene.buildIndex;
            SceneManager.LoadScene(level - 1);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            scene = SceneManager.GetActiveScene();
            level = scene.buildIndex;
            SceneManager.LoadScene(level + 1);
        } */
    }

    private void Reset()
    {
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        jetpack.jetpackBool = false;

        if (dead == true)
        {
            StartCoroutine(DeathWait());
        }
        else
        {
            scene = SceneManager.GetActiveScene();
            level = scene.buildIndex;
            SceneManager.LoadScene(level);
        }
        

        IEnumerator DeathWait()
        {
            audioExplosion.Play();
            deathParticles.Play();
            yield return new WaitForSeconds(1f);

            scene = SceneManager.GetActiveScene();
            level = scene.buildIndex;
            SceneManager.LoadScene(level);
        }
    }
}
