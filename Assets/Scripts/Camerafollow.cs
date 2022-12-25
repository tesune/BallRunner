using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject ball;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = distance + ball.transform.position;

    }
}
