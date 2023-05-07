using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public AudioClip CoinSesi; //ses dosyası
    private static int score = 0; //puan değeri
    public Text ScoreText;


    #region Coine dokunmak
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))//tagi player olan obje coine triggerlandığında buraya girer
        {
            score += 10;
            AudioSource.PlayClipAtPoint(CoinSesi, transform.position);
            Destroy(gameObject);
            UpdateScoreText(); //puanı text nesnesinde gösterme
            PlayerPrefs.SetInt("Score", score); //Score'u PlayerPrefs'a kaydet
        }
    }
    #endregion

    #region Score'u updateleme
    public void UpdateScoreText()
    {
        ScoreText.text = score.ToString(); //ScoreTextin textine ulaşıp,stringe çevirilen score değişkeninin yazar.
    }
    #endregion

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0); //Score'u PlayerPrefs'tan yükle veya varsayılan olarak sıfır ata
        UpdateScoreText(); //puanı text nesnesinde göster
        
    }


    void OnDestroy()
    {
        //OnDestroy methodu nesne yokedilmeden önce yapılması gereken işlemleri yapan bir fonksiyondur.Nesne yok edildiğinde çağırılan özel bir fonksiyondur.
        PlayerPrefs.Save(); //Değişiklikleri PlayerPrefs'a kaydet
    }

    public static void SlimeİsDead(bool slime)
    {
        if (Enemies.isDead)
        {
            Debug.Log("enemyscorearttırma ifine girdi");
            score += 100;
            PlayerPrefs.GetInt("Score",score);
            PlayerPrefs.Save();
        }
    }
}
