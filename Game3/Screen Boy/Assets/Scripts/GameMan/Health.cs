using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Health : MonoBehaviour
{
    public int maxhealth;
    public static int currenthealth;
    public int deathbarrierhealth;
    public float invlength;
    public float invcount;
    public Player plr;
    public Renderer plrrend;
    private float flashcount;
    public float flashlength;
    private bool isrespawn;
    public static Vector3 spawnpoint;
    public float spawndelay;
    public GameObject deathparticle;
    //public Image blackscreen;
    private bool fadeblack;
    private bool fadeback;
    public float fadespeed;
    public float fadedelay;
    public AudioSource hurtsoundsource;
    public AudioClip hurtsound;
    public float hurtvolume;
    public AudioClip gameoversound;
    public Text Healthtext;
    public Color HealthColor;
    public AudioClip alert;
    public AudioMixer audmixer;
    public float tempvol;
    public float finalvol;
    public GameObject fader;
    public Fade fade;
    public Color fadecolor;
    public Image fadeimage;

    // Start is called before the first frame update
    void Start()
    {
    //find fader
    fader = GameObject.Find("Fade");
    fade = fader.GetComponent<Fade>();
        //make heath max
        currenthealth = maxhealth;
        //find player and set spawn to player
        plr = FindObjectOfType<Player>();
        spawnpoint = plr.transform.position;
        //audio
        audmixer.GetFloat("Volume", out tempvol);
        finalvol = 1/Mathf.Abs(tempvol);
    }

    // Update is called once per frame
    void Update()
    {
        //make deathbarrier equal to health
        deathbarrierhealth = currenthealth;
        //make fadecolor equal to fader color
        fadecolor = fadeimage.color;
        //make health red when low
       if(currenthealth < 6)
       {
           
           HealthColor = Color.red;
           Healthtext.color = HealthColor;
       }
       else
       {
           HealthColor = Color.white;
           Healthtext.color = HealthColor;
       }
       //invinciblillity and flashing
        if(invcount > 0 )
        {
            invcount -= Time.deltaTime;
            flashcount -= Time.deltaTime;
            if (flashcount > 0)
            {
                plrrend.enabled = !plrrend.enabled;
                flashcount = flashlength;

            }
                if(invcount <= 0 )
                {
                    plrrend.enabled = true;
                }
        }
        //fade to black
        if(fadeblack)
        {
            //blackscreen.color = new Color(blackscreen.color.r, blackscreen.color.g, blackscreen.color.b, Mathf.MoveTowards(blackscreen.color.a, 1f, fadespeed * Time.deltaTime));
            StartCoroutine(fade.DeathFade());
            if(fadecolor.a == 1f)
            {
                fadeblack = false;
            }
        }
        //fade back after death
        if(fadeback)
        {
            //blackscreen.color = new Color(blackscreen.color.r, blackscreen.color.g, blackscreen.color.b, Mathf.MoveTowards(blackscreen.color.a, 0f, fadespeed * Time.deltaTime));
        StartCoroutine(fade.FadeBack());
            if(fadecolor.a == 0f)
            {
                fadeback = false;
            }
        }
    }
    //damage player
    public void damage(int dmgamnt, Vector3 direction)
    {
        if (invcount <= 0)
        {
        currenthealth -= dmgamnt;
        if(currenthealth <= 0)
        {
            hurtsoundsource.PlayOneShot(hurtsound, hurtvolume);
            respawn();
        } else {
            hurtsoundsource.PlayOneShot(hurtsound, hurtvolume);
        plr.knockback(direction);
        invcount = invlength;
        plrrend.enabled = false;
        flashcount = flashlength;
        }
        }
    }
    //respawn
    public void respawn()
    {
        //plr.transform.position = spawnpoint;
        //currenthealth = maxhealth;
        if(!isrespawn)
        {
            StartCoroutine("respco");
        }
    }
    //respawn 
    public IEnumerator respco()
    {
        
        isrespawn = true;
        AudioSource.PlayClipAtPoint(gameoversound, plr.transform.position, finalvol);
        Instantiate(deathparticle, plr.transform.position, plr.transform.rotation);
        plr.gameObject.SetActive(false);

        yield return new WaitForSeconds(spawndelay);
        fadeblack = true;
        yield return new WaitForSeconds(fadedelay);
        fadeback = true;
        isrespawn= false;
        plr.transform.position = spawnpoint;
        plr.transform.parent = null;
        plr.gameObject.SetActive(true);
        
        currenthealth = maxhealth;

        invcount = invlength;
        plrrend.enabled = false;
        flashcount = flashlength;
    }
    //heal
    public void heal(int healamnt)
    {
        currenthealth += healamnt;
        
        if(currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
    }
    //checkpoint
    public void setspawn(Vector3 checkpointpos)
    {
        spawnpoint = checkpointpos;
    }
}
