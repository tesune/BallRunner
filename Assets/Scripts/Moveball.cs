using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveball : MonoBehaviour
{
    private Rigidbody _rb;
    public float ballspeed;
    public float balljump;
    private bool _isOnGround = true;
    private int _counter;
    public Text coincount;
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _counter = 20;

        coincount.text = "Coins Remaining: " + _counter;
    }

    // Update is called once per frame
    void Update()
    {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 ballMove = new Vector3(hmove, 0.0f, vmove);
        _rb.AddForce(ballMove * ballspeed);

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(Vector3.up * balljump, ForceMode.Impulse);
            _isOnGround = false;
        }
    }
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            _counter -= 1 ;
            coincount.text = "Coins Remaining: " + _counter;
            audioSource.PlayOneShot(audioClip);

            if (_counter == 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
