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
    //main balance manager fiyat�na e�it olunca buton interractible olsun. �nteractible olunca da profile bannerdaki manager ikonuun �st�nde notification sembolu yans�n
    //interactible olan t�m butonlar� bir listeye eklemek laz�m. Listede herhangi bir eleman olunca da notification sembol�n�n yanmas� laz�m. Liste bo� ise sembol yok.
}
