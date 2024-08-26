using UnityEngine;

public class ScaleAnimator : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2, 2, 2); 
    public float duration = 1.0f; 

    private Vector3 initialScale;
    private float timeElapsed;
    private bool isExpanding = false;
    private bool isShrinking = false;

    void Start()
    {
        initialScale = transform.localScale;
        timeElapsed = 0f;
    }

    void Update()
    {
        if (isExpanding)
        {
            Expand();
        }
        else if (isShrinking)
        {
            Shrink();
        }
    }

    public void StartExpansion()
    {
        isExpanding = true;
        isShrinking = false;
        timeElapsed = 0f; 
    }

    public void StartShrinking()
    {
        isShrinking = true;
        isExpanding = false;
        timeElapsed = 0f; 
    }

    private void Expand()
    {
        if (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / duration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
        }
        else
        {
            transform.localScale = targetScale; 
            isExpanding = false;
        }
    }

    private void Shrink()
    {
        if (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / duration;
            transform.localScale = Vector3.Lerp(targetScale, initialScale, t);
        }
        else
        {
            transform.localScale = initialScale; 
            isShrinking = false;
        }
    }
}
