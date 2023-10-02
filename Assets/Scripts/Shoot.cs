using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefabs;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.N)){
            var bullet = Instantiate(bulletPrefabs);
            bullet.transform.position = shootPos.position;
        }
    }
}
