using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    string selectedCharacter = PlayerPrefs.GetString("selected_character");
    int selectedDifficulty = PlayerPrefs.GetInt("selected_difficulty");
}
