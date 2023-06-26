using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Time = 8f;
    private Rigidbody2D rb;


    public void setDirection(Vector2 dir)
    {
        transform.up = dir;
        rb.velocity = new Vector2(dir.x * Speed, dir.y * Speed);
        // speed = speed * dir;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(rb.transform.right * Speed);
        Destroy(this.gameObject, Time);
    }

}
