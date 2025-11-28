using UnityEngine;

public class WirelssEarPhone : EarPhone
{
    public float batterySize;
    public bool isWirelessCharged;
    
    void Start()
    {
        name = "AirPod1";
        price = 100f;
        releaseYear = 2007;
        batterySize = 50f;
        isWirelessCharged = true;
        
        PlayMusic();
    }

    public void BatteryCharged()
    {
        // 유무선 충전
    }
}