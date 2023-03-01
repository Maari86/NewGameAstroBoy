using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronutMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(1, 1, 1);

        float VerticalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(VerticalInput * speed, body.velocity.x);

        if (VerticalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (VerticalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("Moving", VerticalInput != 0);
        anim.SetBool("UpDown", horizontalInput > 0);

        if (Input.GetMouseButton(0) && Input.GetKeyDown(KeyCode.DownArrow) && cooldownTimer > attackCooldown)
            Attack();

        if (Input.GetMouseButton(1) && Input.GetKeyDown(KeyCode.DownArrow) && cooldownTimer > attackCooldown)
            Collect();

        cooldownTimer += Time.deltaTime;



    }
    private void Attack()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float VerticalInput = Input.GetAxis("Horizontal");

        if (horizontalInput == 0 && VerticalInput == 0)
        {
            anim.SetTrigger("attack");
            cooldownTimer = 0;
        }

    }

    private void Collect()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float VerticalInput = Input.GetAxis("Horizontal");

        if (horizontalInput == 0 && VerticalInput == 0)
        {
            anim.SetTrigger("collect");
            cooldownTimer = 0;
        }

    }


    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}