using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{

    public Image TransitionScreen;
    private int Index;
    private float Incriments;
    private float Duration;

    private float LowerBound;
    private float UpperBound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Index = 0;
        Incriments = 10f;
        Duration = 0.8f;
        TransitionScene("In");
    }

    public void TransitionScene(string transitionType)
    {
        Index = 0;
        if (transitionType == "In")
        {
            LowerBound = 0f;
            UpperBound = 1080f;
        }
        else
        {
            LowerBound = 1080f;
            UpperBound = 0f;
        }
        StartCoroutine("Transition");
    }

    IEnumerator Transition()
    {
        if (Incriments >= Index)
        {
            RectTransform rectTransform = TransitionScreen.GetComponent<RectTransform>();
            float yPos = Mathf.Lerp(LowerBound, UpperBound, Index / Incriments);
            Vector2 currentPos = rectTransform.anchoredPosition;
            rectTransform.anchoredPosition = new Vector2(currentPos.x, yPos);
            yield return new WaitForSeconds(Duration / Incriments);
            StartCoroutine("Transition");
        }
        else
        {
            yield return new WaitForSeconds(0);
        }
        Index++;
    }

    public float getDuration()
    {
        return Duration;
    }


}
