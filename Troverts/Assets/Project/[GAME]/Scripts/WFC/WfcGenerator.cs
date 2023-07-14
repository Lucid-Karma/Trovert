using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WfcGenerator : MonoBehaviour
{
    public List<CellSO> cells = new List<CellSO> ();
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private int _moduleSize;
    private int firstCollapse;


    void Start()
    {
        Generate();
        firstCollapse = cells.Count / 2;

        CollapseCell(cells[firstCollapse]);
        FindNeighbors(cells[firstCollapse]);
        FindLowestEntropy(cells[firstCollapse]);
        GetDefiniteState(cells[firstCollapse]);

    }

    private void Generate()
    {
        for (int row = 0; row < _width; row++)
        {
            for (int col = 0; col < _length; col++)
            {
                CellSO cell = new CellSO();
                cell.cellPos = new Vector3(row, 0, col);
                cell.Row = row;
                cell.Column = col;
                cells.Add(cell);
            }
        }
    }

    int _row;
    int _col;
    private void FindNeighbors(CellSO cell)
    {
        _row = cell.Row;
        _col = cell.Column;

        // North
        if (_col > 0)
        {
            CellSO northNeighbor = cells.Find(cell => cell.Column == _col - 1 && cell.Row == _row && !cell.isCollapsed);
            cell.neighbors.Add(northNeighbor);
            UpdateCell(0, northNeighbor, cell);
        }

        // South
        if (_col < _length - 1)
        {
            CellSO southNeighbor = cells.Find(cell => cell.Column == _col + 1 && cell.Row == _row && !cell.isCollapsed);
            cell.neighbors.Add(southNeighbor);
            UpdateCell(1, southNeighbor, cell);
        }

        // East
        if (_row < _width - 1)
        {
            CellSO eastNeighbor = cells.Find(cell => cell.Column == _col && cell.Row == _row + 1 && !cell.isCollapsed);
            cell.neighbors.Add(eastNeighbor);
            UpdateCell(2, eastNeighbor, cell);
        }

        // West
        if (_row > 0)
        {
            CellSO westNeighbor = cells.Find(cell => cell.Column == _col && cell.Row == _row - 1 && !cell.isCollapsed);
            cell.neighbors.Add(westNeighbor);
            UpdateCell(3, westNeighbor, cell);
        }
    }

    int minNum;
    private CellSO FindLowestEntropy(CellSO currentCell)
    {
        CellSO lowestEntropy = new CellSO();
        minNum = currentCell.neighbors[0].modules.Count;

        for (int i = 1; i < currentCell.neighbors.Count; i++)
        {
            if(minNum > currentCell.neighbors[i].modules.Count)
            {
                minNum = currentCell.neighbors[i].modules.Count;
                lowestEntropy = currentCell.neighbors[i];
            }
        }

        return lowestEntropy;
    }

    private void UpdateCell(int i, CellSO neighborCell, CellSO cell)
    {
        //for (int i = 0; i < 4; i++) // 0=north, 1=south, 2=east, 3=west
        //{
            if (i % 2 == 0)
            {
                for (int j = 0; j < neighborCell.modules.Count; j++)
                {
                    if(neighborCell.modules[j].moduleType[i + 1] != cell.modules[0].moduleType[i])  // cell.modules[definiteState].moduleType[i]
                    {
                        neighborCell.modules.RemoveAt(j);
                    }
                }
            }
        //}
    }

    int randomModule;
    private GameObject GetDefiniteState(CellSO currentCell)
    {
        //CellSO cell = FindLowestEntropy(currentCell);

        randomModule = Random.Range(0, currentCell.modules.Count);
        currentCell.definiteState = randomModule;
        return currentCell.modules[randomModule].modulePrefab;
    }

    private void CollapseCell(CellSO currentCell)
    {
        currentCell.isCollapsed = true;
        GameObject obj = (GameObject)Instantiate(GetDefiniteState(currentCell), currentCell.cellPos, Quaternion.identity);
    }
}
