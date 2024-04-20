using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] GameObject pointlightPrefab;
    public static LightManager _instance;

    void Awake()
    {
        _instance = this;
    }

    public GameObject GetPointlightPrefab()
    {
        return pointlightPrefab;
    }
}
