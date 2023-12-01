using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    private DateTime appCloseTime;

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Uygulama kapanýrken tarih ve saat bilgisini al
            appCloseTime = DateTime.Now;
        }
        else
        {
            // Uygulama tekrar açýldýðýnda buraya gelir
            TimeSpan timeSinceClosed = DateTime.Now - appCloseTime;

            // Toplam geçen süreyi örneðin saniye cinsinden alabilirsiniz:
            double totalSecondsSinceClosed = timeSinceClosed.TotalSeconds;

            // Buradan istediðiniz iþlemleri yapabilirsiniz
            Debug.Log("Uygulama kapandýktan sonra geçen süre: " + totalSecondsSinceClosed + " saniye");
        }
    }
}
