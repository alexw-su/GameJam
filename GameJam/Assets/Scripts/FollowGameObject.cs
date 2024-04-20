using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject: MonoBehaviour
{
    [Header("Target to Follow")]
    [SerializeField] Transform _target;

    [Header("Offsets")]
    [SerializeField] float _xOffset;
    [SerializeField] float _yOffset;
    [SerializeField] float _zOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position + new Vector3(_xOffset, _yOffset, _zOffset);
    }
}
