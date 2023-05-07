using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtMAnager : MonoBehaviour
{
    public static int healt = 3;
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;
   
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < healt; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}//class
