using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    //general data

    public static void SaveData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.tito";
        FileStream stream = new FileStream(path, FileMode.Create);


        SavedData data = new SavedData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }
    public static SavedData LoadData()
    {
        string path = Application.persistentDataPath + "/save.tito";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData data =  formatter.Deserialize(stream) as SavedData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //Controles
    public static void SaveControls(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/controls.tito";
        FileStream stream = new FileStream(path, FileMode.Create);


        ControlesSave data = new ControlesSave(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static ControlesSave LoadControls()
    {
        string path = Application.persistentDataPath + "/controls.tito";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ControlesSave data = formatter.Deserialize(stream) as ControlesSave;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("controls file not found in " + path);
            return null;
        }
    }
}
