using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistObjects : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
}
