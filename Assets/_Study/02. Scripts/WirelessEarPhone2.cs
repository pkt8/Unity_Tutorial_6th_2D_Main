using UnityEngine;

public class WirelessEarPhone2 : WirelssEarPhone
{
    public bool isNoiseCanceling;
    
    void Start()
    {
        name = "AirPod2";
        price = 150f;
        releaseYear = 2015;
        batterySize = 150f;
        isWirelessCharged = true;
        
        PlayMusic();
        BatteryCharged();
    }

    public void NoiseCanelingOnOff()
    {
        isNoiseCanceling = !isNoiseCanceling;
    }
}