using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI 
        uiDistance,
        uiTimeShoot,
        uiCoin,
        CoinEffect,
        ShootEffect,
        SpeedEffect;

    public GameObject startMenu, tutorial, endGameImage, losePanel, BoxEffect;
    public Button buttonPauseGame;
    public Sprite pauseImage, resumeImage;
    void Start()
    {
        Instance = this;
        CoinEffect.enabled = false;
        ShootEffect.enabled = false;
        SpeedEffect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        uiDistance.SetText(GameManager.Instance.distance.ToString());
        int timeShoot = (int)GameManager.Instance.timeShoot;
        uiTimeShoot.SetText(timeShoot.ToString());
        if(GameManager.Instance.timeShoot <=0) uiTimeShoot.enabled = false;
        else uiTimeShoot.enabled = true;
        uiCoin.SetText(GameManager.Instance.coin.ToString());
    }
    public void StartGameOnClick(){
        GameManager.Instance.StartGame();
        startMenu.SetActive(false);
    }
    public void PauseGameOnClick(){
        GameManager.Instance.PauseGame();
        if(GameManager.Instance.isPauseGame == false){
            buttonPauseGame.image.sprite = pauseImage;
        }
        else{
            buttonPauseGame.image.sprite = resumeImage;
        }
    }
    public void OpenTutorialOnClick(){
        tutorial.SetActive(true);
    }
    public void CloseTutorialOnClick(){
        tutorial.SetActive(false);
    }
    public void PLayAgainOnClick(){
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitOnClick()
    {
        Application.Quit();
    }
    public void LoseGame()
    {
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        endGameImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        endGameImage.SetActive(false);
        losePanel.SetActive(true);
    }
    IEnumerator CoinBonus(int coin)
    {
        CoinEffect.SetText("+ " + coin + " Coin");
        BoxEffect.SetActive(true);
        CoinEffect.enabled = true;
        yield return new WaitForSeconds(2f);
        CoinEffect.enabled= false;
        BoxEffect.SetActive(false);
    }
    IEnumerator ShootBonus()
    {
        BoxEffect.SetActive(true);
        ShootEffect.enabled = true;
        yield return new WaitForSeconds(2f);
        ShootEffect.enabled= false;
        BoxEffect.SetActive(false);
    }
    IEnumerator SpeedBonus()
    {
        BoxEffect.SetActive(true);
        SpeedEffect.enabled = true;
        yield return new WaitForSeconds(2f);
        SpeedEffect.enabled= false;
        BoxEffect.SetActive(false);
    }
    
    public void CoinBox(int coin)
    {
        StartCoroutine(CoinBonus(coin));
    }
    public void ShootBox()
    {
        StartCoroutine(ShootBonus());
    } 
    public void SpeedBox()
    {
        StartCoroutine(SpeedBonus());
    }  
}
