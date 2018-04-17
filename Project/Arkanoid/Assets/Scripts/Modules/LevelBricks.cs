using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBricks : MonoBehaviour
{
    [SerializeField] private List<BrickType> brickTypes;
    [SerializeField] private GameObject prefabBrick;
    private float brickHeight = 0.25f;
    private float brickSpace = 0.15f;
    private LevelArea levelArea;

    private void Awake()
    {
        this.levelArea = GetComponent<LevelArea>();
    }

    public int[][] GetRandomFieldsSet()
    {
        int[][] fields = new int[this.levelArea.Rows][];
        for (int i = 0; i < fields.Length; i++)
        {
            int columnsCount = Random.Range(1, this.levelArea.Columns);
            fields[i] = new int[columnsCount];
            for (int j = 0; j < fields[i].Length; j++)
            {
                BrickType brickType = this.GetRandomBrickType();
                fields[i][j] = brickType.Id;
            }
        }

        return fields;
    }

    private BrickType GetRandomBrickType()
    {
        int rand = Random.Range(0, this.brickTypes.Count);
        return this.brickTypes[rand];
    }

    public void CreateBricks(int[][] fields, Brick.OnBrickDestroy onBrickDestroy)
    {
        float areaWidth = this.levelArea.Width;
        float areaHeight = this.levelArea.Height;
        int areaColumns = this.levelArea.Columns;

        float brickWidth = (areaWidth - this.brickSpace) / areaColumns - this.brickSpace;
        float brickOffsetY = areaHeight / 2 - this.brickSpace - this.brickHeight / 2;
        
        for (int i = 0; i < fields.Length; i++)
        {
            int[] rowColumns = fields[i];
            float brickOffsetX = (brickWidth + this.brickSpace) * (rowColumns.Length - 1) / 2;
            for (int j = 0; j < rowColumns.Length; j++)
            {
                if (rowColumns[j] > -1)
                {
                    BrickType brickType = this.brickTypes.Find(x => x.Id == rowColumns[j]);
                    Transform brickTransform = Instantiate(this.prefabBrick).transform;
                    Brick brick = brickTransform.GetComponent<Brick>();
                    brick.SetType(brickType);
                    brick.SetCoords(i, j);
                    brick.onBrickDestroy += onBrickDestroy;
                    
                    float posX = (brickWidth + this.brickSpace) * j - brickOffsetX;
                    float posY = brickOffsetY - (this.brickHeight + this.brickSpace) * i;
                    brickTransform.position = new Vector3(posX, posY, 0);
                    brickTransform.localScale = new Vector3(brickWidth, this.brickHeight, 0);
                }
            }
        }
    }
}
