using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public GameObject EnemyCollider;

    float speedAmount = 7f;
    float jumpAmount = 3f;

    public void Awake() 
    {
      rgb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump")&& !animator.GetBool("IsJumping"))
        {
            rgb.AddForce(Vector3.up * jumpAmount,ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        if(Input.GetAxisRaw("Horizontal") == -1)
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        
        else if(Input.GetAxisRaw("Horizontal") == 1)
             transform.rotation = Quaternion.Euler(0f,0f,0f);

    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
      if(collision.gameObject.name == "Ground")
      {
        animator.SetBool("IsJumping", false);
      }  
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Ground")
      {
        animator.SetBool("IsJumping", true);
      }  

        
    }
}//class