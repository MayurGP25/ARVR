using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Text scoreText;

    private int score = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        UpdateScore();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected with: " + other.gameObject.name);  // Log to check collision detection

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected!");  // Log when a coin is collected
            score++;
            UpdateScore();
            Destroy(other.gameObject);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score Updated: " + score);  // Log to confirm score update
    }
}
