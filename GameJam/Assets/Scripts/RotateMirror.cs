using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{
    [Header("Mirror Variables")]
    [SerializeField] float degreesOfRotation;
    [SerializeField] float rotationTime;

    public float range;
    [SerializeField] int state = 0;

    // Private Variables
    bool rotating;
    List<Vector3> rotations;

    // Start is called before the first frame update
    void Start()
    {
        rotating = false;

        rotations = new List<Vector3>();

        var rotation1 = transform.rotation.eulerAngles;
        var rotation2 = transform.rotation.eulerAngles;

        rotation1.y += degreesOfRotation;
        rotation2.y -= degreesOfRotation;

        rotations.Add(transform.rotation.eulerAngles);
        rotations.Add(rotation1);
        rotations.Add(rotation2);

        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(rotation1);
        Debug.Log(rotation2);
    }

    public void Rotate()
    {
        if(!rotating) StartCoroutine(TurnMirror());
    }


    IEnumerator TurnMirror()
    {   
        Debug.Log("Turning Mirror");
        rotating = true;
        float timeElapsed = 0;
        IncrementState();

        var nextStateRotation = Quaternion.Euler(rotations[state]);

        while(timeElapsed <= rotationTime)
        {
            timeElapsed += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, nextStateRotation , timeElapsed / rotationTime);

            yield return null;
        }

        rotating = false;
        yield return null;
    }

    public void IncrementState()
    {
        state++;
        if(state >= 3) state = 0;
    }
}
