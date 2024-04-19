using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private string mothName;
    private string relationship;
    private bool isGameStarted = false;
    // singleton
    public static MenuManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
    public string GetMothName()
    {
        return mothName;
    }
    public string GetRelationship()
    {
        return relationship;
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
