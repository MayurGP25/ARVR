using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Text scoreText;
    public Text timerText;

    private int score = 0;
    private Rigidbody rb;
    private float timeLeft = 30f; // Timer duration in seconds
    private bool gameLost = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        UpdateScore();
    }

    void Update()
    {
        if (gameLost) return;

        // Timer functionality
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timerText.text = "Time's Up!";
            gameLost = true;
            return;
        }
        else
        {
            timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();
        }

        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected with: " + other.gameObject.name);

        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected!");
            score++;
            UpdateScore();
            Destroy(other.gameObject);

            // Level Transition Logic
            if (score == 4 && SceneManager.GetActiveScene().buildIndex == 0) // Level 1 to Level 2
            {
                SceneManager.LoadScene(1);
                score = 0; // Reset score for Level 2
            }
            else if (score == 4 && SceneManager.GetActiveScene().buildIndex == 1) // Win Condition
            {
                timerText.text = "You Win!";
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score Updated: " + score);
    }
}
