using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   public float bulletSpeed;
   public float timeDestroyBullet;
   
   private void Update() {
    transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
    timeDestroyBullet -= Time.deltaTime;
    if(timeDestroyBullet <= 0) Destroy(gameObject); 
   }
   private void OnCollisionEnter(Collision other) {
    other.gameObject.SetActive(false);
    Destroy(gameObject);
   }

}
