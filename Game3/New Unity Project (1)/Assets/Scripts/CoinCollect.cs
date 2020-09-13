using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinCollect : MonoBehaviour
{
    public AudioClip coinsound;
    public int value;
    public float coinvol;
    public GameObject coineffect;
    // Start is called before the first frame update
    void Start()
    {
        coinvol = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinsound, transform.position, 1f);
            FindObjectOfType<GameManager>().CoinAdd(value);
            Instantiate(coineffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
