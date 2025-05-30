using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour
{
    public InputField nameInput;
    public Text warningText; 

    void Start()
    {
        warningText.text = "";

        if (PlayerPrefs.HasKey("username"))
        {
            SceneManager.LoadScene("CounterScene");
        }
    }

    public void OnContinue()
    {
        string username = nameInput.text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            warningText.text = "Name cannot be empty!";
            return;
        }

        PlayerPrefs.SetString("username", username);
        PlayerPrefs.Save();
        SceneManager.LoadScene("CounterScene");
    }

    public void OnExit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
