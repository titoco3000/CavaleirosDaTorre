using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public int maxLevel;
    public int currentLevel;

    public SavedData(GameManager gameManager)
    {
        maxLevel = gameManager.maxLevel;
        currentLevel = gameManager.currentLevel;
    }
}
