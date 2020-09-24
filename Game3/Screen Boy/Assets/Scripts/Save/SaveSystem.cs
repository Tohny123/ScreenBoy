using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public string filename;
    
    public static void Save (GameManager gameman, string filename)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + filename;
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(gameman);
        formatter.Serialize(stream, data);
        stream.Close();
    }

public static PlayerData Load (GameManager gameman, string filename) 
{
    
string path = Application.persistentDataPath + filename;
if (File.Exists(path))
{
BinaryFormatter formatter = new BinaryFormatter();
FileStream stream = new FileStream(path, FileMode.Open);
PlayerData data = formatter.Deserialize(stream) as PlayerData;
stream.Close();
return data;
}
else
{
    Save(gameman, filename);
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream stream = new FileStream(path, FileMode.Open);
    PlayerData data = formatter.Deserialize(stream) as PlayerData;
    stream.Close();
    return data;
    Debug.Log ("Save Not Found");
}
}

}
