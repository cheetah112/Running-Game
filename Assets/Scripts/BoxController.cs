using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,40f*Time.deltaTime,0);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("CoinBox"))
            {
                int bonus = (int)Random.Range(10,20);
                UIManager.Instance.CoinBox(bonus);
                GameManager.Instance.coin += bonus;
            }
            if(gameObject.CompareTag("ShootBox"))
            {
                Debug.Log("Shoot");
                UIManager.Instance.ShootBox();
                GameManager.Instance.timeShoot += 16f;
            }
            if(gameObject.CompareTag("SpeedBox"))
            {
                UIManager.Instance.SpeedBox();
                GameManager.Instance.speedMove = 5f;
            }
            Destroy(gameObject);
        }
    }
}
