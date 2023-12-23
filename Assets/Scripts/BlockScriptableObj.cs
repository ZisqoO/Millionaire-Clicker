
using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName = "NBlockSystemData", menuName = "Block System Data", order = 51)]
public class BlockScriptableObj : ScriptableObject
{
    public float countdownValue;
    public float upgradeButtonValue;
    public float iconLevelTextValue;
    public float iconLevelCapTextValue;
    public float progressBarTextValue;

    public bool activationButton;
    public bool iconButtonObj;
    public bool hasManager;

    private const string FILENAME = "sss.json";

    public void SaveToFile()
    {
        //var filePath = Path.Combine(Application.persistentDataPath, FILENAME);
        var filePath = Application.dataPath + "/Save/" + FILENAME;

        if (!File.Exists(filePath))
        {
            Debug.Log("Dosya oluþturuldu");
            File.Create(filePath);
        }

        var json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
        Debug.Log(json.ToString());
    }


    public void LoadDataFromFile()
    {
        //var filePath = Path.Combine(Application.persistentDataPath, FILENAME);
        var filePath = Application.dataPath + "/Save/" + FILENAME;

        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"File \"{filePath}\" not found!", this);
            return;
        }

        var json = File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(json, this);
    }


}

