using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
    public float maxFuel;
    public float fuel;
    public float jumpForce;
    public float refillSpeed;
    public float fuelConsumption;
    private Rigidbody2D rb;
    public bool jetpackBool = false;
    public Slider slider;
    public Image sliderFill;
    public Color lowFull;
    public Color highFull;
    public Animator animator;
    public SpriteRenderer jetpackSprite;
    public ParticleSystem particles1;
    public ParticleSystem particles2;
    public AudioSource audioJetpack;
    private bool audioPlaying;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuel = maxFuel;
        sliderFill.color = Color.Lerp(lowFull, highFull, fuel/100   );
        slider.SetValueWithoutNotify(fuel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && jetpackBool == true)
        {
            if (fuel > 0)
            {
                if (fuel < 50)
                {
                    jumpForce = (fuel/50) * 5 + 5;
                }
                else
                {
                    jumpForce = 10;
                }
                rb.AddForce(Vector2.up * jumpForce * Time.deltaTime * 1000);
                // drain fuel
                fuel -= (Time.deltaTime * fuelConsumption);
                animator.SetBool("Flying", true);
                particles1.enableEmission = true;
                particles2.enableEmission = true;
                AudioPlay();
            }
            else
            {
                animator.SetBool("Flying", false);
                particles1.enableEmission = false;
                particles2.enableEmission = false;
                AudioStop();
            }

            slider.SetValueWithoutNotify(fuel);
            sliderFill.color = Color.Lerp(lowFull, highFull, fuel/100);
        }
        else
        {
            if (fuel < maxFuel)
            {
                // Refuel
                fuel += (Time.deltaTime * refillSpeed);
                slider.SetValueWithoutNotify(fuel);
                sliderFill.color = Color.Lerp(lowFull, highFull, fuel/100);
            }
            animator.SetBool("Flying", false);
            particles1.enableEmission = false;
            particles2.enableEmission = false;
            AudioStop();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jetpack Pickup")
        {
            collision.gameObject.SetActive(false);
            jetpackBool = true;

            slider.gameObject.SetActive(true);
            jetpackSprite.enabled = true;

        }
    }

    private void AudioPlay()
    {
        if (audioPlaying == false)
        {
            audioJetpack.Play();
            audioPlaying = true;
        }
    }

    private void AudioStop()
    {
        if (audioPlaying == true)
        {
            audioJetpack.Stop();
            audioPlaying = false;
        }
    }
}
