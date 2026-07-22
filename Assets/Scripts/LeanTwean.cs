using UnityEngine;
using System.Collections;

public class LeanTweenHandle : MonoBehaviour
{
    public float fadeInTime = 1f;
    public float fadeOutTime = 1.5f;
    public static bool faded = false;
    private CanvasGroup cg;

    void Start()
    {
        cg = gameObject.GetComponent<CanvasGroup>();
        if(cg == null) cg = gameObject.AddComponent<CanvasGroup>();

        cg.alpha = 0f;
        StartCoroutine(FadeText());
        Debug.Log(TypeObj1.isTyping + "2");
    }

    IEnumerator FadeText()
    {
        LeanTween.alphaCanvas(cg, 1f, fadeInTime);
        yield return new WaitForSeconds(fadeInTime);
        Debug.Log(TypeObj1.isTyping + "1");
        while(TypeObj1.isTyping)
        {
            yield return null;
        }

        LeanTween.alphaCanvas(cg, 0f, fadeOutTime);
        Debug.Log(TypeObj1.isTyping + "3");
        faded = true;
    }
    public static void SlideInLR(GameObject panel, float distance, float time)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();

        Vector2 endPos = rect.anchoredPosition;
        rect.anchoredPosition = new Vector2(endPos.x + distance, endPos.y);

        LeanTween.move(rect, endPos, time).setEaseOutExpo();
    }

    public static void SlideInTB(GameObject panel, float distance, float time)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();

        Vector2 endPos = rect.anchoredPosition;
        rect.anchoredPosition = new Vector2(endPos.x, endPos.y + distance);

        LeanTween.move(rect, endPos, time).setEaseOutExpo();
    }

    public static void PopIn(GameObject obj, float time)
    {
        obj.transform.localScale = Vector3.zero;

        LeanTween.scale(obj, Vector3.one, time).setEaseOutQuad();
    }
    public static void FadeIn(GameObject obj, float time)
    {
        CanvasGroup group = obj.GetComponent<CanvasGroup>();

        group.alpha = 0f;
        LeanTween.alphaCanvas(group, 1f, time);
    }   
}
