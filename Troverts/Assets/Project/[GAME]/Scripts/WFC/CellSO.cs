using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WFC/CellSO")]
public class CellSO : ScriptableObject 
{
    public List<ModuleSO> modules = new List<ModuleSO>();
    //[HideInInspector] public HashSet<CellSO> neighbors = new HashSet<CellSO>();
    [HideInInspector] public Vector3 cellPos;
    [HideInInspector] public bool isCollapsed = false;
    [HideInInspector] public int entropy = 0;

    public int Row { get; set; }
    public int Column { get; set; }
}
