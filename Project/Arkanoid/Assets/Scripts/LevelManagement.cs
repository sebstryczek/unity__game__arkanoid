using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    [SerializeField] private List<BrickType> brickTypes;
    [SerializeField] private GameObject prefabBrick;
    [SerializeField] private GameObject prefabBorder;
    
    private int areaRows = 5;
    private int areaColumns = 10;
    
    private float brickHeight = 0.25f;
    private float brickSpace = 0.15f;

    private float borderSize = 0.25f;

    private void Awake()
    {
        this.CreateBorder();
    }

    private void CreateBorder()
    {
        Transform top = Instantiate(this.prefabBorder).transform;
        float topPosY = (Utils.Viewport.Height - this.borderSize) / 2;
        top.position = new Vector2(0, topPosY);
        top.localScale = new Vector2(Utils.Viewport.Width, this.borderSize);

        Transform left = Instantiate(this.prefabBorder).transform;
        float leftPosX = -(Utils.Viewport.Width - this.borderSize) / 2;
        left.position = new Vector2(leftPosX, 0);
        left.localScale = new Vector2(this.borderSize, Utils.Viewport.Width);

        Transform right = Instantiate(this.prefabBorder).transform;
        float rightPosX = (Utils.Viewport.Width - this.borderSize) / 2;
        right.position = new Vector2(rightPosX, 0);
        right.localScale = new Vector2(this.borderSize, Utils.Viewport.Width);
    }

    public int[][] GetRandomFieldsSet()
    {
        int[][] fields = new int[this.areaRows][];
        for (int i = 0; i < this.areaRows; i++)
        {
            fields[i] = new int[this.areaColumns];
            int columnsCount = Random.Range(0, this.areaColumns);
            for (int j = 0; j < columnsCount; j++)
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

    public void CreateBricks(State state)
    {
        float areaWidth = Utils.Viewport.Width - this.borderSize * 2;
        float brickWidth = (areaWidth - this.brickSpace) / this.areaColumns - this.brickSpace;
        
        float brickOffsetX = Utils.Viewport.Width / 2 - this.borderSize - this.brickSpace - brickWidth / 2;
        float brickOffsetY = Utils.Viewport.Height / 2 - this.borderSize - this.brickSpace - this.brickHeight / 2;

        for (int i = 0; i < this.areaRows; i++)
        {
            int columnsCount = state.fields[i].Length;
            int[] rowItems = System.Array.FindAll(state.fields[i], x => x > 0);
            Debug.Log(rowItems.Length);
            brickOffsetX = (rowItems.Length * (brickWidth + this.brickSpace)+  this.brickSpace) / 2;
            //1 0.5
            for (int j = 0; j < rowItems.Length; j++)
            {
                BrickType brickType = this.brickTypes.Find(x => x.Id == rowItems[j]);
                Transform brickTransform = Instantiate(this.prefabBrick).transform;
                Brick brick = brickTransform.GetComponent<Brick>();
                brick.SetType(brickType);


                    float posX = (brickWidth + this.brickSpace) * j - brickOffsetX;
                    float posY = brickOffsetY - (this.brickHeight + this.brickSpace) * i;
                    brickTransform.position = new Vector3(posX, posY, 0);
                    brickTransform.localScale = new Vector3(brickWidth, this.brickHeight, 0);
            }
        }
    }
}