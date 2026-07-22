using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeInSeconds;
    public GameObject homeback;
    public GameObject damper;
    public GameObject timesup;
    public Slider timeBar;

    void Start()
    {
        timeInSeconds = 10;
        timeBar.value = 1f;
    }

    void Update()
    {
        timeInSeconds -= Time.deltaTime;
        if (timeInSeconds < 0) timeInSeconds = 0;

        timeBar.value = timeInSeconds / 600f;

        if (timeInSeconds == 0)
        {
            Health.currentHealth--;
            timesup.SetActive(true);
            StartCoroutine(WaitFiveSeconds());
            enabled = false;
        }
    }

    public void stopworking()
    {
        enabled = false;
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5f);
        timesup.SetActive(false);
        homeback.SetActive(true);
        damper.SetActive(true);
    }
}
