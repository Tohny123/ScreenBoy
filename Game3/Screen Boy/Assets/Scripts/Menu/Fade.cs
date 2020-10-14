using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour
{
    public Animator fade;
    public float waitsectime;
void Start()
{
    //multiply waittime by deltatime
    waitsectime = waitsectime * Time.deltaTime;
}
//fade coroutine
   public IEnumerator LevelFade(string levlname)
{
    //start fade
    fade.SetTrigger("Start");
    //wait and load scene
    yield return new WaitForSeconds(waitsectime);
    SceneManager.LoadScene(levlname);
}
public IEnumerator DeathFade()
{
    //fade and wait
    fade.SetTrigger("Start");
    yield return new WaitForSeconds(waitsectime);
}
public IEnumerator FadeBack()
{
    //fade back
    fade.SetTrigger("End");
    yield return new WaitForSeconds(waitsectime);
}

}
