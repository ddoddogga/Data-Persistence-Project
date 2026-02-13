using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name;
    public int BestScore;
    public string BestScoreName;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public int BestScore;
        public string BestScoreName;
    }

    public void SaveFile()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;
        }
    }
}
