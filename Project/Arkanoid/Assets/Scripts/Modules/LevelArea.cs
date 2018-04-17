using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArea : MonoBehaviour
{
    [SerializeField] int rows = 6;
    [SerializeField] int columns = 10;
    [SerializeField] float border = 0.25f;
    [SerializeField] private GameObject prefabBorder;

    public int Rows { get { return this.rows; } }
    public int Columns { get { return this.columns; } }
    public float Border { get { return this.border; } }
    public float Width { get { return Utils.Viewport.Width - this.Border * 2; } }
    public float Height { get { return Utils.Viewport.Height - this.Border * 2; } }

    private void Start()
    {
        this.CreateBorder();
    }

    private void CreateBorder()
    {
        float maxVertical = (Utils.Viewport.Height - this.border) / 2;
        float maxHorizontal = (Utils.Viewport.Width - this.border) / 2;

        Transform top = Instantiate(this.prefabBorder).transform;
        top.position = new Vector2(0, maxVertical);
        top.localScale = new Vector2(Utils.Viewport.Width, this.border);

        Transform left = Instantiate(this.prefabBorder).transform;
        left.position = new Vector2(-maxHorizontal, 0);
        left.localScale = new Vector2(this.border, Utils.Viewport.Width);

        Transform right = Instantiate(this.prefabBorder).transform;
        right.position = new Vector2(maxHorizontal, 0);
        right.localScale = new Vector2(this.border, Utils.Viewport.Width);
    }
}
