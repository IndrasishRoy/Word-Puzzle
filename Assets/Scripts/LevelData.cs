// File: LevelData.cs
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelData", menuName = "WordPuzzle/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    public List<string> words;                   // All words for the level
    public List<string> correctWords;            // Words that solve the level
    //public AnimationClip levelAnimation;         // Reference to the level animation

    // Optional: Actions or events tied to solving the level
    public UnityEngine.Events.UnityEvent onLevelSolved;
}
