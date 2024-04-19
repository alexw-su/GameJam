using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MothController : MonoBehaviour
{
    [Header("Moth Variables")]
    [SerializeField] Transform _target;
    [SerializeField] float _radius;

    [Header("Test Variables")]
    [SerializeField] Transform _target1;
    [SerializeField] Transform _target2;
    [SerializeField] Transform _target3;
    [SerializeField] Transform _target4;

    NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.TryGetComponent(out NavMeshAgent agent)) return;
        _agent = agent;

        if(_target != null) _agent.destination = _target.position;
    }

    // For Debugging
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeTarget(_target1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeTarget(_target2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeTarget(_target3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeTarget(_target4);
    }

    public void ChangeTarget(Transform newTarget)
    {
        _agent.destination = newTarget.position;
    }
}
