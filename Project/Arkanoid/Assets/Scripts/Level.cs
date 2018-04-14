using System;

[Serializable]
public class Level
{
    public int rowsCount;
    public int columnsCount;
    public int[,] fields;

    public Level()
    {
    }

    public void GenerateLevel(BrickType[] brickTypes)
    {
        this.rowsCount = UnityEngine.Random.Range(5, 11);
        this.columnsCount = UnityEngine.Random.Range(5, 11);
        this.fields = new int[this.rowsCount, this.columnsCount];
        for (int i = 0; i < this.rowsCount; i++)
        {
            for (int j = 0; j < this.columnsCount; j++)
            {
                BrickType brickType = Utils.HelpersRandom.GetRandomFromArray(brickTypes);
                this.fields[i, j] = brickType.Id;
            }
        }
    }
}