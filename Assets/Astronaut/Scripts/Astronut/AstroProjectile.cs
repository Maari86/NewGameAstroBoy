using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private int direction;
    private Rigidbody2D rb;

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }


    private void OnEnable()
    {
        Invoke("Hide", 2f);
    }

    private void Update()
    {
        transform.Translate(new Vector2(speed * direction * Time.deltaTime, 0f));
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
