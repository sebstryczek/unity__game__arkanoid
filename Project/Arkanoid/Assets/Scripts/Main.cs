using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour
{
    [SerializeField] private List<BrickType> brickTypes;
    [SerializeField] private GameObject prefabBrick;

    private Level currentLevel;
    
    private void Start()
    {
        this.currentLevel = new Level();
        this.currentLevel.GenerateLevel(this.brickTypes.ToArray());
        this.CreateBricks();
    }

    private void CreateBricks()
    {
        for (int i = 0; i < this.currentLevel.rowsCount; i++)
        {
            for (int j = 0; j < this.currentLevel.columnsCount; j++)
            {
                GameObject go = Instantiate(this.prefabBrick);
                BrickType brickType = this.GetBrickTypeById(this.currentLevel.fields[i, j]);
                go.GetComponent<SpriteRenderer>().material.color = brickType.Tint;

                float screenRatio = (float)Screen.width / Screen.height;
                float viewportHeight = Camera.main.orthographicSize * 2;
                float viewportWidth = viewportHeight * screenRatio;
                float halfViewportHeight = viewportHeight / 2;
                float halfViewportWidth = viewportWidth / 2;

                float brickWidth = go.GetComponent<BoxCollider2D>().bounds.size.x;
                float brickHeight = go.GetComponent<BoxCollider2D>().bounds.size.y;

                float xPos = brickWidth * j + 0.1f * j - ((brickWidth + 0.1f) * (this.currentLevel.columnsCount - 1)) / 2;
                float yPos = halfViewportHeight - 1 - brickHeight * i - 0.1f * i;

                go.transform.position = new Vector3(xPos, yPos, 0);
            }
        }
    }

    private BrickType GetBrickTypeById(int id)
    {
        return this.brickTypes.Find(x => x.Id == id);
    }
}
