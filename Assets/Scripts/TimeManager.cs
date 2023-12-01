using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    private DateTime appCloseTime;

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Uygulama kapan�rken tarih ve saat bilgisini al
            appCloseTime = DateTime.Now;
        }
        else
        {
            // Uygulama tekrar a��ld���nda buraya gelir
            TimeSpan timeSinceClosed = DateTime.Now - appCloseTime;

            // Toplam ge�en s�reyi �rne�in saniye cinsinden alabilirsiniz:
            double totalSecondsSinceClosed = timeSinceClosed.TotalSeconds;

            // Buradan istedi�iniz i�lemleri yapabilirsiniz
            Debug.Log("Uygulama kapand�ktan sonra ge�en s�re: " + totalSecondsSinceClosed + " saniye");
        }
    }
}
