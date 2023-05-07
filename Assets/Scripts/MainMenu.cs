using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    #region PlayGame

    public void PlayGame()
    {
        //Performans açısından Scene managera index değer vermek veya sahne adı vermek sürekli sahne ismi ve index araması anlamına geliyor ve performans açısından kötü.O yuzden GetActiveScene kullanmak daha mantıklı
        HealtMAnager.healt = 3;
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Giriş yapıldı");
    }
    #endregion


    #region Quit

    public void Quit()
    {
        Debug.Log("Çıkış Yapıldı..");
        Application.Quit();
    }
    #endregion


    #region ReturnMainMEnu

    
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion


    #region Continue

    public void Continue()
    {
        //Kaydedilmiş son sahne bilgisini yükle
        int savedSceneIndex = PlayerPrefs.GetInt("SavedSceneIndex", 0);

        //Eğer kaydedilmiş sahne bilgisi mevcutsa, kaydedilmiş sahneye git, yoksa ilk sahneye git.
        SceneManager.LoadScene(savedSceneIndex);
    }

    #endregion

    private void OnDestroy()
    {   
        //OnDestroy metodu bi gameobject yok olduğunda oluşan özel fonksiyondur.
        // Oyuncunun son kaldığı sahne bilgisini kaydedin
        PlayerPrefs.SetInt("SavedSceneIndex", SceneManager.GetActiveScene().buildIndex);
    }

   public void SoundsMute()
{
    AudioListener mainCameraAudioListener = Camera.main.GetComponent<AudioListener>();
    if (mainCameraAudioListener != null)
    {
        mainCameraAudioListener.enabled = !mainCameraAudioListener.enabled;
    }
}

}//class
