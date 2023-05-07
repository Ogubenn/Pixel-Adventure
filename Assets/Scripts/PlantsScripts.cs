using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantsScripts : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f; // Ateş etme aralığı
    private float nextFireTime = 0f; // Bir sonraki ateş zamanı



    void Update()
    {
        if(Time.time >= nextFireTime)
        {
            //Time.time oyun başladıktan sonra geçen süreyi saniye cinsinden belirtir.
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//UInstantiate parametreleri neyi oluşturcağımız,positionu ve rotationu.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.right * bulletSpeed, ForceMode2D.Impulse);//Impulse nesneye anlık olarak kuvvet uygular.
        Destroy(bullet, 5f);

        /*"Instantiate", Unity oyun motorunda yeni bir nesne veya öğe oluşturmak için kullanılan bir fonksiyondur. Bu fonksiyon, prefabsların oluşturur ve bu kopyayı sahneye veya hiyerarşiye ekler.*/
    }
}
