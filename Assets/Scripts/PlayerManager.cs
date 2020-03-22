using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rB;
    private float speed = 5;
    [SerializeField] LevelManager lM;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Door"))
        {
            lM.ScapedAtTime();
        }
    }

}
