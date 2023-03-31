using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellData 
{
    public static readonly Vector2[] cellSides = new Vector2[4] 
    {

		new Vector2 (1.0f, 0.0f),   // +X
		new Vector2 (0.0f, 1.0f),   // +Z
		new Vector2 (-1.0f, 0.0f),  // -X
		new Vector2 (0.0f, -1.0f)   // -Z

	};

    // public static readonly int[,] voxelTris = new int[6,4] 	
    // {
	// 	// 0 1 2 2 1 3
	// 	{0, 3, 1, 2}, // Back Face
	// 	{5, 6, 4, 7}, // Front Face
	// 	{3, 7, 2, 6}, // Top Face
	// 	{1, 5, 0, 4}, // Bottom Face
	// 	{4, 7, 0, 3}, // Left Face
	// 	{1, 2, 5, 6} // Right Face

	// };
}
