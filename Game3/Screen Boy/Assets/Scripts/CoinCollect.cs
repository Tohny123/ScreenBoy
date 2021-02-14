using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Unity.Mathematics;

public class CoinCollect : MonoBehaviour
{
    public AudioClip coinsound;
    public int value;
    public float coinvol;
    public GameObject coineffect;
    public GameManager gameman;
    // Start is called before the first frame update
    void Start()
    {
        //find the volume and divide one by that volume
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameman.volnormal();
        coinvol = gameman.vol;
  
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //collect coin
            AudioSource.PlayClipAtPoint(coinsound, transform.position, coinvol);
            FindObjectOfType<GameManager>().CoinAdd(value);
            Instantiate(coineffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
