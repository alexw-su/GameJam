using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{


    PlayerActions input;
    NavMeshAgent agent;
    [Header("Movement")]
    [SerializeField] List<LayerMask> layers;
    public float lookRotationSpeed = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        input = new PlayerActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        //if (!MenuManager.instance.IsGameStarted() || LevelManager.instance.LevelCompletedScreenActive())
        //{
        //    return;
        //}
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {

            if (hit.transform.gameObject.tag == "Mirror")
            {
                if (hit.transform.gameObject.TryGetComponent(out RotateMirror mirror)) Debug.LogWarning("Found Script");

                var distanceToMirror = (transform.position - hit.transform.position).magnitude;

                Debug.Log(distanceToMirror);

                if (distanceToMirror <= mirror.range) mirror.Rotate();
            }
            else if (hit.transform.gameObject.tag == "Clickable")
            {
                agent.destination = hit.point;
            }
        }
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        if (input.Main.Look.IsPressed()) LookAtMouse();
    }

    void LookAtMouse()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var distance = (transform.position - Camera.main.transform.position).magnitude;

        transform.LookAt(ray.origin + ray.direction * distance);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }


}


