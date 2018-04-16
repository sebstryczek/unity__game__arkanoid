using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private GameObject prefabBorder;

    public void CreateBorder(Area area)
    {
        float maxVertical = (Utils.Viewport.Height - area.Border) / 2;
        float maxHorizontal = (Utils.Viewport.Width - area.Border) / 2;

        Transform top = Instantiate(this.prefabBorder).transform;
        top.position = new Vector2(0, maxVertical);
        top.localScale = new Vector2(Utils.Viewport.Width, area.Border);

        Transform left = Instantiate(this.prefabBorder).transform;
        left.position = new Vector2(-maxHorizontal, 0);
        left.localScale = new Vector2(area.Border, Utils.Viewport.Width);

        Transform right = Instantiate(this.prefabBorder).transform;
        right.position = new Vector2(maxHorizontal, 0);
        right.localScale = new Vector2(area.Border, Utils.Viewport.Width);
    }
}
