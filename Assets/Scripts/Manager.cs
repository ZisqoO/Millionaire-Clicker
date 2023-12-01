using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameManager gameManager;
    //public BlockSystem blockSystem;
   
    public float managerPriceValue;
    Button managerButton;
    private void Awake()
    {
        managerButton = gameObject.GetComponent<Button>();

        gameManager.notificationImage.enabled = false;
    }
    void Start()
    {
        managerButton.interactable = false;
        
        
    }

    
    void Update()
    {
        
    }
    //main balance manager fiyatýna eþit olunca buton interractible olsun. Ýnteractible olunca da profile bannerdaki manager ikonuun üstünde notification sembolu yansýn
    //interactible olan tüm butonlarý bir listeye eklemek lazým. Listede herhangi bir eleman olunca da notification sembolünün yanmasý lazým. Liste boþ ise sembol yok.
}
