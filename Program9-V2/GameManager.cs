using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public int totalCubes = 5;
    public float levelTime = 30f;
    public int maxChances = 3;

    private int score = 0;
    private float timer;
    private int chances;

    void Start()
    {
        timer = levelTime;
        chances = maxChances;
        UpdateUI();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            EndLevel();
        }
        UpdateUI();
    }

    public void CollectCube(GameObject cube)
    {
        score += 10;
        Destroy(cube);
        totalCubes--;

        if (totalCubes == 0)  
        {
            LoadNextLevel();  // Switch to the next level
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time Left: " + Mathf.Ceil(timer);
    }

    void EndLevel()
    {
        chances--;
        if (chances > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(1); // Load Level2
        }
        else
        {
            Debug.Log("You Won! Game Completed.");
        }
    }
}
