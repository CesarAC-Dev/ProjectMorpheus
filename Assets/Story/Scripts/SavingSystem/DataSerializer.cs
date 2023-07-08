using UnityEngine;

public static class DataSerializer
{
    private const string SaveKey = "gameData";

    public static void SaveGameData(GameData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, jsonData);
        PlayerPrefs.Save();
    }

    public static GameData LoadGameData()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string jsonData = PlayerPrefs.GetString(SaveKey);
            return JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            Debug.LogWarning("No se ha encontrado ningún dato guardado.");
            return null;
        }
    }
}