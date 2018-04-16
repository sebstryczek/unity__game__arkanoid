using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBricks : MonoBehaviour
{
    [SerializeField] private List<BrickType> brickTypes;
    [SerializeField] private GameObject prefabBrick;
    private float brickHeight = 0.25f;
    private float brickSpace = 0.15f;

    public BrickType GetRandomBrickType()
    {
        int rand = Random.Range(0, this.brickTypes.Count);
        return this.brickTypes[rand];
    }

    public void CreateBricks(State state, Area area)
    {
        float brickWidth = (area.Width - this.brickSpace) / area.Columns - this.brickSpace;
        float brickOffsetY = area.Height / 2 - this.brickSpace - this.brickHeight / 2;
        
        int [][] rows = state.fields;
        for (int i = 0; i < rows.Length; i++)
        {
            int[] rowColumns = state.fields[i];
            float brickOffsetX = (brickWidth + this.brickSpace) * (rowColumns.Length - 1) / 2;
            for (int j = 0; j < rowColumns.Length; j++)
            {
                BrickType brickType = this.brickTypes.Find(x => x.Id == rowColumns[j]);
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
