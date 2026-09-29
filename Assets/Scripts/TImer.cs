using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float startingTime = 240f;
    public static float timeInSeconds;

    public GameObject homeback;
    public GameObject damper;
    public GameObject timesup;
    public Slider timeBar;
    public GameObject player;
    public TMP_Text timerText;

    void Start()
    {
        timeInSeconds = startingTime;
        timeBar.value = 1f;
    }

    void Update()
    {
        timeInSeconds -= Time.deltaTime;

        if (timeInSeconds < 0)
            timeInSeconds = 0;

        timeBar.value = timeInSeconds / startingTime;

        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        timerText.text = $"{minutes}:{seconds:00}";

        if (timeInSeconds <= 0)
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

        player.transform.position = new Vector3(29, 476, 147);
        timesup.SetActive(false);
        homeback.SetActive(true);
        damper.SetActive(true);
    }

    public static void ReduceRoundTime()
    {
        startingTime -= 60f;

        if (startingTime < 60f)
            startingTime = 60f;
    }

    public static void ResetRoundTime()
    {
        startingTime = 240f;
    }
}