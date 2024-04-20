using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EndButtonScript : MonoBehaviour
{

    //on trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Moth"))
        {
            LevelManager.instance.LevelCompleted();
        }
    }
}
