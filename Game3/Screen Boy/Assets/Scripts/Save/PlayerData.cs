using UnityEngine;
[System.Serializable]
public class PlayerData
{
    
    public int coinamount;
    public int levelamount;
    public PlayerData (GameManager gameman)
    {
        levelamount = gameman.levelamount;
        coinamount = gameman.coinamount;
    }
}
