using UnityEngine;

public class WirelessEarPhone3 : WirelessEarPhone2
{
    public enum NoiseCanelingType { Off, On, Around }
    public NoiseCanelingType type;
    
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

    public void SelectNoiseCancelingType()
    {
        
    }
}