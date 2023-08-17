
using UnityEngine;

public class BallSelection : MonoBehaviour
{
    public Vector3 scene3Center = new Vector3(0, 1, 5);
    private Renderer ballRenderer;

    private Color originalColor;
    private bool isRotating = true;
    public Transform rotationCenter;
    public float rotationSpeed = 30f;
    public float fixedDistance = 0.5f;
    public GameObject correspondingBallInScene3;
    public Transform fixedPositionInScene3;

    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
        originalColor = ballRenderer.material.color;
    }

    void Update()

    {
        if (isRotating)
        {
            Vector3 directionToBall = transform.position - rotationCenter.position;
            directionToBall.Normalize();
            transform.position = rotationCenter.position + directionToBall * fixedDistance;
            transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }

    }

    void OnMouseDown()
    {

        StartTransition();
        correspondingBallInScene3.SetActive(true);
        correspondingBallInScene3.transform.position = fixedPositionInScene3.position;
    }

    void StartTransition()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            if (ball != gameObject)
            {
                StartCoroutine(FadeOutRoutine(ball.GetComponent<Renderer>())); // 开始淡出

            }
        }

        StartCoroutine(MoveToPosition(scene3Center, 2.0f));
        isRotating = false;
    }

    public System.Collections.IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    public System.Collections.IEnumerator FadeOutRoutine(Renderer targetRenderer)
    {
        float duration = 10.0f; // 淡出时间
        float progress = 0f;
        Color originalColorOfTarget = targetRenderer.material.color;

        while (progress < duration)
        {
            progress += Time.deltaTime;
            targetRenderer.material.color = Color.Lerp(originalColorOfTarget, new Color(originalColorOfTarget.r, originalColorOfTarget.g, originalColorOfTarget.b, 0f), progress / duration);
            yield return null;
        }

        targetRenderer.material.color = new Color(originalColorOfTarget.r, originalColorOfTarget.g, originalColorOfTarget.b, 0f);
        targetRenderer.gameObject.SetActive(false);
    }

}




