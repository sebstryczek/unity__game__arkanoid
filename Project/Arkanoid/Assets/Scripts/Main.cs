
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour
{
    private Area area = new Area(5, 10, 0.25f);
    private LevelBorders levelBorders;
    private LevelBricks levelBricks;

    private void Awake()
    {
        this.levelBorders = GetComponent<LevelBorders>();
        this.levelBricks = GetComponent<LevelBricks>();
    }

    private void Start()
    {
        if (StateManager.Instance.CurrentState == null)
        {
            StateManager.Instance.CreateEmptyState();
        }

        if (StateManager.Instance.CurrentState.fields == null)
        {
            int[][] fields = this.GetRandomFieldsSet();
            StateManager.Instance.CurrentState.fields = fields;
            StateManager.Instance.SaveState();
        }

        this.levelBorders.CreateBorder(this.area);
        this.levelBricks.CreateBricks(StateManager.Instance.CurrentState, this.area);
    }
    
    public int[][] GetRandomFieldsSet()
    {
        int[][] fields = new int[this.area.Rows][];
        for (int i = 0; i < fields.Length; i++)
        {
            int columnsCount = Random.Range(0, this.area.Columns);
            fields[i] = new int[columnsCount];
            for (int j = 0; j < fields[i].Length; j++)
            {
                BrickType brickType = this.levelBricks.GetRandomBrickType();
                fields[i][j] = brickType.Id;
            }
        }

        return fields;
    }
}
