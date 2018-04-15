using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private string saveFileName = "save.dat";
    private string saveFilePath;

    public bool HasSavedState { get { return File.Exists(this.saveFilePath); } }

    private void Awake()
    {
        this.saveFilePath = Application.persistentDataPath + "/" + this.saveFileName;
    }
    
    public GameState Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(this.saveFilePath, FileMode.Open);
        GameState state = bf.Deserialize(stream) as GameState;
        stream.Close();
        return state;
    }

    public void Save(GameState state)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(this.saveFilePath, FileMode.Create);
        bf.Serialize(stream, state);
        stream.Close();
    }
}