using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public float Border { get; private set; }
    public float Width
    {
        get
        {
            return Utils.Viewport.Width - this.Border * 2;
        }
    }
    public float Height
    {
        get
        {
            return Utils.Viewport.Height - this.Border * 2;
        }
    }

    public Area(int rows, int columns, float border)
    {
        this.Rows = rows;
        this.Columns = columns;
        this.Border = border;
    }
}
