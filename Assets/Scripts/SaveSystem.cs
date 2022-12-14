using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
public static class SaveSystem
{
    private static readonly string path = Path.Combine(Application.persistentDataPath, "player.fun");

    public static void SavePlayer(Player player)
    {
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryWriter writer = new BinaryWriter(stream);

        PlayerData data = PlayerData.FromPlayer(player);

        if (data.Position == null)
        {
            writer.Write(0);
        }
        else
        {
            writer.Write(data.Position.Length);
            foreach (var value in data.Position)
            {
                writer.Write(value);
            }
        }

        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if (!File.Exists(path))
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

        FileStream stream = new FileStream(path, FileMode.Open);
        BinaryReader reader = new BinaryReader(stream);

        PlayerData data = new PlayerData();

        int length = reader.ReadInt32();
        data.Position = new float[length];
        for (int index = 0; index < length; index++)
        {
            data.Position[index] = reader.ReadSingle();
        }

        stream.Close();

        return data;
    }
}
