using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bulletPrefabs;
    public float timeShoot;
    private void Update() {
        if(GameManager.Instance.timeShoot <=0) return;
        if(Input.GetKeyDown(KeyCode.N)){
            var bullet = Instantiate(bulletPrefabs);
            bullet.transform.position = shootPos.position;
        }
    }
}
