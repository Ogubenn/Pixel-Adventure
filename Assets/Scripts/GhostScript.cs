using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostScript : MonoBehaviour
{
    float x,y;
    public float Sure = 3f;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource PlayerHitSound;
    private Renderer objectRenderer;//bir nesnenin ekranda görünmesini sağlayan bir bileşendir.herhangi bir nesne, parçacık renderlayıcısına erişmek için kullanılır.Renderer komponenti performans açısından çok sağlıklı değildir.Çünkü verdiğimiz süre boyunda objecti sürekli tekrardan renderlamak zorunda kalır.Optimizasyon açısından pek sağlıklı değil.
    public int geriGit = 5;

    #region Awake
    public void Awake() 
    {
         objectRenderer = GetComponent<Renderer>();//Renderer componentine ulaştık.
    }
    #endregion

    private void Start()
    {
        StartCoroutine(GhostVisibility());
    }
       

#region Ghostun aralıklarla yok olup var olma işlemi
    private IEnumerator GhostVisibility()
    {
        /*"Enumerator" nesneleri, belirli bir koleksiyonda bulunan öğeleri teker teker döndüren ve bu işlemi yaparken işlemciyi boşa harcamadan diğer işlemlere geçiş yaparak performansı artıran nesnelerdir. */
        while (true)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
            yield return new WaitForSeconds(Sure);//wait for secons coroutine fonksiyonunda belirli bir süre beklemeyi sağlar.
            
            /*Yield = bir işlemi geçici olarak durdurmak ve daha sonra devam ettirmek için kullanılır. Bu işlem, işlemciyi boşa harcamadan diğer işlemlere geçiş yaparak performansı artırabilir.*/
        }
            
    }
#endregion

#region Ghostun Playerı Dashleme 
//AddForce metodu,bir nesneye belirli bir kuvvet uygulamak için kullanılır.Rigidbody bileşenine sahip bir nesne üzerinde çağrılır.Biz bu regionda playerımıza enemye dokundupu zaman geri gitmesi için kullandık.


 void OnCollisionEnter2D(Collision2D force)
{
    //force parametresi,çarpışmanın kendisi hakkında bilgi sağlayan bir parametredir.Bu nesne,iki fiziksel nesne arasındaki çarpışma hakkında bilgiler içerir, örneğin çarpışma noktası,vektörü temas noktası vb. Bu bilgileri kullanarak, çarpışmadan etkilenen nesnelere müdahale müdahale edilebilir hale geliyor.
    if (force.gameObject.tag == "Player")
    {
        Debug.Log("dokundu");
        Rigidbody2D playerRigidbody = force.gameObject.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            Debug.Log("ife girdi");
            Vector2 forceDirection = (force.transform.position - transform.position).normalized;
            playerRigidbody.AddForce(forceDirection * geriGit, ForceMode2D.Impulse);

            /*"force" adlı bir nesnenin konumu ile kendi konumunun farkını alarak, yön vektörünü "forceDirection" değişkenine atar. Daha sonra, "geriGit" değişkeninin değeri ile çarpılmış "forceDirection" vektörü, "ForceMode2D.Impulse" kullanarak "playerRigidbody" üzerinde bir itme kuvveti olarak uygulanır.*/

            /*ForceMode2D.Impulse = Unity'deki fizik motorunda kullanılan bir kuvvet uygulama modudur. Bu mod, bir Rigidbody2D nesnesine uygulanacak kuvvetin, nesneye anlık olarak uygulanmasını sağlar.*/

            /*Impulse "Impulse", bir nesneye bir anlık kuvvet uygulamak için kullanılan bir fizik terimidir. */
        }
    }
}
#endregion
}




