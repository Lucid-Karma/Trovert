using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WfcGenerator : MonoBehaviour
{
    private List<CellSO> cells = new List<CellSO> ();
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private int _moduleSize;
    private int firstCollapse;


    void Start()
    {
        Generate();
        firstCollapse = cells.Count / 2;

        cells[firstCollapse].isCollapsed = true;
        GameObject obj = (GameObject)Instantiate(GetDefiniteState(cells[firstCollapse]), cells[firstCollapse].cellPos, Quaternion.identity);

        CollapseGrid();

    }

    private void Generate()
    {
        for (int row = 0; row < _width; row++)
        {
            for (int col = 0; col < _length; col++)
            {
                CellSO cell = ScriptableObject.CreateInstance<CellSO>(); // Use "CreateInstance" method for scriptableObjects not "new CellSO();"
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
        // 0=north, 1=south, 2=east, 3=west

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
    }

    int randomModule;
    private GameObject GetDefiniteState(CellSO currentCell)
    {
        if (currentCell.modules.Count > 0)
        {
            randomModule = Random.Range(0, currentCell.modules.Count);
            currentCell.definiteState = randomModule;
            ModuleSO selectedModule = currentCell.modules[randomModule];
            
            if (selectedModule != null)
            {
                GameObject modulePrefab = selectedModule.modulePrefab;

                if (modulePrefab != null)
                {
                    //return Instantiate(modulePrefab, currentCell.cellPos, Quaternion.identity);
                    return modulePrefab;
                }
                else
                {
                    Debug.LogWarning("modulePrefab is not assigned in the selected ModuleSO.");
                    return null; // or return a default GameObject if you have one.
                }
            }
            else
            {
                Debug.LogWarning("Selected ModuleSO is null.");
                return null; // or return a default GameObject if you have one.
            }
        }
        else
        {
            Debug.LogWarning("No modules attached to the current cell.");
            return null; // or return a default GameObject if you have one.
        }
    }



    private void CollapseCell(CellSO nextCell)
    {
        nextCell.isCollapsed = true;
        GameObject obj = (GameObject)Instantiate(GetDefiniteState(FindLowestEntropy(nextCell)), nextCell.cellPos, Quaternion.identity);
    }

    private void CollapseGrid()
    {
        while(cells.Any(y => !y.isCollapsed))
        {
            if(cells.Where(x => x.isCollapsed).Any())
            {
                var cell = cells.Find(x => x.isCollapsed);

                FindNeighbors(cell);
                CollapseCell(cell);
            } 
        }
    }
}
