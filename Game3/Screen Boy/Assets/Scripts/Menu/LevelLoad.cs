using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    public Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();
    }

   public void load(string LevelName)
    {
        StartCoroutine(fade.LevelFade(LevelName));
    }
}
