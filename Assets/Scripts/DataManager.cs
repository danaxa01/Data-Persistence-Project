using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int HighScore;
    public string Holder, Player;

    void Awake()
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
    class SaveData
    {
        public int HighScore;
        public string Holder;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.Holder = Holder;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            Holder = data.Holder;
        }
    }
}
