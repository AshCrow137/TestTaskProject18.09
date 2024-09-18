using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject moneyPanel;
    [SerializeField]
    private TMP_Text moneyText;
    [SerializeField]
    private Image moneyImage;
    [SerializeField]
    private Color greenColor;   
    [SerializeField]
    private Color redColor;

    [SerializeField]
    private GameObject levelPanel;
    [SerializeField] 
    private TMP_Text pointsText;

    [SerializeField]
    private GameObject gameStartPanel;

    [SerializeField]
    private float moneyPanelShowTime = 3;

    [SerializeField]
    private Sprite GreenDollar;
    [SerializeField]
    private Sprite RedDollar;

    [SerializeField]
    private GameObject GameFinishPanel;
    [SerializeField]
    private TMP_Text resultPointsTextNormal;
    [SerializeField]
    private TMP_Text resultPointsTextX2;


    private float timeToShowLeft;
    private int moneyGet = 0;

    private bool bhandleFirstTouch = true;
    private void Start()
    {
        GlobalEventManager.StartEvent.AddListener(OnGameStarted);
        GlobalEventManager.PickUpEvent.AddListener(OnGetMoney);
        GlobalEventManager.FinishEvent.AddListener(OnGameFinished);
    }
    private void OnGameStarted()
    {
        levelPanel.SetActive(true);
        gameStartPanel.SetActive(false);
    }
    private void ShowMoneyPanel()
    {
        moneyPanel.SetActive(true);
        StartCoroutine(MoneyPanelShowTime());
    }
    private void OnGetMoney(int amount)
    {
        if (amount>0)
        {
            moneyImage.sprite = GreenDollar;
            timeToShowLeft = moneyPanelShowTime;
            moneyGet += amount;
            moneyText.text = moneyGet.ToString();
            moneyText.color = greenColor;
        }
        else if(amount == 0)
        {
            return;
        }
        else
        {
            timeToShowLeft = moneyPanelShowTime;
            moneyText.color = redColor;
            moneyGet = 0;
            moneyImage.sprite = RedDollar;
            moneyText.text = amount.ToString();
        }
        
        
        if (!moneyPanel.active)
        {
            ShowMoneyPanel();
        }
        pointsText.text = PlayerProperties.Instance.GetPoints().ToString();
        
    }

    private IEnumerator MoneyPanelShowTime()
    {
        
        while (timeToShowLeft>0)
        {
           
            timeToShowLeft-=Time.deltaTime;
            yield return null;
        }
        moneyPanel.SetActive(false );
        moneyGet = 0;
    }
    public void CheckStartGame()
    {
        if(DynamicJoystick.Instance.Horizontal>0.3|| DynamicJoystick.Instance.Horizontal<-0.3)
        {
            GlobalEventManager.InvokeStartEvent();
            bhandleFirstTouch = false;
        }
        
    }
    private void OnGameFinished()
    {
        GameFinishPanel.SetActive(true );
        resultPointsTextNormal.text = PlayerProperties.Instance.GetPoints().ToString();
        resultPointsTextX2.text = (PlayerProperties.Instance.GetPoints()*2).ToString();
        pointsText.text = "гюбепьемн";
        DynamicJoystick.Instance.gameObject.SetActive( false );

    }
    private void Update()
    {
        if(bhandleFirstTouch)
        {
            CheckStartGame();
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
