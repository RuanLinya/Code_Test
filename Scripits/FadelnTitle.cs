using UnityEngine;
using TMPro;
using System.Collections;

public class FadelnTitle : MonoBehaviour
{
    public float fadeInDuration = 2.0f;
    private TMP_Text titleText;
    private Color originalColor;

    void Start()
    {
        titleText = GetComponent<TMP_Text>();
        originalColor = titleText.color;
        originalColor.a = 0;
        titleText.color = originalColor;
    }

    void Update()
    {
        if (originalColor.a < 1)
        {
            originalColor.a += Time.deltaTime / fadeInDuration;
            titleText.color = originalColor;
        }
    }

}

