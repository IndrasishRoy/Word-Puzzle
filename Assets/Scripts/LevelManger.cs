using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData currentLevel;

    public void LoadLevel(LevelData levelData)
    {
        currentLevel = levelData;
        Debug.Log("Level Loaded: " + currentLevel.name);
        // Load the contents of the current level.
    }
}
