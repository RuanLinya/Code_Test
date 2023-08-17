using UnityEngine;

public class CubeFadeIn : MonoBehaviour
{
    public float fadeInDuration = 2.0f;
    private Renderer CubeRenderer;
    private Color originalColor;

    void Start()
    {
        CubeRenderer = GetComponent<Renderer>();
        if (CubeRenderer && CubeRenderer.material)
        {
            originalColor = CubeRenderer.material.color;
            originalColor.a = 0;
            CubeRenderer.material.color = originalColor;
        }
    }

    void Update()
    {
        if (originalColor.a < 1 && CubeRenderer && CubeRenderer.material)
        {
            originalColor.a += Time.deltaTime / fadeInDuration;
            CubeRenderer.material.color = originalColor;
        }
    }
}



