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

#region Slime Ölme

    void OnCollisionEnter2D(Collision2D collision)
{
    
    if (collision.gameObject.CompareTag("Player"))
    {   
        
        if (collision.gameObject.GetComponent<Collider2D>().IsTouching(headCollider.GetComponent<Collider2D>()))//Collison nesnesine ait olan yani playerın colliderıyla düşmanın head colliderı arasında temas varmı diye kontrol eder.Temas varsa true olur ve Düşman öölür.
        {
            //IsTouching fonksiyonu collidera sahip bir objenin,başka bir collidera sahip obje ile temas halinde olup olmadığının bilgisini verir.Phyisc kütüphanesinin parçasıdır.Boolendır,iki nesne temas halindeyse true döner.
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
        GameObject.Find("Player").transform.position = PlayerTransform.startPosition;//Playerımızı start pozisyonuna ışınlıyoruz.
        if (HealtMAnager.healt <= 0)
        {
            //Eğer healt 0 a eşit ve daha küçükse Level0 yüklenir Gameobject destroy olur.
            Debug.Log("Level0Yüklemeifinegirdi");
            PlayerHitSound.Play();
            Destroy(playerAnimator.gameObject,PlayerDestroy);
            SceneManager.LoadScene(0);
        }
    }
    #endregion

    }

    
}//class (Bu scripte çok fazla getcomponent çağırıldı optimizasyon için bunları azalt)
