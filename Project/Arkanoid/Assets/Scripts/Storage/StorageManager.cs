using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StorageManager<T, TStorage> : Singleton<T> where T : MonoBehaviour where TStorage : new()
{
    protected string fileName;
    protected Storage<TStorage> storage;

    public bool IsFileExist { get { return this.storage.IsFileExist; } }
    public bool IsStateExist { get { return this.storage.State != null; } }

    protected virtual void Awake()
    {
        string filePath = Application.persistentDataPath + "/" + this.fileName;
        this.storage = new Storage<TStorage>(filePath);
    }

    public void Create()
    {
        this.storage.Create();
    }

    public void RemoveFile()
    {
        this.storage.RemoveFile();
    }

    public void SaveToFile()
    {
        this.storage.SaveToFile();
    }

    public void LoadFromFile()
    {
        this.storage.LoadFromFile();
    }
}
