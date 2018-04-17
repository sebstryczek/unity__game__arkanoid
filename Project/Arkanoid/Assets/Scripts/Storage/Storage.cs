using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Storage<T> where T : new()
{
    public T State { get; private set; }
    private string filePath;

    public Storage(string filePath)
    {
        this.filePath = filePath;
    }
    
    public bool IsFileExist { get { return File.Exists(this.filePath); } }

    public void Create()
    {
        this.State = new T();
    }

    public void RemoveFile()
    {
        if (this.IsFileExist)
        {
            File.Delete(this.filePath);
        }
    }

    public void LoadFromFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(this.filePath, FileMode.Open);
        this.State = (T)bf.Deserialize(stream);
        stream.Close();
    }

    public void SaveToFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(this.filePath, FileMode.Create);
        bf.Serialize(stream, this.State);
        stream.Close();
    }
}
