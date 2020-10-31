using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;
    public HexCell hexCellPrefab;

    HexCell[] cells;

    void Awake()
    {
        cells = new HexCell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = x * 10f;
        position.y = 0f;
        position.z = z * 10f;

        if (hexCellPrefab != null)
        {
            HexCell cell = cells[i] = Instantiate<HexCell>(hexCellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
        }
        else
        {
            Debug.Log("hexCellPrefab has not been assigned! Cannot create hex grid");
        }

    }
}