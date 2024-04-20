using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera _camera;

    [Header("Target to Follow")]
    [SerializeField] Transform _target;

    [Header("Offsets")]
    [SerializeField] float _xOffset;
    [SerializeField] float _yOffset;
    [SerializeField] float _zOffset;

    // Start is called before the first frame update
    void Start()
    {
        if(!gameObject.TryGetComponent(out Camera camera)) return;

        _camera = camera;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = _target.position + new Vector3(_xOffset, _yOffset, _zOffset);
    }
}
