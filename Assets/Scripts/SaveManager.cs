using UnityEngine;

public class SaveManager : MonoBehaviour
{

    //public BlockSystem lemonBlock;
    //public BlockSystem donutblock;
    
    void Start()
    {
        //if (PlayerPrefs.HasKey("LemonIconLevelTextValue") || PlayerPrefs.HasKey("DonutIconLevelTextValue"))
        //{
        //    LoadGame();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void SaveGame()
    //{
    //    PlayerPrefs.SetFloat("LemonProgressBarTextValue", lemonBlock.progressBarTextValue);
    //    PlayerPrefs.SetFloat("DonutProgressBarTextValue", donutblock.progressBarTextValue);

    //    PlayerPrefs.SetFloat("LemonCountdownValue", lemonBlock.countdownValue);
    //    PlayerPrefs.SetFloat("DonutCountdownValue", donutblock.countdownValue);

    //    PlayerPrefs.SetFloat("LemonUpgradeButtonValue", lemonBlock.upgradeButtonValue);
    //    PlayerPrefs.SetFloat("DonutUpgradeButtonValue", donutblock.upgradeButtonValue);

    //    PlayerPrefs.SetFloat("LemonIconLevelTextValue", lemonBlock.iconLevelTextValue);
    //    PlayerPrefs.SetFloat("DonutIconLevelTextValue", donutblock.iconLevelTextValue);

    //    PlayerPrefs.SetFloat("LemonIconLevelCapTextValue", lemonBlock.iconLevelCapTextValue);
    //    PlayerPrefs.SetFloat("DonutIconLevelCapTextValue", donutblock.iconLevelCapTextValue);

    //    PlayerPrefs.SetInt("LemonActivationButton", lemonBlock.activationButton.gameObject ? 1 : 0);
    //    PlayerPrefs.SetInt("DonutActivationButton", donutblock.activationButton.gameObject ? 1 : 0);

    //    PlayerPrefs.SetInt("LemonIconButtonObj", lemonBlock.iconButtonObj.interactable ? 1 : 0);
    //    PlayerPrefs.SetInt("DonutIconButtonObj", donutblock.iconButtonObj.interactable ? 1 : 0);

    //    PlayerPrefs.SetInt("LemonManagerButton", lemonBlock.managerButton.interactable ? 1 : 0);
    //    PlayerPrefs.SetInt("DonutManagerButton", donutblock.managerButton.interactable ? 1 : 0);

        

    //    PlayerPrefs.Save();
    //}
    //public void LoadGame()
    //{
    //    Debug.Log("SaveManager LoadGame Çalýþtý");
    //    float LemonCountdownValue = PlayerPrefs.GetFloat("LemonCountdownValue");
    //    lemonBlock.countdownValue = LemonCountdownValue;
    //    float DonutCountdownValue = PlayerPrefs.GetFloat("DonutCountdownValue");
    //    donutblock.countdownValue = DonutCountdownValue;

    //    float LemonUpgradeButtonValue = PlayerPrefs.GetFloat("LemonUpgradeButtonValue");
    //    lemonBlock.upgradeButtonValue = LemonUpgradeButtonValue;
    //    float DonutUpgradeButtonValue = PlayerPrefs.GetFloat("DonutUpgradeButtonValue");
    //    donutblock.upgradeButtonValue = DonutUpgradeButtonValue;

    //    float LemonIconLevelTextValue = PlayerPrefs.GetFloat("LemonIconLevelTextValue");
    //    lemonBlock.iconLevelTextValue = LemonIconLevelTextValue;
    //    float DonutIconLevelTextValue = PlayerPrefs.GetFloat("DonutIconLevelTextValue");
    //    donutblock.iconLevelTextValue = DonutIconLevelTextValue;

    //    float LemonIconLevelCapTextValue = PlayerPrefs.GetFloat("LemonIconLevelCapTextValue");
    //    lemonBlock.iconLevelCapTextValue = LemonIconLevelCapTextValue;
    //    float DonutIconLevelCapTextValue = PlayerPrefs.GetFloat("DonutIconLevelCapTextValue");
    //    donutblock.iconLevelCapTextValue = DonutIconLevelCapTextValue;

    //    float LemonProgressBarTextValue = PlayerPrefs.GetFloat("LemonProgressBarTextValue");
    //    lemonBlock.progressBarTextValue = LemonProgressBarTextValue;
    //    float DonutProgressBarTextValue = PlayerPrefs.GetFloat("DonutProgressBarTextValue");
    //    donutblock.progressBarTextValue = DonutProgressBarTextValue;

    //    if (PlayerPrefs.HasKey("LemonActivationButton"))
    //    {
    //        lemonBlock.activationButton.gameObject.SetActive(PlayerPrefs.GetInt("LemonActivationButton") == 1);
    //    }
    //    if (PlayerPrefs.HasKey("DonutActivationButton"))
    //    {
    //        donutblock.activationButton.gameObject.SetActive(PlayerPrefs.GetInt("DonutActivationButton") == 1);
    //    }

    //    if (PlayerPrefs.HasKey("LemonIconButtonObj"))
    //    {
    //        lemonBlock.iconButtonObj.gameObject.SetActive(PlayerPrefs.GetInt("LemonIconButtonObj") == 1);
    //    }
    //    if (PlayerPrefs.HasKey("DonutIconButtonObj"))
    //    {
    //        donutblock.iconButtonObj.gameObject.SetActive(PlayerPrefs.GetInt("DonutIconButtonObj") == 1);
    //    }

    //    if (PlayerPrefs.HasKey("LemonManagerButton"))
    //    {
    //        lemonBlock.managerButton.gameObject.SetActive(PlayerPrefs.GetInt("LemonManagerButton") == 1);
    //    }
    //    if (PlayerPrefs.HasKey("DonutManagerButton"))
    //    {
    //        donutblock.managerButton.gameObject.SetActive(PlayerPrefs.GetInt("DonutManagerButton") == 1);
    //    }

    //}
    public void Save(BlockSystem block)
    {
        PlayerPrefs.SetFloat(nameof(block.progressBarTextValue) , block.progressBarTextValue);
        Debug.Log("ProgressBarTextValue :" + block.name + " ve " + block.progressBarTextValue);

        PlayerPrefs.SetFloat(nameof(block.countdownValue), block.countdownValue);
        Debug.Log("CountdownValue :" + block.name + " ve " + block.countdownValue);

        PlayerPrefs.SetFloat(nameof(block.upgradeButtonValue), block.upgradeButtonValue);
        Debug.Log("upgradeButtonValue :" + block.name + " ve " + block.upgradeButtonValue);

        PlayerPrefs.SetFloat(nameof(block.iconLevelTextValue), block.iconLevelTextValue);
        Debug.Log("iconLevelTextValue :" + block.name + " ve " + block.iconLevelTextValue);

        PlayerPrefs.SetFloat(nameof(block.iconLevelCapTextValue), block.iconLevelCapTextValue);
        Debug.Log("iconLevelCapTextValue :" + block.name + " ve " + block.iconLevelCapTextValue);

        PlayerPrefs.SetInt(nameof(block.activationButton.gameObject), block.activationButton.gameObject ? 1 : 0);
        Debug.Log("activationButton :" + block.name + " ve " + block.activationButton.gameObject);

        PlayerPrefs.SetInt(nameof(block.iconButtonObj.interactable), block.iconButtonObj.interactable ? 1 : 0);
        Debug.Log("iconButtonObj :" + block.name + " ve " + block.iconButtonObj.interactable);

        PlayerPrefs.SetInt(nameof(block.managerButton.interactable), block.managerButton.interactable ? 1 : 0);
        Debug.Log("managerButton :" + block.name + " ve " + block.managerButton.interactable);
        PlayerPrefs.Save();
    }
    public void Load(BlockSystem block)
    {

        float CountdownValue = PlayerPrefs.GetFloat(nameof(block.countdownValue));
        block.countdownValue = CountdownValue;
        Debug.Log("CountdownValue :" + block.name + " ve " + block.countdownValue);

        float UpgradeButtonValue = PlayerPrefs.GetFloat(nameof(block.upgradeButtonValue));
        block.upgradeButtonValue = UpgradeButtonValue;
        Debug.Log("UpgradeButtonValue :" + block.name + " ve " + block.upgradeButtonValue);

        float IconLevelTextValue = PlayerPrefs.GetFloat(nameof(block.iconLevelTextValue));
        block.iconLevelTextValue = IconLevelTextValue;
        Debug.Log("IconLevelTextValue :" + block.name + " ve " + block.iconLevelTextValue);

        float IconLevelCapTextValue = PlayerPrefs.GetFloat(nameof(block.iconLevelCapTextValue));
        block.iconLevelCapTextValue = IconLevelCapTextValue;
        Debug.Log("IconLevelCapTextValue :" + block.name + " ve " + block.iconLevelCapTextValue);

        float ProgressBarTextValue = PlayerPrefs.GetFloat(nameof(block.progressBarTextValue));
        block.progressBarTextValue = ProgressBarTextValue;
        Debug.Log("ProgressBarTextValue :" + block.name + " ve " + block.progressBarTextValue);

        if (PlayerPrefs.HasKey(nameof(block.activationButton.gameObject)))
        {
            block.activationButton.gameObject.SetActive(PlayerPrefs.GetInt(nameof(block.activationButton.gameObject)) == 1);
        }
        if (PlayerPrefs.HasKey(nameof(block.iconButtonObj.interactable)))
        {
            block.iconButtonObj.gameObject.SetActive(PlayerPrefs.GetInt(nameof(block.iconButtonObj.interactable)) == 1);
        }
        if (PlayerPrefs.HasKey(nameof(block.managerButton.interactable)))
        {
            block.managerButton.gameObject.SetActive(PlayerPrefs.GetInt(nameof(block.managerButton.interactable)) == 1);
        }
    }
}
