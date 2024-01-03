using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameManager gameManager; 
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
}
