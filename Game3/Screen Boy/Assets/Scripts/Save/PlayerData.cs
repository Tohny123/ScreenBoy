using UnityEngine;
[System.Serializable]
public class PlayerData
{
    
    public int? coinamount;
    public PlayerData (GameManager gameman)
    {
        coinamount = gameman.coinamount;
    }
}
