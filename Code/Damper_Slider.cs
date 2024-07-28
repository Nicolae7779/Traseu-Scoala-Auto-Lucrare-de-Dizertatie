using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damper_Slider : MonoBehaviour
{
    public Slider DamperSlider;

    public float value_of_Slider;

    public float previous_value = 100f;
    private void FixedUpdate()
    {
        value_of_Slider = DamperSlider.value * 100f;

        Butoane_Volan();
    }


    private void Butoane_Volan()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            butoane_volan(rec);
        }
    }

    public bool buttonPressed = false;

    void butoane_volan(LogitechGSDK.DIJOYSTATE2ENGINES v_butoane)
    {
        if (value_of_Slider != previous_value)
        {
            LogitechGSDK.LogiPlayDamperForce(0, (int)value_of_Slider);
            previous_value = value_of_Slider;
        }
    }

}
