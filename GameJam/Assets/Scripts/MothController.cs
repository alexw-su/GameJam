using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
    List<Vector3> mothTargets = new List<Vector3>();
    List<Vector3> allLastTargets = new List<Vector3>();
    int nextTargetIndex = 0;
    //singleton
    public static MothController instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.TryGetComponent(out NavMeshAgent agent)) return;
        _agent = agent;

        if (_target != null) _agent.destination = _target.position;
    }

    // For Debugging
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _agent.destination);
        //Debug.Log("Distance to target: " + distanceToTarget);
        if (nextTargetIndex != -1 && distanceToTarget < _agent.stoppingDistance)
        {
            StartMoving();
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        _agent.destination = newTarget.position;
        _target = newTarget;
    }
    public void SetNewTargets(List<Vector3> destinations)
    {
        if (!allLastTargets.SequenceEqual(destinations))
        {
            allLastTargets = destinations;
            mothTargets = destinations.Count > 1
                ? destinations.GetRange(1, destinations.Count - 1)
                : destinations;
            nextTargetIndex = GetNearestTargetIndex();
            StartMoving();
        }
    }
    public void StartMoving()
    {
        if (mothTargets.Count == 0) return;
        _agent.destination = mothTargets[nextTargetIndex];
        //mothTargets.RemoveAt(nextTargetIndex);
        if (nextTargetIndex + 1 < mothTargets.Count)
        {
            nextTargetIndex++;
        }
        else
        {
            nextTargetIndex = -1;
        }
        //ChangeTarget(mothTargets[nextTargetIndex]);
        //mothTargets.Remove(mothTargets.);
    }
    public int GetNearestTargetIndex()
    {
        float minDistance = Mathf.Infinity;
        int nearestIndex = 0;
        for (int i = 0; i < allLastTargets.Count - 1; i++)
        {
            float distance = Vector3.Distance(transform.position, allLastTargets[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }
        return nearestIndex;
    }

}
