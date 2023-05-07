using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public static Vector3 startPosition; // karakterin başlangıç konumu

    void Start()
    {
        startPosition = transform.position; // karakterin başlangıç konumunu kaydet
    }
}//class
