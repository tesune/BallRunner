using UnityEngine;

public class RotateCoins : MonoBehaviour
{
    private Vector3 turncoins;
    void Update()
    {
        turncoins = new Vector3(45, 0, 0);
        transform.Rotate(turncoins * Time.deltaTime);
    }
}
