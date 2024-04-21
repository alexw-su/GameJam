using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using System.Text.RegularExpressions;

public class EndText : MonoBehaviour
{
    public string textTemplate;
    private void Awake()
    {
        string name = PlayerPrefs.GetString("MothName");
        string relationship = PlayerPrefs.GetString("MothRelationship");


        string finalText = ReplacePlaceholders(textTemplate, name, relationship);
        gameObject.GetComponent<TMP_Text>().text = finalText;
    }
    private string ReplacePlaceholders(string template, string name, string relationship)
    {
        template = Regex.Replace(template, @"\{name\}", name);
        template = Regex.Replace(template, @"\{relationship\}", relationship);
        return template;
    }
}
