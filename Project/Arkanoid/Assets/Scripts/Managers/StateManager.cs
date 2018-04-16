using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    [SerializeField] private string saveFileName = "save.dat";

    public State CurrentState { get; private set; }
    public bool HasSavedState { get { return File.Exists(this.saveFilePath); } }

    private string saveFilePath;

    private void Awake()
    {
        this.saveFilePath = Application.persistentDataPath + "/" + this.saveFileName;
    }

    public void CreateEmptyState()
    {
        this.CurrentState = new State();
    }

    public void LoadState()
    {
        if (this.HasSavedState)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(this.saveFilePath, FileMode.Open);
            this.CurrentState = bf.Deserialize(stream) as State;
            stream.Close();
        }
    }

    public void SaveState()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(this.saveFilePath, FileMode.Create);
        bf.Serialize(stream, this.CurrentState);
        stream.Close();
    }

    public void DeleteState()
    {
        if (this.HasSavedState)
        {
            File.Delete(this.saveFilePath);
        }
    }
}