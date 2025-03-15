using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene found. Make sure scenes are added to Build Settings.");
        }
    }
}
