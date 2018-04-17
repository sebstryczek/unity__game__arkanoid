using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private UnityEvent onWin;
    [SerializeField] private UnityEvent onLose;

    private Area area = new Area(1, 4, 0.25f);
    private LevelBorders levelBorders;
    private LevelBricks levelBricks;
    private LevelSpeed levelSpeed;
    private LevelUI levelUI;
    

    private void Awake()
    {
        this.levelBorders = GetComponent<LevelBorders>();
        this.levelBricks = GetComponent<LevelBricks>();
        this.levelSpeed = GetComponent<LevelSpeed>();
        this.levelUI = GetComponent<LevelUI>();
    }

    private void Start()
    {
        // In build, state is created in menu
        if (Application.isEditor && !GameStateManager.Instance.IsStateExist)
        {
            GameStateManager.Instance.Create();
        }
        
        GameStateManager.Instance.onSetLives += this.levelUI.SetLivesUI;
        GameStateManager.Instance.onSetScore += this.levelUI.SetScoreUI;

        if (GameStateManager.Instance.State.fields == null)
        {
            int[][] fields = this.GetRandomFieldsSet();
            GameStateManager.Instance.SetFields(fields);
            GameStateManager.Instance.SetLives(3);
            GameStateManager.Instance.SetScore(0);
            GameStateManager.Instance.SetTimeFactor(1);
        }


        this.levelBorders.CreateBorder(this.area);
        this.levelBricks.CreateBricks(GameStateManager.Instance.State, this.area, this.OnBrickHitted);
    }


    private void OnDestroy()
    {
        GameStateManager.Instance.onSetLives -= this.levelUI.SetLivesUI;
        GameStateManager.Instance.onSetScore -= this.levelUI.SetScoreUI;
    }

    private void OnBrickHitted(Brick brick)
    {
        GameStateManager.Instance.State.fields[brick.Row][brick.Column] = -1;
        GameStateManager.Instance.SetScore(GameStateManager.Instance.State.score + brick.Type.Points);
        GameStateManager.Instance.SetLives(GameStateManager.Instance.State.lives + brick.Type.BonusLives);

        this.levelSpeed.SetSpeed(brick.Type.Speed, brick.Type.SpeedDuration);

        int[][] fields = GameStateManager.Instance.State.fields;
        for (int i = 0; i < fields.Length; i++)
        {
            for (int j = 0; j < fields[i].Length; j++)
            {
                if (fields[i][j] > -1)
                {
                    return;
                }
            }
        }

        this.LevelComplete();
    }

    private void LevelComplete()
    {
        int[][] fields = this.GetRandomFieldsSet();
        GameStateManager.Instance.SetFields(fields);
        this.levelBricks.CreateBricks(GameStateManager.Instance.State, this.area, this.OnBrickHitted);
        
        this.onWin.Invoke();
    }

    public void Died()
    {
        GameStateManager.Instance.SetLives(GameStateManager.Instance.State.lives - 1);
    
        if (GameStateManager.Instance.State.lives < 0)
        {
            this.onLose.Invoke();
            return;
        }
    }

    private int[][] GetRandomFieldsSet()
    {
        int[][] fields = new int[this.area.Rows][];
        for (int i = 0; i < fields.Length; i++)
        {
            int columnsCount = Random.Range(1, this.area.Columns);
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
