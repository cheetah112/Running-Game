using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetechHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Game Over");
            GameManager.Instance.EndGame();
        }
    }
}
