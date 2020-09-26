using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audmix;
    Resolution[] resolutions;
    public Dropdown resdropdown;
    public Slider volslider;
    void Start()
    {
        float tempvol;
        audmix.GetFloat("Volume",out tempvol);
        volslider.value = tempvol;

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
    }

    public void VolSet (float vol)
    {
        
        audmix.SetFloat("Volume", vol);
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
