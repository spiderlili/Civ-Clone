using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;
    public HexCell hexCellPrefab;
    [Tooltip("Default planes are 10 by 10 units.")]
    public float cellOffsetDistance = 10f;
    HexCell[] cells;

    public TMP_Text cellLabelTextPrefab;
    [SerializeField] private Canvas gridCanvas;

    void Awake()
    {
        gridCanvas = gameObject.GetComponentInChildren<Canvas>();
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
        position.x = x * cellOffsetDistance;
        position.y = 0f;
        position.z = z * cellOffsetDistance;

        //construct hex grid with hex cells
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

        //debug coordinates of the cells
        if (gridCanvas != null)
        {
            if (cellLabelTextPrefab != null)
            {
                TMP_Text label = Instantiate<TMP_Text>(cellLabelTextPrefab);
                label.rectTransform.SetParent(gridCanvas.transform, false);
                label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
                label.text = x.ToString() + "\n" + z.ToString();
            }
            else
            {
                Debug.Log("text label prefab has not been assigned");
            }
        }
        else
        {
            Debug.Log("Grid canvas is null");
        }
    }
}