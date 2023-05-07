using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    

    private Animator enemyAnimator;
    public static Animator playerAnimator;
    public GameObject headCollider; // Düşmanın kafası için bir kollider
    public float EnemyDestroy = 4f; // Enemy Destroy olma süresi
    public static float  PlayerDestroy = 4f; // Player Destroy olma süresi
     public static bool isDead = false; // İsDead boolu

     private int EnemyDeadScore = 0;

     
     [SerializeField] AudioSource PlayerHitSound;
     [SerializeField] AudioSource EnemyHitSound;
     [SerializeField] GameObject oyuncu;

#region Awake
    public void Awake() 
    {
        /* Unity oyun motorunda bir bileşen (component) oluşturulduğunda veya sahneye eklendiğinde otomatik olarak çağrılan bir fonksiyondur. Bu fonksiyon, bir nesnenin bileşenlerine erişmek, nesnenin özelliklerini ve parametrelerini ayarlamak, önceden hazırlık işlemleri yapmak ve bileşenleri inşa etmek için kullanılır. Starttan önce çalışır.*/

        oyuncu = GameObject.FindWithTag("Player");//zaten yukarıda object oluşturdun unity içinde atayabilirsin.Optimizasyon için sil ,gereksiz işlem.
        enemyAnimator = GetComponent<Animator>();
        playerAnimator = oyuncu.GetComponent<Animator>();
    }
#endregion

    void OnCollisionEnter2D(Collision2D collision)
{
    #region Slime Ölme
    if (collision.gameObject.CompareTag("Player"))
    {   
        
        if (collision.gameObject.GetComponent<Collider2D>().IsTouching(headCollider.GetComponent<Collider2D>()))
        {
            Debug.Log("Düşman Öldürme Çalıştı.");
            EnemyHitSound.Play();
            isDead = true;
            Coin.SlimeİsDead(isDead);
            enemyAnimator.Play("SlimeHit");
            Destroy(gameObject,EnemyDestroy);     
        }
    }
    #endregion

    #region Player Ölme
    if (collision.gameObject.CompareTag("Player") && !(collision.gameObject.GetComponent<Collider2D>().IsTouching(headCollider.GetComponent<Collider2D>())))
    {
        HealtMAnager.healt--;
        GameObject.Find("Player").transform.position = PlayerTransform.startPosition;
        if (HealtMAnager.healt == 0)
        {
            Debug.Log("Level0Yüklemeifinegirdi");
            PlayerHitSound.Play();
            Destroy(playerAnimator.gameObject,PlayerDestroy);
            SceneManager.LoadScene(0);
        }
    }
    #endregion

    }

    
}//class (Bu scripte çok fazla getcomponent çağırıldı optimizasyon için bunları azalt)
