using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float smoothFactor;
    public Vector3 offset;
    public Vector3 minValue, maxValue;
    //public float damping;
    //private Vector3 velocity = Vector3.zero;
    void LateUpdate ()
    {
        /* Vector3 movePosition = target.position + offset;
         transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);*/
        Vector3 targetposition = target.position + offset;
        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetposition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetposition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetposition.z, minValue.z, maxValue.z));

        Vector3 smoothposition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothposition;

    }

}
