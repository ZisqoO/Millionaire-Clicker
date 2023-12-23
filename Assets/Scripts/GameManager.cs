using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameManager : MonoBehaviour
{
    //public SaveManager saveManager;
    public Image notificationImage;
    public TextMeshProUGUI mainBalance;
    public float mainBalanceValue;
    public GameObject managerTab;
    public List<BlockSystem> blockList = new List<BlockSystem>();
    public List<BlockSystem> ActiveblockList = new List<BlockSystem>();

 
    void Start()
    {


        //if (PlayerPrefs.HasKey("mainBalance"))
        //{
        //    mainBalanceValue = PlayerPrefs.GetFloat("mainBalance");
        //}
        //else
        //{
        //    mainBalanceValue = 49;
        //}




        mainBalance.text = mainBalanceValue.ToString("F2");
        managerTab.SetActive(false);
        LoadGame();
        BlockUpdate();

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

        if (mainBalanceValue >= block.managerPriceValue && block.isManagerBought == false)
        {
            block.managerButton.interactable = true;
            if (!blockList.Contains(block))
            {
                blockList.Add(block);

            }
        }
        else if (mainBalanceValue < block.managerPriceValue)
        {
            block.managerButton.interactable = false;
            if (blockList.Contains(block))
            {

                blockList.Remove(block);
            }
        }
        
    }
    public void BalanceReset()
    {
        PlayerPrefs.DeleteAll();
        mainBalanceValue = 49;
        PlayerPrefs.SetFloat("mainBalance", mainBalanceValue);
        PlayerPrefs.Save();
        mainBalance.text = mainBalanceValue.ToString("F2");
        Debug.Log(mainBalanceValue);
        managerTab.SetActive(false);
    }
    public void BlockUpdate()
    {
        for (int i = 0; i < ActiveblockList.Count; i++)
        {
            BlockBalanceUpdate(ActiveblockList[i]);
            //ActiveblockList[i].SaveData(ActiveblockList[i].name);
            ActiveblockList[i].SaveGame();

        }
        

    }
    public void MainBalanceUpdate()
    {
        mainBalance.text = mainBalanceValue.ToString("F2");
        PlayerPrefs.SetFloat("mainBalance", mainBalanceValue);
        
    }
    public void DeleteSaveData()
    {
        for (int i = 0; i < ActiveblockList.Count; i++)
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void LoadGame()
    {
        for (int i = 0; i < ActiveblockList.Count; i++)
        {

            //ActiveblockList[i].LoadData(ActiveblockList[i].name);
            ActiveblockList[i].LoadGame();

        }
    }
}
