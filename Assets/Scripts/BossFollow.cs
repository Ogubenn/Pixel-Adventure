using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFollow : MonoBehaviour
{
    public Transform playerTransform; // Takip edilecek karakterin Transform bileşeni
    public float moveSpeed = 3f; // Düşmanın hareket hızı
    public float attackDistance = 2f; // Düşmanın saldırı yapabileceği mesafe

    private Animator animator; // Düşmanın Animator bileşeni
    private Vector3 initialScale; // Düşmanın ilk ölçeği

    private int Can = 100;


    private void Start()
    {
        animator = GetComponent<Animator>(); // Düşmanın Animator bileşenini al
        initialScale = transform.localScale; // Düşmanın ilk ölçeğini kaydet
    }

    private void OnTriggerStay2D(Collider2D other) 
        
    {
        if (other.gameObject.name == "Player") // Düşmanın Player bileşenine girdiği zaman  
        {
            if (Can > 0) // Düşmanın Player ile çarpılma olasılığı var ise  
            {
                Can--;
                Debug.Log(Can);
                if(Can == 0)
                SceneManager.LoadScene("FinalLevel");
            }
        }
    }

    private void Update()
    {
        // Düşmanın pozisyonunu takip edilecek karakterin pozisyonuna doğru hareket ettirin
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Düşmanın yönünü takip edilecek karakterin pozisyonuna doğru ayarlayın
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }

        // Düşman player'a yeterince yakınsa atak animasyonunu oynat
        if (Vector2.Distance(transform.position, playerTransform.position) < attackDistance)
        {
            animator.SetBool("IsAttacking", true);


        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    
}


