using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer (UIManager uiManager)
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");
        
        Debug.Log("Saving player");
        PlayerData data = new PlayerData(uiManager);
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = File.Create("Saves/saveData.bin");
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static PlayerData LoadPlayer ()
    {
        Debug.Log("Loading player");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open("Saves/saveData.bin", FileMode.Open);
        PlayerData data = (PlayerData) formatter.Deserialize(stream);
        Debug.Log("Score : " + data.score);
        stream.Close();
        return data;
    }
}
