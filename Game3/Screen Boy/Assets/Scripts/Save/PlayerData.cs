using UnityEngine;
[System.Serializable]
public class PlayerData
{
    
    public int coinamount;
    public int levelamount;
    public float rotationspeed;
    public float volume;
    public bool fullscreen;
    public PlayerData (GameManager gameman)
    {
        levelamount = gameman.levelamount;
        coinamount = gameman.coinamount;
        rotationspeed = gameman.rotspd;
        volume = gameman.volume;
        fullscreen = gameman.fullscreen;
    }
}
