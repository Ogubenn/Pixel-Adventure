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

#region update
    private void Update() 
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);//GetAxis yatay veya dikey girdileri yakalamak için kullanılır.Normal değeri sıfırdır ama klavyeden tuşa basıldığı zaman negatif veya pozitif değer döndürür.Veloicty rigitbodyini hız değişkenini tutar.Sadece yatay eksende hareketini sağlar.
        transform.position += velocity * speedAmount * Time.deltaTime;//playerın pozisyonu velocityle ve bizim verdiğimiz float değerle çarpılır.Normal zamana uyarlanıp karaktermizin hareket etmesini sağlar.
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));//Speed parametresi yatay düzlemde eksi değer alabileceği için Horizontal değerin mutlak değerini kullanıyoruz.

        if (Input.GetButtonDown("Jump")&& !animator.GetBool("IsJumping"))
        {
            rgb.AddForce(Vector3.up * jumpAmount,ForceMode2D.Impulse);//Impulse anlık kuvvet uygular.
            animator.SetBool("IsJumping", true);
        }
        //Playerımızın sağa sola kafasını çevirmesi bakış işlemini yapar.Quaternion nesnelerin dönmesini temsil eder.Eular ise dönmmenin korrdinatları.
        if(Input.GetAxisRaw("Horizontal") == -1)
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        
        else if(Input.GetAxisRaw("Horizontal") == 1)
             transform.rotation = Quaternion.Euler(0f,0f,0f);

    }

    #endregion

    #region Isjumpingi groundla eşleme kontrol işemleri
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
    #endregion
}//class