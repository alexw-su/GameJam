using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_UI : MonoBehaviour
{
    public AudioSource asrc;
    public AudioClip sfx1, sfx2;

    public void Button_Sound()
    {
        asrc.clip = sfx1;
        asrc.Play();
    }
    public void Hat_Sound()
    {
        asrc.clip = sfx2;
        asrc.Play();
    }
}
