using UnityEngine;

public class MCController : MonoBehaviour
{
    public ScoreManager scoreManager; 
    public UIController uiController; 
    public float fallThreshold = -10f; 

    private Transform currentPlatform; 
    private bool hasScored = false; 
    private bool isFirstPlatform = true; 

    void Start()
    {
        currentPlatform = GetCurrentPlatform(); 
        if (currentPlatform != null)
        {
            isFirstPlatform = false; 
        }
    }

    void Update()
    {
        Transform newPlatform = GetCurrentPlatform();
        
        if (newPlatform != currentPlatform && newPlatform != null)
        {
            if (!hasScored)
            {
               
                if (!isFirstPlatform)
                {
                    if (scoreManager != null)
                    {
                        scoreManager.IncreaseScore();
                    }
                    else
                    {
                        Debug.LogError("ScoreManager reference is not assigned.");
                    }
                }

               
                currentPlatform = newPlatform;
                hasScored = true;
            }
        }
        else
        {
            
            hasScored = false;
        }

        
        if (isFirstPlatform && currentPlatform != null)
        {
            isFirstPlatform = false;
        }

     
        if (transform.position.y < fallThreshold)
        {
            if (uiController != null)
            {
                uiController.ShowGameOverScreen(); 
                Time.timeScale = 0; 
            }
        }
    }

    Transform GetCurrentPlatform()
    {
        // Raycast downwards to detect the platform under MC
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Platform"))
            {
                return hit.collider.transform; // Return the platform's transform
            }
        }
        return null; // Return null if no platform is detected
    }
}
