using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnCllisonEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Kılıç oyuncuya temas etti.");
            HealtMAnager.healt--; // Oyuncunun canını azalt
        }
    }
}