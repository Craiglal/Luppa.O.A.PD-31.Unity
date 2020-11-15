using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerSystem player, Weapon weapon)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(player, weapon);
        binaryFormatter.Serialize(fileStream, playerData);

        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.LogError("Save is not found: " + path);
            return null;
        }
    }
}
