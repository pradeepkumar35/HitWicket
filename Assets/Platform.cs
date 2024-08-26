using UnityEngine;

public class Platform : MonoBehaviour
{
    public ScoreManager scoreManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
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
    }
}
