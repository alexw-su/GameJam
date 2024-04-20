using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothRotater : MonoBehaviour
{

    [SerializeField]
    private Camera MainCam;
    private Transform mytrans;

    void Start()
    {
        mytrans = GetComponent<Transform>();

        MainCam = Camera.main;
    }

    void Update()
    {
        mytrans.rotation = MainCam.transform.rotation;
    }
}
