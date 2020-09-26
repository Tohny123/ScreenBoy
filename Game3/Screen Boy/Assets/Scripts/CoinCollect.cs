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
    public AudioMixer audmix;
    public float tempvol;
    
    // Start is called before the first frame update
    void Start()
    {
        audmix.GetFloat("Volume", out tempvol);
        coinvol = 1/Mathf.Abs(tempvol);
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinsound, transform.position, coinvol);
            FindObjectOfType<GameManager>().CoinAdd(value);
            Instantiate(coineffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
