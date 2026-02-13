#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataManager.Instance.LoadFile();
        title.text = "Best Score : " + DataManager.Instance.BestScoreName + " : " + DataManager.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClicked()
    {
        DataManager.Instance.Name = nameText.text;
        SceneManager.LoadScene(1);
    }
    public void QuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
