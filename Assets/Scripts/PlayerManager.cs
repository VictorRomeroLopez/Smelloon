using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] LevelManager lM;

    Rigidbody2D rB;
    private float speed = 5;
    private Vector2 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        rB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += transform.up * Time.fixedDeltaTime*speed;
            rB.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rB.velocity = -Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rB.velocity = -Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rB.velocity = Vector2.right * speed;
        }
        else
        {
            rB.velocity = Vector2.zero;
        }
    }

    public void OnReset()
    {
        transform.position = _startPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Door"))
        {
            lM.ScapedAtTime();
        }
    }

}
