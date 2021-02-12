using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour
{
    public Animator fade;
    public float waitsectime;
    public bool isrun;
void Start()
{
    //find refrences
  
    //multiply waittime by deltatime
    waitsectime = waitsectime * Time.deltaTime;
}
//fade coroutine
   public IEnumerator LevelFade(string levlname)
{
    //start fade
    isrun = true;
    fade.SetTrigger("Start");
    //wait and load scene
    yield return new WaitForSeconds(waitsectime);
    isrun = false;
    SceneManager.LoadScene(levlname);
}
public IEnumerator DeathFade()
{
    //fade and wait
    isrun = true;
    fade.SetTrigger("Start");
    yield return new WaitForSeconds(waitsectime);
    isrun = false;
}
public IEnumerator FadeBack()
{
    //fade back
    isrun = true;
    fade.SetTrigger("End");
    yield return new WaitForSeconds(waitsectime);
    isrun = false;

}

}
