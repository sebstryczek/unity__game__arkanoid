
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour
{
    private SaveLoadSystem saveLoadSystem;
    private LevelManagement levelManagement;
    private GameState state;
    
    private void Awake()
    {
        this.saveLoadSystem = GetComponent<SaveLoadSystem>();
        this.levelManagement = GetComponent<LevelManagement>();
    }

    private void Start()
    {
        if (this.saveLoadSystem.HasSavedState)
        {
            this.state = this.saveLoadSystem.Load();
        }
        else
        {
            this.state = new GameState();
            this.state.fields = this.levelManagement.GetRandomFieldsSet();
        }

        this.levelManagement.CreateBricks(this.state);
    }
}
