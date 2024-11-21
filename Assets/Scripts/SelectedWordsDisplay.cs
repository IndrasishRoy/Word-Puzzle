using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SelectedWordsDisplay : MonoBehaviour
{
    public TextMeshProUGUI selectedWordsText; // Text to display the selected words

    public void UpdateDisplay(List<string> selectedWords)
    {
        string mergedWords = string.Join(" ", selectedWords);
        Debug.Log("Updating display with: " + mergedWords); // Log the merged words
        selectedWordsText.text = mergedWords;
    }


    public void ClearDisplay()
    {
        selectedWordsText.text = string.Empty;
        Debug.Log("Display cleared");
    }
}
