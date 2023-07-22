using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WfcGenerator : MonoBehaviour
{
    private List<CellSO> cells = new List<CellSO> ();
    private List<CellSO> candidateCells = new List<CellSO>();
    public CellSO Cell; //.......................A CellSO reference with modules defined.
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private int _moduleSize;


    private int firstCollapse; //................The index of the first cell to be created in the list.
    Quaternion prefabRotation;

    int _row;   
    int _col;

    int lowestEntropyValue; //...................Lowest usage value of modules among cells to Find_Lowest_Entropy and to Get_Definite_State.
    int randomModule; //.........................Selected cell's random module index to Get_Definite_State.


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
        //Debug.Log("Starting wave. Collapsed cell is: " + firstCollapse);

        GameObject obj = (GameObject)Instantiate(GetDefiniteState(cells[firstCollapse]), cells[firstCollapse].cellPos, prefabRotation);
    }

    private void Generate()
    {
        CellSO originalCell = Cell;

        for (int row = 0; row < _width; row++)
        {
            for (int col = 0; col < _length; col++)
            {
                CellSO cell = ScriptableObject.CreateInstance<CellSO>();
                cell.modules = new List<ModuleSO>(originalCell.modules);
                cell.cellPos = new Vector3(row * _moduleSize, 0, col * _moduleSize * -1);   
                cell.Row = row;
                cell.Column = col;

                cells.Add(cell);
            }
        }
        //Debug.Log("Grid generated. Cell count: " + cells.Count);
    }
    
    private void FindNeighbors(CellSO cell)
    {
        _row = cell.Row;
        _col = cell.Column;

        // North
        if (_col > 0 )
        {
            CellSO northNeighbor = cells.Find(c => c.Column == _col - 1 && c.Row == _row && !c.isCollapsed);
            if (northNeighbor != null)
            {
                UpdateCell(0, northNeighbor, cell);

                if (!candidateCells.Contains(northNeighbor))
                {
                    candidateCells.Add(northNeighbor);
                }
            }
        }

        // South
        if (_col < _length - 1 )
        {
            CellSO southNeighbor = cells.Find(c => c.Column == _col + 1 && c.Row == _row && !c.isCollapsed);
            if (southNeighbor != null)
            {
                UpdateCell(1, southNeighbor, cell);

                if (!candidateCells.Contains(southNeighbor))
                {
                    candidateCells.Add(southNeighbor);
                }
            }
        }

        // East
        if (_row < _width - 1 )
        {
            CellSO eastNeighbor = cells.Find(c => c.Column == _col && c.Row == _row + 1 && !c.isCollapsed);
            if (eastNeighbor != null)
            {
                UpdateCell(2, eastNeighbor, cell);

                if (!candidateCells.Contains(eastNeighbor))
                {
                    candidateCells.Add(eastNeighbor);
                }
            }
        }

        // West
        if (_row > 0)
        {
            CellSO westNeighbor = cells.Find(c => c.Column == _col && c.Row == _row - 1 && !c.isCollapsed);
            if (westNeighbor != null)
            {
                UpdateCell(3, westNeighbor, cell);

                if (!candidateCells.Contains(westNeighbor))
                {
                    candidateCells.Add(westNeighbor);
                }
            }
        }
    }

    private CellSO FindLowestEntropy()
    {
        int lowestModuleCount = candidateCells.Min(list => list.modules.Count); 

        var lowestEntropies = candidateCells.Where(num => num.modules.Count == lowestModuleCount).ToList();

        if(lowestEntropies.Count > 1)
        {
            lowestEntropyValue = lowestEntropies.Min(x => x.entropy);
            var lowestEntropyValues = lowestEntropies.Where(entropyValue => entropyValue.entropy == lowestEntropyValue).ToList();

            if(lowestEntropyValues.Count > 1)    return lowestEntropyValues[Random.Range(0, lowestEntropyValues.Count)];
            else    return lowestEntropies.Find(y => y.entropy == lowestEntropyValue);  // or lowestEntropyValues[0] ...first and only element.
        }
        else
        {
            return lowestEntropies[0];
        }
    }

    private void UpdateCell(int direction, CellSO neighborCell, CellSO cell)
    {
        // 0=north, 1=south, 2=east, 3=west

        neighborCell.modules.RemoveAll(possibleModule => !IsMatching(direction, possibleModule, cell.modules[0]));  //cell.modules[0] represents the last remaining cell.

        neighborCell.entropy = neighborCell.modules.Sum(x => x.moduleUsageCount);
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

    private GameObject GetDefiniteState(CellSO currentCell)
    {
        if (currentCell.modules.Count > 0)
        {   
            ModuleSO selectedModule;
            if (currentCell.modules.Where(x => x.moduleUsageCount == lowestEntropyValue).Any())
            {
                selectedModule = currentCell.modules.Find(x => x.moduleUsageCount == lowestEntropyValue);
            }
            else
            {
                randomModule = Random.Range(0, currentCell.modules.Count);
                selectedModule = currentCell.modules[randomModule];
            }

            currentCell.modules.RemoveAll(module => module !=selectedModule);
            
            if (selectedModule != null)
            {
                GameObject modulePrefab = selectedModule.modulePrefab;

                if (modulePrefab != null)
                {
                    selectedModule.moduleUsageCount ++;
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

    private void CollapseCell()
    {
        CellSO nextCell;
        nextCell = FindLowestEntropy();
        nextCell.isCollapsed = true;
        GameObject obj = (GameObject)Instantiate(GetDefiniteState(nextCell), nextCell.cellPos, prefabRotation);
        //Debug.Log("cell index is: " + candidateCells.IndexOf(nextCell));
        candidateCells.Remove(nextCell);
        //Debug.Log("Cell collapsed. CandidateCells count: " + candidateCells.Count);

        FindNeighbors(nextCell);
    }

    private void CollapseGrid()
    {
        if(cells.Where(x => x.isCollapsed).Any())
        {
            var cell = cells.Find(x => x.isCollapsed);

            FindNeighbors(cell);
        } 

        while (cells.Where(x => !x.isCollapsed).Any())
        {
            if (candidateCells.Count > 0)
            {
                CollapseCell();
            }
            else
            {
                break;
            }
        }
        //Debug.Log("All cells are collapsed.");
    }
            
}
