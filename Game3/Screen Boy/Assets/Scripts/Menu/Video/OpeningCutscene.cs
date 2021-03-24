﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    public VideoPlayer vid;
    public float vidtime;
    public string levelnext;
    public Fade fade;
    public GameManager gameman;
    public string filename;
    public int coinamount;
    public int levelamount;
    public float rotationspeed;
    public float volume;
    public bool fullscreen;
    public static SaveSystem savesystem = new SaveSystem();

    // Start is called before the first frame update
    void Start()
    {
        load();
        vidtime = vid.frameCount/vid.frameRate;
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        gameman.watchedyet = true;
        SaveSystem.Save(gameman, filename);
    }

    // Update is called once per frame
    void Update()
    {
        if (vidtime > 0)
        {
            vidtime -= Time.deltaTime;
        }
        else if (vidtime < 0)
        {
            StartCoroutine(fade.LevelFade(levelnext));
        }
    }
    public void load()
    {
        PlayerData data = SaveSystem.Load(gameman, filename);
        coinamount = data.coinamount;
        levelamount = data.levelamount;
        rotationspeed = data.rotationspeed;
        volume = data.volume;
        fullscreen = data.fullscreen;
    }
}
