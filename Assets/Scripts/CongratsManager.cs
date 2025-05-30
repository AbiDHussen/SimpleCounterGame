using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CongratsManager : MonoBehaviour
{
    public Text congratsText;

    void Start()
    {
        string username = PlayerPrefs.GetString("username", "Player");
        congratsText.text = $"Congratulations, {username}! You reached 10!";
        Debug.Log("Username in CongratsScene: " + username);
    }

    public void OnRestartGame()
    {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.Save();

        SceneManager.LoadScene("WelcomeScene");
    }

    public void OnExit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
