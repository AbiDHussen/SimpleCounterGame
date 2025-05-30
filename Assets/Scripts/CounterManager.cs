using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CounterManager : MonoBehaviour
{
    public Text counterText;
    private int count = 0;

    void Start()
    {
        count = PlayerPrefs.GetInt("score", 0);
        UpdateCounterText();
        if (count >= 10)
        {
            SceneManager.LoadScene("CongratsScene");
        }
    }

    public void OnPlus()
    {
        count++;
        UpdateCounterText();

        if (count >= 10)
        {
            SceneManager.LoadScene("CongratsScene");
        }
    }

    public void OnMinus()
    {
        count--;
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        counterText.text = count.ToString();

        PlayerPrefs.SetInt("score", count);
        PlayerPrefs.Save();
    }

    public void OnExit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnBack()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
