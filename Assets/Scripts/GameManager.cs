using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int distance;
    public float timeShoot;
    public bool isEndGame;
    public bool isPauseGame;
    public int coin;
    public float speedMove;
    void Start()
    {
        Instance = this;
        distance = 0;
        timeShoot = 0;
        speedMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpSpeed();
        if(timeShoot < 0) 
        {
           timeShoot = 0; 
           return; 
        }
        timeShoot -= 1 * Time.deltaTime;
    }
    protected void UpSpeed()
    {
        if(GameManager.Instance.distance % 5 == 0 && speedMove > 0) speedMove += Time.deltaTime;
    }
    public void StartGame()
    {
        speedMove = 5;
    }
    public void PauseGame()
    {
        if(isPauseGame == false)
        {
            Pause();
        }
        else
        {
            Remuse();
        }
    }
    public void Pause()
    {
        isPauseGame = true;
        Time.timeScale = 0;
    }

    public void Remuse()
    {
        isPauseGame = false;
        Time.timeScale = 1;
    }
    public void EndGame()
    {
        isEndGame = true;
        speedMove = 0;
        UIManager.Instance.LoseGame();
    }
}
