using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private string mothName;
    private string relationship;
    private bool isGameStarted = false;
    public void UpdateName(string value)
    {
        Debug.Log("Update name" + value);
        mothName = value;
    }
    public void UpdateRelationship(string value)
    {
        Debug.Log("Update relationship" + value);
        relationship = value;
    }
    public void StartGame()
    {
        isGameStarted = true;
        gameObject.SetActive(false);
    }
}
