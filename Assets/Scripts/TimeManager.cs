using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public GameManager gameManager;
    private const string AppCloseTimeKey = "AppCloseTime";
    private DateTime appOpenTime;
    public float deltaSecondsSinceClosed = 0;

    void Start()
    {
     
        // Uygulama ilk çalýþtýðýnda tarih ve saat bilgisini al
        appOpenTime = DateTime.Now;
    }

    void OnApplicationQuit()
    {
        // Uygulama kapatýldýðýnda tarih ve saat bilgisini PlayerPrefs'a kaydet
        PlayerPrefs.SetString(AppCloseTimeKey, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            // Uygulama tekrar açýldýðýnda buraya gelir
            if (PlayerPrefs.HasKey(AppCloseTimeKey))
            {
                
                // PlayerPrefs'tan appCloseTime bilgisini al
                string appCloseTimeString = PlayerPrefs.GetString(AppCloseTimeKey);
                DateTime.TryParse(appCloseTimeString, out DateTime parsedAppCloseTime);

                // Toplam geçen süreyi örneðin saniye cinsinden alabilirsiniz:
                TimeSpan timeSinceClosed = DateTime.Now - parsedAppCloseTime;
                double totalSecondsSinceClosed = timeSinceClosed.TotalSeconds;
                deltaSecondsSinceClosed = Mathf.Floor((int)totalSecondsSinceClosed);
                // Buradan istediðiniz iþlemleri yapabilirsiniz
                Debug.Log("Uygulama kapandýktan sonra geçen süre: " + totalSecondsSinceClosed + " saniye");
                Debug.Log("Uygulama kapandýktan sonra geçen süre: " + deltaSecondsSinceClosed + " saniye");
            }

            // Uygulama tekrar açýldýðýnda baþlangýç zamanýný sýfýrla
            appOpenTime = DateTime.Now;
        }
    }
}
