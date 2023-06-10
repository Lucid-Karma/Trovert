using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager //: Singleton<CutsceneManager>
{
    // Array of game objects that are involved in the cutscene 
    //public GameObject[] actors; 
    private List<GameObject> actors = new List<GameObject>();

    public void DetermineActors(GameObject actor)
    {
        actors.Add(actor);
    }
}
