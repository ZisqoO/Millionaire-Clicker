using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameManager : MonoBehaviour
{
    public Image notificationImage;
    public TextMeshProUGUI mainBalance;
    public TextMeshProUGUI comeBackIncome;
    public float mainBalanceValue;
    public GameObject managerTab;
    public List<BlockSystem> blockList = new List<BlockSystem>();
    public List<BlockSystem> ActiveblockList = new List<BlockSystem>();
    float totalCycleIncome = 0;
    public GameObject RestartGamePanel;
    public TimeManager timeManager;
    public bool isFirstRun = false;
    bool managerCount = false;
    void Start()
    {

        //RestartGamePanel.gameObject.SetActive(false);
        managerCount = PlayerPrefs.GetInt(nameof(managerCount)) == 1;
        //isFirstRun = PlayerPrefs.GetInt(nameof(isFirstRun)) == 1;

       

        if (PlayerPrefs.HasKey("mainBalance"))
        {
            mainBalanceValue = PlayerPrefs.GetFloat("mainBalance");
        }
        else
        {
            mainBalanceValue = 49;
        }



        isFirstRun = true;
        PlayerPrefs.SetInt(nameof(isFirstRun), isFirstRun ? 1 : 0);
        Debug.Log("isFirstRun: " + isFirstRun);
        mainBalance.text = mainBalanceValue.ToString("F2");
        managerTab.SetActive(false);
        LoadGame();
        BlockUpdate();
        IncomeCalculator();
        //if (PlayerPrefs.GetInt(nameof(isFirstRun)) == 1 && managerCount == true)
        //{
        //    RestartGamePanel.gameObject.SetActive(true);
        //}
        //PlayerPrefs.DeleteKey(nameof(isFirstRun));
        //Debug.Log("isFirstRun Value: " + PlayerPrefs.GetInt(nameof(isFirstRun)));
    }

    
    void Update()
    {
        
        if(blockList.Count > 0 )
        {
            notificationImage.gameObject.SetActive(true);
        }
        else
        {
            notificationImage.gameObject.SetActive(false);
        }
        
    }
    public void ManagerPanelButton()
    {
        managerTab.gameObject.SetActive(true);
    }
    public void ManagerPnlExitButton()
    {
        managerTab.gameObject.SetActive(false);
    }
    public void BlockBalanceUpdate(BlockSystem block)
    {
        if(block.isActivationButtonClicked)
        {
            block.activationButton.gameObject.SetActive(false);
        }
        if (mainBalanceValue >= block.upgradeButtonValue)
        {
            block.upgradeButton.interactable = true;
            
        }
        else
        {
            block.upgradeButton.interactable = false;
        }


        if (mainBalanceValue >= block.activationButtonValue && block.isActivationButtonClicked == false)
        {
            block.activationButton.interactable = true;
        }
        else
        {
            block.activationButton.interactable = false;
        }

        if (mainBalanceValue >= block.managerPriceValue && block.isActivationButtonClicked == true && block.isManagerBought == false)
        {
            Color activeColor = new Color(72f / 255, 126f / 255, 176f /255);
            block.managerButton.interactable = true;
           
            if (!blockList.Contains(block))
            {
                blockList.Add(block);
                block.managerButton.transform.GetChild(0).GetComponent<Image>().color = activeColor;
            }
        }
        else if (mainBalanceValue < block.managerPriceValue)
        {
            block.managerButton.interactable = false;
            Color disableColor = new Color(72f / 255, 126f / 255, 176f / 255);
            if (blockList.Contains(block))
            {

                blockList.Remove(block);
                block.managerButton.transform.GetChild(0).GetComponent<Image>().color = disableColor;
            }
        }
        
    }
    
    public void BlockUpdate()
    {
        for (int i = 0; i < ActiveblockList.Count; i++)
        {
            BlockBalanceUpdate(ActiveblockList[i]);
            ActiveblockList[i].SaveData(ActiveblockList[i].name);

        }
        

    }
    public void MainBalanceUpdate()
    {
        mainBalance.text = mainBalanceValue.ToString("F2");
        PlayerPrefs.SetFloat("mainBalance", mainBalanceValue);
        
    }
    
    public void LoadGame()
    {
        for (int i = 0; i < ActiveblockList.Count; i++)
        {

            ActiveblockList[i].LoadData(ActiveblockList[i].name);

        }
    }
    
    public void IncomeCalculator()
    {
        
        for (int i = 0; i < ActiveblockList.Count; i++)
        {
            if(ActiveblockList[i].isManagerBought == true)
            {
                managerCount = true;
                PlayerPrefs.SetInt(nameof(managerCount), managerCount ? 1 : 0);
                ActiveblockList[i].ReopenApp();
            }
            totalCycleIncome += ActiveblockList[i].incomeFromCycle;

            Debug.Log(totalCycleIncome);
            Debug.Log("managerCount: " + managerCount);
        }
        
        //comeBackIncome.text = "$ " + totalCycleIncome.ToString();
        if (PlayerPrefs.GetInt(nameof(isFirstRun)) == 1 && managerCount == true)//************************
        {
            RestartGamePanel.gameObject.SetActive(true);
            comeBackIncome.text = "$ " + totalCycleIncome.ToString();
        }
        Debug.Log("totalCycleIncome: " + totalCycleIncome);
    }
    public void ComeBackAcceptButton()
    {
        RestartGamePanel.gameObject.SetActive(false);
        mainBalanceValue += totalCycleIncome;
        MainBalanceUpdate();
    }
}
