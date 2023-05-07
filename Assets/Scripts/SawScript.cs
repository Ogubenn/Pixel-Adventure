using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawScript : MonoBehaviour
{

     [SerializeField] AudioSource PlayerHitSound;
     [SerializeField] GameObject kan;
     public static Animator playerAnimator;


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "Player")
        {
            HealtMAnager.healt--;
            GameObject.Find("Player").transform.position = PlayerTransform.startPosition;
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
    private IEnumerator ShowKanFor3Seconds()
{
   kan.SetActive(true); // Show the "kan" sprite
    yield return new WaitForSeconds(1.5f); // Wait for 3 seconds
    kan.SetActive(false); // Hide the "kan" sprite
}
}
