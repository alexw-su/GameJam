using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MothController : MonoBehaviour
{
    [Header("Moth Variables")]
    [SerializeField] Transform _target;
    [SerializeField] float _radius;

    NavMeshAgent _agent;
    List<Vector3> mothTargets = new List<Vector3>();
    List<Vector3> allLastTargets = new List<Vector3>();
    int nextTargetIndex = -1;
    //singleton
    public static MothController instance;
    public GameObject testObject;
    [SerializeField] GameObject lightTemplate;
    List<GameObject> lights = new List<GameObject>();

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
    public void SetAnimation()
    {
        int index = PlayerPrefs.GetInt("HatIndex");
        Debug.Log("Set Animation" + index);
        Animator animator = gameObject.GetComponent<Animator>();
        if (index == 0)
        {
            index = Random.Range(1, 7);
        }
        animator.SetBool("Remote", index == 1);
        animator.SetBool("Abomination", index == 2);
        animator.SetBool("Fez", index == 3);
        animator.SetBool("Dino", index == 4);
        animator.SetBool("Tophat", index == 5);
        animator.SetBool("Crown", index == 6);
    }

    public void SetNewTargets(List<Vector3> destinations)
    {
        var manager = MenuManager.instance;
        var levelManager = LevelManager.instance;
        if (manager != null && levelManager != null)
        {
            if (!manager.IsGameStarted() || levelManager.LevelCompletedScreenActive())
            {
                return;
            }
        }

        if (!ListsAreEqual(allLastTargets, destinations))
        {
            allLastTargets = destinations;
            mothTargets = destinations.Count > 1
                ? destinations.GetRange(1, destinations.Count - 1)
                : destinations;
            nextTargetIndex = GetNearestTargetIndex();
            UpdateLights();
            StartMoving();
        }
    }
    void UpdateLights()
    {
        //destroy all items from lights before creating again
        foreach (var item in lights)
        {
            Destroy(item);
        }
        lights.Clear();
        foreach (var item in allLastTargets)
        {
            //GameObject newItem = Instantiate(lightTemplate, item);
            GameObject newItem = Instantiate(lightTemplate, item, Quaternion.identity);
            lights.Add(newItem);
        }
    }
    private bool ListsAreEqual(List<Vector3> list1, List<Vector3> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            // Check if the elements are "equal enough" (within a small tolerance)
            if (!Vector3ApproximatelyEqual(list1[i], list2[i]))
                return false;
        }

        return true;
    }
    private bool Vector3ApproximatelyEqual(Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(v1, v2) < 0.001f; // Adjust tolerance as needed
    }
    public void StartMoving()
    {
        if (mothTargets.Count == 0) return;
        _agent.destination = mothTargets[nextTargetIndex];
        if (testObject != null)
        {
            testObject.transform.position = mothTargets[nextTargetIndex];
        }
        //Debug.Log("New Destination" + mothTargets[nextTargetIndex]);
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
