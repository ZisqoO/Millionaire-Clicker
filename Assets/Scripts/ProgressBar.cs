using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public BlockSystem blockSystem;
    public Slider progressSlider;
    private float targetValue = 1;
   

    private void Awake()
    {
        
    }
    void Start()
    {
      
    }
    void Update()
    {
        if (blockSystem.isCountdowning == true)
        {
            if (progressSlider.value < targetValue)
            {
                progressSlider.value += 1 / blockSystem.countdownValue * Time.deltaTime;
            }
        }
        
        
    }
}
