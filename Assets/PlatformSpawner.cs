using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform mcTransform;
    public ScoreManager scoreManager;

    public Vector2 platformSize = new Vector2(9.0f, 9.0f);
    public float minPulpitDestroyTime = 4.0f;
    public float maxPulpitDestroyTime = 5.0f;
    public float pulpitSpawnTime = 2.5f;

    private GameObject currentPlatform;
    private GameObject newPlatform;

    void Start()
    {
        currentPlatform = CreatePlatform(mcTransform.position);
        StartCoroutine(ManagePlatforms());
    }

    GameObject CreatePlatform(Vector3 position)
    {
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);
        platform.SetActive(true);
        return platform;
    }

    IEnumerator ManagePlatforms()
    {
        while (true)
        {
            float destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
            yield return new WaitForSeconds(destroyTime);

            Vector3[] adjacentPositions = GetAdjacentPositions(currentPlatform.transform.position);
            Vector3 newPosition = adjacentPositions[Random.Range(0, adjacentPositions.Length)];
            newPlatform = CreatePlatform(newPosition);

            Animator animator = currentPlatform.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Shrink");
                float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(animationDuration);
            }

            Destroy(currentPlatform);
            currentPlatform = newPlatform;
        }
    }

    Vector3[] GetAdjacentPositions(Vector3 currentPosition)
    {
        float width = platformSize.x;
        float length = platformSize.y;

        return new Vector3[]
        {
            new Vector3(currentPosition.x + width, 0, currentPosition.z),
            new Vector3(currentPosition.x - width, 0, currentPosition.z),
            new Vector3(currentPosition.x, 0, currentPosition.z + length),
            new Vector3(currentPosition.x, 0, currentPosition.z - length)
        };
    }
}
