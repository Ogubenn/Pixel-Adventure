using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region  Flag objesine dokunduğunda bir sonraki level yükleme
public class Flag : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D Flag) 
    {
        if (Flag.gameObject.CompareTag("Flag"))//Tagi Flag olan objeye carptığında LoadNextSceene fonksiyonunu çağır.
        {
            LoadNextScene();
        }
    }
     public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        //GetAktiveScene ile o an bulunduğumuz sceenin indexini alırız. + 1 ile toplayıp nextSceneIndex değişkenine eşitleriz.Ve sonra SceeneManagerda LoadScene ile o indexteki sceene çağırırz.
        if(nextSceneIndex + 1 == 12)
        {
            SceneManager.LoadScene("Level0");
        }
    }
}//class
#endregion
