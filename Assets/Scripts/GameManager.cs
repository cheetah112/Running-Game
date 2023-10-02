using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int distance;
    void Start()
    {
        Instance = this;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
