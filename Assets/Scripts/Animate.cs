using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animatorPurple;
    Animator animatorGreen;

    SpriteRenderer purpleInfrontSpriteRenderer;
    SpriteRenderer greenInfrontSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animatorPurple = GameObject.Find("SpriteInfrontPurple").GetComponent<Animator>();
        animatorGreen = GameObject.Find("SpriteInfrontGreen").GetComponent<Animator>();

        purpleInfrontSpriteRenderer = GameObject.Find("SpriteBehindPurple").GetComponent<SpriteRenderer>();
        greenInfrontSpriteRenderer = GameObject.Find("SpriteBehindGreen").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animatorPurple.GetCurrentAnimatorStateInfo(0).IsName("PurpleAppear"))
        {
            purpleInfrontSpriteRenderer.enabled = false;
        }
        else
        {
            purpleInfrontSpriteRenderer.enabled = true;
        }

        if (animatorGreen.GetCurrentAnimatorStateInfo(0).IsName("GreenAppear"))
        {
            greenInfrontSpriteRenderer.enabled = false;
        }
        else
        {
            greenInfrontSpriteRenderer.enabled = true;
        }
    }

    public void PurpleAppear()
    {
        animatorPurple.SetTrigger("PurpleAppearTrigger");
    }
    public void GreenAppear()
    {
        animatorGreen.SetTrigger("GreenAppearTrigger");
    }
}
