using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("데이터")]
    public MazeData data;

    private int width;
    private int height;

    private float cellWidth = 0.83f;
    private float cellHeight = 0.388f;

    public Cell cellPrefab;

    private Cell[,] cellMap;
    private List<Cell> cellHistoryList;

    private void Awake()
    {
        data.LoadDataFromPrefs();

        width = data.width;
        height = data.height;

    }

    void Start()
    {
        BatchCells();

        MakeMaze(cellMap[0,0]);
        cellMap[0, 0].isBackWall = false;
        cellMap[width - 1, height - 1].isForwardWall = false;
        cellMap[0, 0].ShowWalls();
        cellMap[width - 1, height - 1].ShowWalls();


    }

    private void BatchCells()
    {
        cellMap = new Cell[width, height];
        cellHistoryList = new List<Cell>();

        for(int x = 0; x <  width; x++)
        {
            for(int y = 0; y<height; y++)
            {
                Cell _cell = Instantiate<Cell>(cellPrefab, this.transform);
                _cell.index = new Vector2Int(x, y);
                _cell.name = "cell_" + x + "_" + y;
                _cell.transform.localPosition = new Vector3(x * cellWidth, cellHeight, y * cellWidth);

                cellMap[x, y] = _cell;
            }
        }
    }

    private void MakeMaze(Cell startCell)
    {
        Cell[] neighbors = GetNeighborCells(startCell);
        if(neighbors.Length > 0)
        {
            Cell nextCell = neighbors[Random.Range(0, neighbors.Length)];
            ConnectCells(startCell, nextCell);
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else
        {
            if(cellHistoryList.Count>0)
            {
                Cell lastCell = cellHistoryList[cellHistoryList.Count - 1];
                cellHistoryList.Remove(lastCell);
                MakeMaze(lastCell);
            }
        }
    }

    private Cell[] GetNeighborCells(Cell cell)
    {
        List<Cell> retCellList = new List<Cell>();
        Vector2Int index = cell.index;

        //forward
        if(index.y + 1 < height)
        {
            Cell neighbor = cellMap[index.x, index.y + 1];
            if(neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        //back
        if (index.y - 1 >= 0)
        {
            Cell neighbor = cellMap[index.x, index.y - 1];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        //left
        if (index.x - 1 >= 0)
        {
            Cell neighbor = cellMap[index.x - 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        // right
        if (index.x + 1 < width)
        {
            Cell neighbor = cellMap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }

        return retCellList.ToArray();
    }

    private void ConnectCells(Cell c0, Cell c1)
    {
        Vector2Int dir = c0.index - c1.index;

        //forward
        if(dir.y <= -1)
        {
            c0.isForwardWall = false;
            c1.isBackWall = false;
        }

        //back
        else if (dir.y >= 1)
        {
            c0.isBackWall = false;
            c1.isForwardWall = false;
        }

        //left
        else if (dir.x >= 1)
        {
            c0.isLeftWall = false;
            c1.isRightWall = false;
        }

        //right
        else if (dir.x <= -1)
        {
            c0.isRightWall = false;
            c1.isLeftWall = false;
        }

        c0.ShowWalls();
        c1.ShowWalls();
    }
}
