using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BlockSystem : MonoBehaviour
{
    
    
    public ProgressBar progressBar;
    public GameManager gameManager;
    public TextMeshProUGUI iconLevelText;
    public TextMeshProUGUI iconLevelCapText;
    public TextMeshProUGUI upgradeButtonText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI progressBarText;
    public TextMeshProUGUI activationButtonPriceText;

    public Button upgradeButton;
    public Button iconButtonObj;
    public Button activationButton;
    public Button managerButton;

    float iconLevelTextValue;
    float iconLevelCapTextValue;
    public float progressBarTextValue;

    float reservedPBValue;

    public float managerPriceValue;
    public float countdownValue;
    public float upgradeButtonValue;
    public float activationButtonValue;
    public bool isCountdowning = false;
    public bool isManaged = false;
    private void Awake()
    {
        Awaking();
    }
    void Start()
    {
        
        managerButton.interactable = false;
        reservedPBValue = progressBarTextValue;
        //activationButton.interactable = false;


    }
    void Update()
    {

        


    }
    public void IconButton()
    {
        iconButtonObj.interactable = false;
        isCountdowning = true;
        Countdown();
    }
    public void Countdown()
    {
        StartCoroutine(CountdownTimer());
        
    }
    IEnumerator CountdownTimer()
    {
        float tempCountValue = countdownValue;
 
        while (true)
        {
            if (tempCountValue > 0)
            {
                tempCountValue--;
                countdownText.text = tempCountValue.ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                gameManager.mainBalanceValue += progressBarTextValue;
                gameManager.BalanceUpdate();
                ManagerCheck();
                BalanceCheck();
                isCountdowning = false;
                iconButtonObj.interactable = true;
                progressBar.progressSlider.value = 0;
                countdownText.text = countdownValue.ToString();
                break;
            }
            
        }
        

    }
    public void UpgradeButton()
    {
        gameManager.mainBalanceValue -= upgradeButtonValue;
        gameManager.BalanceUpdate();
        ManagerCheck();
        BalanceCheck();
        progressBarTextValue += reservedPBValue;
        progressBarText.text = progressBarTextValue.ToString("F2");
        
        float randomValue = Random.Range(1.12f, 1.15f);
        upgradeButtonValue *= randomValue;
        upgradeButtonText.text = upgradeButtonValue.ToString("F2");
        
        iconLevelTextValue++;
        iconLevelText.text = iconLevelTextValue.ToString();

        if(iconLevelTextValue == iconLevelCapTextValue)
        {
            iconLevelCapTextValue += 25;
            iconLevelCapText.text = iconLevelCapTextValue.ToString();
            countdownValue *= 0.9f;
        }
    }
    void Awaking()
    {
        activationButtonPriceText.text = activationButtonValue.ToString("F2");
        upgradeButtonText.text = upgradeButtonValue.ToString("F2");
        countdownText.text = countdownValue.ToString();
        progressBarText.text = progressBarTextValue.ToString("F2");
        iconLevelTextValue = 1;
        iconLevelText.text = iconLevelTextValue.ToString();
        iconLevelCapTextValue = 25;
        iconLevelCapText.text = iconLevelCapTextValue.ToString();
        gameManager.BalanceUpdate();
        ManagerCheck();
        BalanceCheck();
        

    }
    public void ActivationButton()
    {
        gameManager.mainBalanceValue -= activationButtonValue;
        gameManager.BalanceUpdate();
        ManagerCheck();
        BalanceCheck();
        activationButton.gameObject.SetActive(false);
    }
    IEnumerator Managing()
    {
        isCountdowning = true;
        float tempCountValue = countdownValue;

        while (true)
        {
            if (tempCountValue > 0)
            {
                tempCountValue--;
                countdownText.text = tempCountValue.ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                gameManager.mainBalanceValue += progressBarTextValue;
                isCountdowning = false;
                progressBar.progressSlider.value = 0;
                countdownText.text = countdownValue.ToString();
                gameManager.BalanceUpdate();
                ManagerCheck();
                BalanceCheck();
                break;
            }
            

        }
        StartCoroutine(Managing());


    }
    public void ManagerBuy()
    {
        gameManager.mainBalanceValue -= managerPriceValue;
        gameManager.BalanceUpdate();
        Destroy(managerButton.gameObject);
        gameManager.blockList.Remove(gameObject.name);
        iconButtonObj.interactable = false;
        StartCoroutine(Managing());
        ManagerCheck();
        BalanceCheck();
    }
    public void ManagerCheck()
    {
        if (gameManager.mainBalanceValue >= managerPriceValue)
        {

            Debug.Log("IF e girdi");
            managerButton.interactable = true;
            if (!gameManager.blockList.Contains(gameObject.name))
            {
                gameManager.blockList.Add(gameObject.name);
            }
            
        }
        else if (gameManager.mainBalanceValue < managerPriceValue)
        {
            Debug.Log("ELSE e girdi");
            managerButton.interactable = false;
            
        }
    }
    public void BalanceCheck()
    {
        if (gameManager.mainBalanceValue >= upgradeButtonValue)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }


        if (gameManager.mainBalanceValue >= activationButtonValue)
        {
            activationButton.interactable = true;
        }
        else
        {
            activationButton.interactable = false;
        }
    }

}
