using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WfcGenerator : MonoBehaviour
{
    private List<CellSO> cells = new List<CellSO> ();
    public CellSO Cell;
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private int _moduleSize;
    private int firstCollapse;


    void Start()
    {
        Generate();
        
        StartWave();

        CollapseGrid();

    }

    private void StartWave()
    {
        firstCollapse = cells.Count / 2;
        
        cells[firstCollapse].isCollapsed = true;

        randomModule = Random.Range(0, cells[firstCollapse].modules.Count);
        ModuleSO selectedModule = cells[firstCollapse].modules[randomModule];

        cells[firstCollapse].modules.RemoveAll(module => module !=selectedModule);

        GameObject obj = (GameObject)Instantiate(GetDefiniteState(cells[firstCollapse]), cells[firstCollapse].cellPos, prefabRotation);

        for (int i = 0; i < cells[firstCollapse].modules.Count; i++)
        {
            Debug.Log(i + " first cell's module info is: " + cells[firstCollapse].modules[i].modulePrefab.name);
        }
    }

    private void Generate()
    {
        CellSO originalCell = Cell;

        for (int row = 0; row < _width; row++)
        {
            for (int col = 0; col < _length; col++)
            {
                CellSO cell = ScriptableObject.CreateInstance<CellSO>();    // Use "CreateInstance" method for scriptableObjects not "new CellSO();"
                cell.modules = new List<ModuleSO>(originalCell.modules);
                cell.cellPos = new Vector3(row * _moduleSize, 0, col * _moduleSize * -1);   
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
            CellSO northNeighbor = cells.Find(c => c.Column == _col - 1 && c.Row == _row && !c.isCollapsed);
            cell.neighbors.Add(northNeighbor);
            //Debug.Log("nothNeighbor num is: " + cells.IndexOf(northNeighbor));
            UpdateCell(0, northNeighbor, cell);
        }

        // South
        if (_col < _length - 1)
        {
            CellSO southNeighbor = cells.Find(c => c.Column == _col + 1 && c.Row == _row && !c.isCollapsed);
            cell.neighbors.Add(southNeighbor);
            UpdateCell(1, southNeighbor, cell);
        }

        // East
        if (_row < _width - 1)
        {
            CellSO eastNeighbor = cells.Find(c => c.Column == _col && c.Row == _row + 1 && !c.isCollapsed);
            cell.neighbors.Add(eastNeighbor);
            UpdateCell(2, eastNeighbor, cell);
        }

        // West
        if (_row > 0)
        {
            CellSO westNeighbor = cells.Find(c => c.Column == _col && c.Row == _row - 1 && !c.isCollapsed);
            cell.neighbors.Add(westNeighbor);
            UpdateCell(3, westNeighbor, cell);
        }
    }

    private CellSO FindLowestEntropy(CellSO currentCell)
    {
        CellSO lowestEntropy = ScriptableObject.CreateInstance<CellSO>();
        
        lowestEntropy = currentCell.neighbors.OrderBy(list => list.modules.Count).FirstOrDefault();

        var lowestEntropies = currentCell.neighbors.Where(num => num == lowestEntropy).ToList();
        int lowestEntropyIndex = Random.Range(0, lowestEntropies.Count);
        //Debug.Log("lowestEntropy's neighbor index is: " + currentCell.neighbors.IndexOf(lowestEntropy));
        return lowestEntropies[lowestEntropyIndex];
    }

    private void UpdateCell(int direction, CellSO neighborCell, CellSO cell)
    {
        // 0=north, 1=south, 2=east, 3=west

        List<ModuleSO> modulesCopy = new List<ModuleSO>(neighborCell.modules);

        foreach (ModuleSO possibleModule in modulesCopy)
        {
            if (!IsMatching(direction, possibleModule, cell.modules[0]))    //cell.modules[0] represents the last remaining cell.
            {
                neighborCell.modules.Remove(possibleModule);
            }
        }

        Debug.Log("Neighbor's module count is: " + neighborCell.modules.Count);
    }

private bool IsMatching(int direction, ModuleSO neighborModule, ModuleSO cellModule)
{
    if (direction == 0) // North
        return neighborModule.south == cellModule.north;

    if (direction == 1) // South
        return neighborModule.north == cellModule.south;

    if (direction == 2) // East
        return neighborModule.west == cellModule.east;

    if (direction == 3) // West
        return neighborModule.east == cellModule.west;

    return false;
}




    int randomModule;
    private GameObject GetDefiniteState(CellSO currentCell)
    {
        if (currentCell == null)
        {
            Debug.Log("cell is null in GetDefiniteState");
        }

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
                    prefabRotation = modulePrefab.transform.rotation;
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

    Quaternion prefabRotation;

    private void CollapseCell(CellSO nextCell)
    {
        nextCell = FindLowestEntropy(nextCell);
        nextCell.isCollapsed = true;
        GameObject obj = (GameObject)Instantiate(GetDefiniteState(nextCell), nextCell.cellPos, prefabRotation);
    }

    private void CollapseGrid()
    {
        // while(cells.Any(y => !y.isCollapsed))
        // {
            for (int i = 0; i < 4; i++)
            {
                if(cells.Where(x => x.isCollapsed).Any())
                {
                    var cell = cells.Find(x => x.isCollapsed);
    
                    //Debug.Log("cell num is: " + cells.IndexOf(cell));
    
                    FindNeighbors(cell);
                    CollapseCell(cell);
    
                    Debug.Log("collapsed cell is found");
                } 
            }
        // }
    }
    
    // private void CollapseGrid()
    // {
    //     // while (cells.Any(y => !y.isCollapsed))
    //     // {
    //         var cell = cells.Find(x => x.isCollapsed == false);

    //         if (cell != null)
    //         {
    //             FindNeighbors(cell);
    //             CollapseCell(cell);
    //         }
    //         // else
    //         // {
    //         //     // Handle case when there are no more cells to collapse
    //         //     break;
    //         // }
    //     // }
    // }

}
