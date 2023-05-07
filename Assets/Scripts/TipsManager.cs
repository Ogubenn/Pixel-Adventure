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
            int randomIndex = Random.Range(0, tips.Length);
            tipsText.text = tips[randomIndex];
            yield return new WaitForSeconds(5f);
        }
    }
}
