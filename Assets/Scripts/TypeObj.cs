using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TypeObj : MonoBehaviour
{
    public float charactersPerSecond = 75f;
    public AudioSource typeSFX;

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

        if (typeSFX != null)
            typeSFX.Play();

        for (int i = 0; i <= totalCharacters; i++)
        {
            textBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(1f / charactersPerSecond);
        }

        if (typeSFX != null)
            typeSFX.Stop();
    }
}