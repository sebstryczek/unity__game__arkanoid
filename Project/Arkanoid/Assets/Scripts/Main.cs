
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour
{
    private LevelManagement levelManagement;
    
    private void Awake()
    {
        this.levelManagement = GetComponent<LevelManagement>();
    }

    private void Start()
    {
        if (StateManager.Instance.CurrentState == null)
        {
            StateManager.Instance.CreateEmptyState();
        }

        if (StateManager.Instance.CurrentState.fields == null)
        {
            int[][] fields = this.levelManagement.GetRandomFieldsSet();
            StateManager.Instance.CurrentState.fields = fields;
            StateManager.Instance.SaveState();
        }

        this.levelManagement.CreateBricks(StateManager.Instance.CurrentState);
    }
}
