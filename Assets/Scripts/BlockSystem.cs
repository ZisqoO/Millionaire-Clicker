using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using Random = UnityEngine.Random;

[System.Serializable]
public class BlockSystemData
{
    public float iconLevelTextValue;
    public float iconLevelCapTextValue;
    public float progressBarTextValue;
    public float managerPriceValue;
    public float countdownValue;
    public float upgradeButtonValue;
    public float activationButtonValue;
    
    public bool isManagerBought;
    public bool isActivationButtonClicked;

    public Button upgradeButton;
    public Button iconButtonObj;
    
    public Button managerButton;
}
[Serializable]
public class BlockSystem : MonoBehaviour
{
    
    
    public ProgressBar progressBar;
    public GameManager gameManager;
    TextMeshProUGUI iconLevelText;
    TextMeshProUGUI iconLevelCapText;
    TextMeshProUGUI upgradeButtonText;
    TextMeshProUGUI countdownText;
    TextMeshProUGUI progressBarText;
    public TextMeshProUGUI activationButtonPriceText;

    public Button upgradeButton;
    public Button iconButtonObj;
    public Button activationButton;
    public Button managerButton;

    
    public float iconLevelTextValue;
    public float iconLevelCapTextValue;
    public float progressBarTextValue;

    float reservedPBValue;

    public float managerPriceValue;
    public float countdownValue;
    public float upgradeButtonValue;
    public float activationButtonValue;
    public bool isCountdowning = false;
    public bool isManagerBought = false;
    public bool isActivationButtonClicked = false;
    
    private void Awake()
    {
        
    }
    void Start()
    {
        Initialising();
        //LoadGame();
        //scriptableObject.LoadDataFromFile();
        //gameManager.LoadGame();
        //gameManager.BlockUpdate();


    }
    void Update()
    {

        


    }
    public void IconButton()
    {
        iconButtonObj.interactable = false;
        isCountdowning = true;
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
                if (tempCountValue > 60)
                {
                    float minutes = tempCountValue / 60;
                    float seconds = tempCountValue % 60;
                    countdownText.text = minutes.ToString() + " M " + seconds.ToString() + " S";
                }
                else
                {
                    countdownText.text = tempCountValue.ToString() + " S";
                }
              
                yield return new WaitForSeconds(1);
            }
            else
            {
                gameManager.mainBalanceValue += progressBarTextValue;
                gameManager.MainBalanceUpdate();
                
                isCountdowning = false;
                iconButtonObj.interactable = true;
                progressBar.progressSlider.value = 0;

                if (countdownValue > 60)
                {

                    float minutes = countdownValue / 60;
                    float seconds = countdownValue % 60;
                    countdownText.text = minutes.ToString() + " M " + seconds.ToString() + " S";
                }
                else
                {
                    countdownText.text = countdownValue.ToString() + " S";
                }
                
                gameManager.BlockUpdate();
                break;
            }
            
        }
        

    }
    public void UpgradeButton()
    {
        gameManager.mainBalanceValue -= upgradeButtonValue;
        
        
        progressBarTextValue += reservedPBValue;
        PlayerPrefs.SetFloat(nameof(progressBarTextValue), progressBarTextValue);
        progressBarText.text = progressBarTextValue.ToString("F2");
        
        
        float randomValue = Random.Range(1.12f, 1.15f);
        upgradeButtonValue *= randomValue;
        PlayerPrefs.SetFloat(nameof(upgradeButtonValue), upgradeButtonValue);
        upgradeButtonText.text = upgradeButtonValue.ToString("F2");
        
       
        iconLevelTextValue++;
        PlayerPrefs.SetFloat(nameof(iconLevelTextValue), iconLevelTextValue);
        iconLevelText.text = iconLevelTextValue.ToString();
        
        
        if (iconLevelTextValue == iconLevelCapTextValue)
        {
            iconLevelCapTextValue += 25;
            PlayerPrefs.SetFloat(nameof(iconLevelCapTextValue), iconLevelCapTextValue);
            iconLevelCapText.text = iconLevelCapTextValue.ToString();
            
            
            countdownValue *= 0.9f;
            PlayerPrefs.SetFloat(nameof(countdownValue), countdownValue);


        }
        gameManager.MainBalanceUpdate();
        gameManager.BlockUpdate();
    }
    public void ActivationButton()
    {
        gameManager.mainBalanceValue -= activationButtonValue;
        isActivationButtonClicked = true;
        PlayerPrefs.SetInt(nameof(isActivationButtonClicked), isActivationButtonClicked ? 1 : 0);
        if (isActivationButtonClicked)
        {
            activationButton.gameObject.SetActive(false);
        }
        
        
        gameManager.MainBalanceUpdate();
        gameManager.BlockUpdate();
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
                if (tempCountValue > 60)
                {
                    double minutes = tempCountValue / 60;
                    float seconds = tempCountValue % 60;
                    countdownText.text = minutes.ToString() +" M " + seconds.ToString() + " S";
                }
                else
                {
                    countdownText.text = tempCountValue.ToString() + " S";
                }
                //countdownText.text = tempCountValue.ToString() + " S";
                yield return new WaitForSeconds(1);
            }
            else
            {
                gameManager.mainBalanceValue += progressBarTextValue;
               
                isCountdowning = false;
                progressBar.progressSlider.value = 0;
                if(countdownValue > 60)
                {
                    
                    float minutes = countdownValue / 60;
                    float seconds = countdownValue % 60;
                    countdownText.text = minutes.ToString() + " M " + seconds.ToString() + " S";
                }
                else
                {
                    countdownText.text = countdownValue.ToString() + " S";
                }
                
                gameManager.MainBalanceUpdate();
                
                
                break;
            }
            

        }
        gameManager.BlockUpdate(); 
        StartCoroutine(Managing());


    }
    public void ManagerBuy()
    {
        isManagerBought =true;
        PlayerPrefs.SetInt(nameof(isManagerBought), isManagerBought ? 1 : 0);
        gameManager.mainBalanceValue -= managerPriceValue;
        gameManager.MainBalanceUpdate();
        Destroy(managerButton.gameObject);
        gameManager.blockList.Remove(this);
        iconButtonObj.interactable = false;
       
        StartCoroutine(Managing());
        gameManager.BlockUpdate();
        
    }
    
    void Initialising()
    {
        managerButton.interactable = false;
        reservedPBValue = progressBarTextValue;
        

        iconLevelText = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        iconLevelTextValue = float.Parse(iconLevelText.text);
        
        iconLevelCapText = gameObject.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        iconLevelCapTextValue = float.Parse(iconLevelCapText.text);

        upgradeButtonText = gameObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        upgradeButtonValue = float.Parse(upgradeButtonText.text);

        countdownText = gameObject.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        countdownValue = float.Parse(countdownText.text);

        progressBarText = gameObject.transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();
        progressBarTextValue = float.Parse(progressBarText.text);
        
        activationButtonPriceText = gameObject.transform.GetChild(5).GetChild(2).GetComponent<TextMeshProUGUI>();
        activationButtonValue = float.Parse(activationButtonPriceText.text);

    }
    public void BlockReset()
    {
        PlayerPrefs.DeleteAll();

    }
    //public void SaveData(string fileName)
    //{
    //    BlockSystemData data = new BlockSystemData();
    //    data.activationButtonValue = activationButtonValue;
    //    data.countdownValue = countdownValue;
    //    data.iconLevelCapTextValue = iconLevelCapTextValue;
    //    data.iconLevelTextValue = iconLevelTextValue;
       
    //    data.isManagerBought = isManagerBought;
    //    data.managerPriceValue = managerPriceValue;
    //    data.progressBarTextValue = progressBarTextValue;
    //    data.upgradeButtonValue = upgradeButtonValue;
    //    data.isActivationButtonClicked = isActivationButtonClicked;
        

    //string filePath = Application.persistentDataPath + "/" + fileName + ".json";
    //    string json = JsonUtility.ToJson(data);
    //    File.WriteAllText(filePath, json);

    //    Debug.Log(fileName);
    //}

    //// Verileri yüklemek için
    //public void LoadData(string fileName)
    //{
    //    string filePath = Application.persistentDataPath + "/" + fileName + ".json";

    //    if (File.Exists(filePath))
    //    {
    //        string json = File.ReadAllText(filePath);
    //        BlockSystemData data = JsonUtility.FromJson<BlockSystemData>(json);

    //        // Verileri geri yükleyin
    //        activationButtonValue = data.activationButtonValue;

    //        managerPriceValue = data.managerPriceValue;

    //        countdownValue = data.countdownValue;
    //        countdownText.text = countdownValue.ToString();
    //        Debug.Log("countdownValue: " + countdownValue);
    //        Debug.Log("countdownText: " + countdownText.name);

    //        iconLevelCapTextValue = data.iconLevelCapTextValue;
    //        iconLevelCapText.text = iconLevelCapTextValue.ToString();

    //        iconLevelTextValue = data.iconLevelTextValue;
    //        iconLevelText.text = iconLevelTextValue.ToString();

    //        progressBarTextValue = data.progressBarTextValue;
    //        progressBarText.text = progressBarTextValue.ToString("F2");

    //        upgradeButtonValue = data.upgradeButtonValue;
    //        upgradeButtonText.text = upgradeButtonValue.ToString("F2");

    //        isActivationButtonClicked = data.isActivationButtonClicked;

    //        isManagerBought = data.isManagerBought;
    //        if (isManagerBought)
    //        {
    //            Destroy(managerButton.gameObject);
    //            gameManager.blockList.Remove(this);
    //            iconButtonObj.interactable = false;
    //            StartCoroutine(Managing());
    //        }

    //    }
    //    else
    //    {
    //        Debug.LogWarning("Save file not found: " + filePath);
    //    }
    //}
    public void SaveGame()
    {
        PlayerPrefs.Save();
        Debug.Log("Save alýndý");
        Debug.Log(progressBarTextValue);
    }
    public void LoadGame()
    {
        float tempProgressBarTextValue = PlayerPrefs.GetFloat(nameof(progressBarTextValue));
        progressBarTextValue = tempProgressBarTextValue;
        Debug.Log(tempProgressBarTextValue);
        progressBarText.text = progressBarTextValue.ToString("F2");

        upgradeButtonValue = PlayerPrefs.GetFloat(nameof(upgradeButtonValue));
        upgradeButtonText.text = upgradeButtonValue.ToString("F2");

        iconLevelTextValue = PlayerPrefs.GetFloat(nameof(iconLevelTextValue));
        iconLevelText.text = iconLevelTextValue.ToString();

        iconLevelCapTextValue = PlayerPrefs.GetFloat(nameof(iconLevelCapTextValue));
        iconLevelCapText.text = iconLevelCapTextValue.ToString();

        countdownValue = PlayerPrefs.GetFloat(nameof(countdownValue));
        countdownText.text = countdownValue.ToString();



        isManagerBought = PlayerPrefs.GetInt(nameof(isManagerBought)) == 1;
        if (isManagerBought)
        {
            Destroy(managerButton.gameObject);
            gameManager.blockList.Remove(this);
            iconButtonObj.interactable = false;
            StartCoroutine(Managing());
        }

        isActivationButtonClicked = PlayerPrefs.GetInt(nameof(isActivationButtonClicked)) == 1;
    }
}
