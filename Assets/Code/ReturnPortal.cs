using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string prevScene = PlayerPrefs.GetString("PreviousScene", "MainScene");
            SceneManager.LoadScene(prevScene);
        }
    }
}


