using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        transform.position += movement * speed * Time.deltaTime;
    }
}
