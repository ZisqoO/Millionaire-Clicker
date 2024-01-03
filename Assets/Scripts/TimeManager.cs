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
     
        // Uygulama ilk �al��t���nda tarih ve saat bilgisini al
        appOpenTime = DateTime.Now;
    }

    void OnApplicationQuit()
    {
        // Uygulama kapat�ld���nda tarih ve saat bilgisini PlayerPrefs'a kaydet
        PlayerPrefs.SetString(AppCloseTimeKey, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            // Uygulama tekrar a��ld���nda buraya gelir
            if (PlayerPrefs.HasKey(AppCloseTimeKey))
            {
                
                // PlayerPrefs'tan appCloseTime bilgisini al
                string appCloseTimeString = PlayerPrefs.GetString(AppCloseTimeKey);
                DateTime.TryParse(appCloseTimeString, out DateTime parsedAppCloseTime);

                // Toplam ge�en s�reyi �rne�in saniye cinsinden alabilirsiniz:
                TimeSpan timeSinceClosed = DateTime.Now - parsedAppCloseTime;
                double totalSecondsSinceClosed = timeSinceClosed.TotalSeconds;
                deltaSecondsSinceClosed = Mathf.Floor((int)totalSecondsSinceClosed);
                // Buradan istedi�iniz i�lemleri yapabilirsiniz
                Debug.Log("Uygulama kapand�ktan sonra ge�en s�re: " + totalSecondsSinceClosed + " saniye");
                Debug.Log("Uygulama kapand�ktan sonra ge�en s�re: " + deltaSecondsSinceClosed + " saniye");
            }

            // Uygulama tekrar a��ld���nda ba�lang�� zaman�n� s�f�rla
            appOpenTime = DateTime.Now;
        }
    }
}
