using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLight : MonoBehaviour
{
    public Material material;
    LightSource source;

    void Update()
    {
        Destroy(GameObject.Find("Light Source"));

        source = new LightSource(gameObject.transform.position, gameObject.transform.right, material);
    }
}
