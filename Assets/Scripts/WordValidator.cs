using System.Collections.Generic;
using UnityEngine;

public class WordValidator : MonoBehaviour
{
    public bool Validate(List<string> selectedWords, List<string> correctWords)
    {
        if (selectedWords.Count != 2)
            return false;

        string selectedWordPair = string.Join(" ", selectedWords);

        // Check if any individual correct word matches the selected pair
        foreach (var correctWord in correctWords)
        {
            if (selectedWordPair == correctWord)
            {
                return true;
            }
        }

        return false;
    }
}
