using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TMP_InputField inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataManager.Instance.LoadScore();
        DisplayHolder();
        inputField.onEndEdit.AddListener(HandleInput);
    }

    void HandleInput(string input)
    {
        Debug.Log("Player typed: " + input);
        DataManager.Instance.Player = input;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void DisplayHolder()
    {
        highscore.text = "Best Score: " + DataManager.Instance.Holder + " : " + DataManager.Instance.HighScore;
    }
}
