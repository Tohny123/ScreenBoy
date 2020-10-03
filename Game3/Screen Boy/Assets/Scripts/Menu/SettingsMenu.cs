﻿using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        rotspeed = gameman.rotspd;
        float tempvol;
        audmix.GetFloat("Volume",out tempvol);
        volslider.value = tempvol;
        if (rotspeed <= 0)
        {
            sensitivityslider.value = 25;
        }
        else
        {
            sensitivityslider.value = rotspeed;
        }
        
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

        areyousure.SetActive(false);

    }

    public void activateareyousure ()
    {
        areyousure.SetActive(true);
    }

    public void savedelyes()
    {
        gameman.coinamount = 0;
        gameman.levelamount = 0;
        SaveSystem.Save(gameman, filename);
        SceneManager.LoadScene("Menu");
    }

    public void savedelno()
    {
        areyousure.SetActive(false);
    }

    public void VolSet (float vol)
    {
        
        audmix.SetFloat("Volume", vol);
    }
    
    public void CamSpeed(float rotatespeed)
    {
   
    PlayerData plrdata = SaveSystem.Load(gameman, filename);
    gameman.rotspd = rotatespeed;
    gameman.coinamount = plrdata.coinamount;
    gameman.levelamount = plrdata.levelamount;
    SaveSystem.Save(gameman, filename);
    }

    public void QualSet(int qualindex)
    {
        QualitySettings.SetQualityLevel(qualindex);
    }

    public void Fullscreenset(bool isfullscrn)
    {
        Screen.fullScreen = isfullscrn;
    }

    public void ResSet(int resindex)
    {
        Resolution res = resolutions[resindex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
