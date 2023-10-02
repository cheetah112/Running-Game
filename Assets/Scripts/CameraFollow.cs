using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,transform.position.y,target.position.z),1000f);
    }
}
