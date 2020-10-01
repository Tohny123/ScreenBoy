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
    waitsectime = waitsectime * Time.deltaTime;
}

   public IEnumerator LevelFade(string levlname)
{
    fade.SetTrigger("Start");
    yield return new WaitForSeconds(waitsectime);
    SceneManager.LoadScene(levlname);
}
public IEnumerator DeathFade()
{
    fade.SetTrigger("Start");
    yield return new WaitForSeconds(waitsectime);
}
public IEnumerator FadeBack()
{
    fade.SetTrigger("End");
    yield return new WaitForSeconds(waitsectime);
}

}
