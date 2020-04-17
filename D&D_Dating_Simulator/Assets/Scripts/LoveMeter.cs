using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveMeter : MonoBehaviour
{
   public Slider slider;

   public void setMaxLoveMeter(int loveMeter)
   {
        slider.maxValue = loveMeter;
        slider.value = 0;
   }

    public void SetLoveMeter(int loveMeter)
   {
        slider.value = loveMeter;
   }
}
