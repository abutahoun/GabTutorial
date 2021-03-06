﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateControls();
        updateAnimator();

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void updateAnimator()
    {
        anim.SetFloat("Speed", Math.Abs(rb.velocity.x));
    }

    private void UpdateControls()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        horizontalInput *= speed;
        rb.velocity = new Vector2(horizontalInput, rb.velocity.y);


    }
}
