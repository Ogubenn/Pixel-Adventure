using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawScript : MonoBehaviour
{

     [SerializeField] AudioSource PlayerHitSound;
     [SerializeField] GameObject kan;
     public static Animator playerAnimator;

#region Sawın dokunma işlemleri
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "Player")
        {
            HealtMAnager.healt--;//can azalt
            GameObject.Find("Player").transform.position = PlayerTransform.startPosition;//pozisyonu başa sıfırla
            StartCoroutine(ShowKanFor3Seconds());

        }
        if (HealtMAnager.healt == 0)
        {
            Debug.Log("Level0Yüklemeifinegirdi");
            PlayerHitSound.Play();
            Destroy(playerAnimator.gameObject);
            SceneManager.LoadScene(0);
            
        }
    }

    #endregion

    #region Show blood
    private IEnumerator ShowKanFor3Seconds()
{
   kan.SetActive(true); // Kan spriteI true yap ekranda göster
    yield return new WaitForSeconds(1.5f); // 3 cm
    kan.SetActive(false); // kan spritını gizle
}
#endregion

}//class
