using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image notificationImage;
    public TextMeshProUGUI mainBalance;
    public float mainBalanceValue;
    public GameObject managerTab;
    public List<string> blockList = new List<string>();
    
    void Start()
    {
        mainBalance.text = mainBalanceValue.ToString("F2");
        managerTab.SetActive(false);
    }

    
    void Update()
    {
        //mainBalance.text = mainBalanceValue.ToString("F2");
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
    public void BalanceUpdate()
    {
        mainBalance.text = mainBalanceValue.ToString("F2");
    }
   



}
