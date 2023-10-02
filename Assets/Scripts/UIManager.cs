using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI uiDistance;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        uiDistance.SetText(GameManager.Instance.distance.ToString());
    }
}
