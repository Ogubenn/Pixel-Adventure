using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    public Text tipsText;
    public string[] tips;

    void Start()
    {
        StartCoroutine(ShowTips());
    }

    IEnumerator ShowTips()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, tips.Length);//Random.Range belirtilen iki sayı arasında rastgele sayı üretir.Dizi uzunluğu ile 0 arasında rastegele sayı belirler.
            tipsText.text = tips[randomIndex];//texte rondom indexi yaz
            yield return new WaitForSeconds(5f);// 5 saniye bekle
        }
    }
}
