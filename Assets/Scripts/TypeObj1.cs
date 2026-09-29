using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TypeObj1 : MonoBehaviour
{
    public float charactersPerSecond = 35f;
    public AudioSource typeSFX;
    public static bool isTyping;


    private TMP_Text textBox;

    void Awake()
    {
        textBox = GetComponent<TMP_Text>();
        if (typeSFX != null)
        {
            typeSFX.loop = true;
            typeSFX.Stop();
        }
    }

    void OnEnable()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textBox.maxVisibleCharacters = 0;
        textBox.ForceMeshUpdate();
        int totalCharacters = textBox.textInfo.characterCount;

        yield return new WaitForSeconds(1f);

        if (typeSFX != null)
            typeSFX.Play();

        for (int i = 0; i <= totalCharacters; i++)
        {
            textBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(1f / charactersPerSecond);
            isTyping = true;
        }
        isTyping = false;


        if (typeSFX != null)
        {
            typeSFX.Stop();

        }
    }

    public static bool Typing()
    {
        return isTyping;
    }


}