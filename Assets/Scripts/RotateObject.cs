using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public GameObject target;
    public float angle;
    private Quaternion startRotation;

    private void Start()
    {
        startRotation = target.transform.rotation;
    }

    public void ResetRotation()
    {
        target.transform.rotation = startRotation;
    }

    public void RotateLeft()
    {
        target.transform.Rotate(Vector3.up,angle);
    }

    public void RotateRight()
    {
        target.transform.Rotate(Vector3.down, angle);
    }

    public void RotateUp()
    {
        target.transform.Rotate(Vector3.right, angle);
    }

    public void RotateDown()
    {
        target.transform.Rotate(Vector3.left, angle);
    }
}
