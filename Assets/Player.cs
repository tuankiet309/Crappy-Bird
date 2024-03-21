using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ///////////////////////MovementInfo/////////////////
    [Header("MovementInfo")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDelay;
    private float jumpDelayCounter;
    [SerializeField] private Transform roof;
    //////////////////////PlayerInfo//////////////
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpDelayCounter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        RestrictMovement();
        JumpFunction();
    }

    private void JumpFunction()
    {
        jumpDelayCounter = jumpDelayCounter - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpDelayCounter < 0)
        {
            jumpDelayCounter = jumpDelay;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    private void RestrictMovement()
    {
        float playerY = transform.position.y;
        float clampedY = Mathf.Clamp(playerY, float.MinValue, roof.position.y);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        if(transform.position.y == roof.position.y) {
            rb.velocity = new Vector3(rb.velocity.x,0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Block")
        {
            GameManager.Instance.EndGame();
        }
    }
}
