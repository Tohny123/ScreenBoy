using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audmix;
    Resolution[] resolutions;
    public Dropdown resdropdown;
    public Slider volslider;
    public Slider sensitivityslider;
    public GameObject areyousure;
    public GameManager gameman;
    public static SaveSystem savesys = new SaveSystem();
    public string filename;
    public float rotspeed;
    public Dropdown graphicsdropdown;
    
    void Start()
    {
        //load data
        load();
        //set rotationspeed
        rotspeed = gameman.rotspd;

        //set volume to current volume
        float tempvol;
        audmix.GetFloat("Volume",out tempvol);
        volslider.value = tempvol;
        //if rotspeed is 0 set it to 8
        if (rotspeed <= 0)
        {
            sensitivityslider.value = 8;
            gameman.rotspd = 8;
            rotspeed = 8;
            SaveSystem.Save(gameman, filename);
        }
        else
        {
            sensitivityslider.value = rotspeed;
        }
        //set dropdown to screen resolutions
        resolutions = Screen.resolutions;
        resdropdown.ClearOptions();
        List<string> resoptions = new List<string>();
        int curresindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            resoptions.Add(options);

            if (resolutions[i].width == Screen.currentResolution.width &&
            resolutions[i].height == Screen.currentResolution.height)
            {
                curresindex = i;
            }
        }
        resdropdown.AddOptions(resoptions);
        resdropdown.value = curresindex;
        resdropdown.RefreshShownValue();
        //quality settings value
        graphicsdropdown.value = QualitySettings.GetQualityLevel();
        //set are you sere message to false
        areyousure.SetActive(false);

    }
    //enable are you sure
    public void activateareyousure ()
    {
        areyousure.SetActive(true);
    }
    //delete save
    public void savedelyes()
    {
    gameman.coinamount = 0;
    gameman.levelamount = 0;
    SaveSystem.Save(gameman, filename);
    SceneManager.LoadScene("Menu");
    }
    //close are you sure
    public void savedelno()
    {
        areyousure.SetActive(false);
    }
    //set volume
    public void VolSet (float vol)
    {
        load();
        gameman.volume = vol;
        audmix.SetFloat("Volume", vol);
        SaveSystem.Save(gameman, filename);
    }
    //set camspeed
    public void CamSpeed(float rotatespeed)
    {
    load();
    gameman.rotspd = rotatespeed;
    SaveSystem.Save(gameman, filename);
    }
    //set quality
    public void QualSet(int qualindex)
    {
        QualitySettings.SetQualityLevel(qualindex);
    }
    //set fullscreen
    public void Fullscreenset(bool isfullscrn)
    {
        Screen.fullScreen = isfullscrn;
        gameman.fullscreen = isfullscrn;
        SaveSystem.Save(gameman, filename);
    }
    //set resolutions
    public void ResSet(int resindex)
    {
        Resolution res = resolutions[resindex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    //load
    public void load()
    {
    PlayerData plrdata = SaveSystem.Load(gameman, filename);
    gameman.rotspd = plrdata.rotationspeed;
    gameman.coinamount = plrdata.coinamount;
    gameman.levelamount = plrdata.levelamount;
    gameman.fullscreen = plrdata.fullscreen;
    gameman.volume = plrdata.volume;
    }
}
