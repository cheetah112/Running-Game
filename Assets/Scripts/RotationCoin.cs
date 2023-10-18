using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(40*Time.deltaTime,0,0);
    }
}
