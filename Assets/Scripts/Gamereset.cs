using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class Gamereset : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
