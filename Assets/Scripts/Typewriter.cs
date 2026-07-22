using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SimpleTypewriter : MonoBehaviour
{
    public float CharactersPerSecond = 25f;
    public AudioSource TypeSFX;
    private TMP_Text TextBox;

    void Awake()
    {
        TextBox = GetComponent<TMP_Text>();
        if (TypeSFX != null)
        {
            TypeSFX.loop = true;
            TypeSFX.Stop(); 
        }
    }

    void OnEnable()
    {
        StartCoroutine(typeText());
    }

    IEnumerator typeText()
    {
        TextBox.maxVisibleCharacters = 0;
        TextBox.ForceMeshUpdate();
        int totalCharacters = TextBox.textInfo.characterCount;

        if (TypeSFX != null)
            TypeSFX.Play();

        for (int i = 0; i <= totalCharacters; i++)
        {
            TextBox.maxVisibleCharacters = i;
            yield return new WaitForSeconds(1f / CharactersPerSecond);
        }

        if (TypeSFX != null)
            TypeSFX.Stop();
    }
}