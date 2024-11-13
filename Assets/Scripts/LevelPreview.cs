using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class LevelPreview : MonoBehaviour
{
    public LevelData levelData;                       // Reference to level data for correct words
    public FeedbackManager feedbackManager;           // FeedbackManager for showing feedback
    public WordSelectionManager wordSelectionManager; // WordSelectionManager for handling word selection

    private List<string> selectedWords = new List<string>(); // Tracks words selected during preview
    public bool isPreviewing = false;                 // Tracks whether preview mode is active

    private void OnEnable()
    {
        ClearPreview();
    }

    public void StartPreview()
    {
        isPreviewing = true;
        Debug.Log("Preview started");
        ClearPreview();
    }

    public void StopPreview()
    {
        isPreviewing = false;
        Debug.Log("Preview stopped");
        feedbackManager.count = 0;
        ClearPreview();
    }

    public void SelectWord(string word)
    {
        if (!isPreviewing) return; // Ensure this only works in preview mode

        if (selectedWords.Count < 2)
        {
            selectedWords.Add(word);
            Debug.Log("Selected word in preview: " + word);

            // Simulate display update in WordSelectionManager
            wordSelectionManager.SelectWord(word);

            // Check if two words have been selected to validate
            if (selectedWords.Count == 2)
            {
                ValidateWords();
            }
        }
    }

    private void ValidateWords()
    {
        bool isCorrect = wordSelectionManager.wordValidator.Validate(selectedWords, levelData.correctWords);

        if (isCorrect)
        {
            DisplayFeedbackWithClear("Correct!", Color.green);
            Debug.Log("Preview validation: Correct!");
        }
        else
        {
            DisplayFeedbackWithClear("Wrong! Try Again.", Color.red);
            Debug.Log("Preview validation: Incorrect!");
        }
    }

    private void DisplayFeedbackWithClear(string message, Color color)
    {
        feedbackManager.DisplayFeedback(message, color);
        Invoke(nameof(ClearFeedback), feedbackManager.feedbackDisplayTime);
    }

    private void ClearFeedback()
    {
        feedbackManager.HideFeedback();
    }

    public void ClearPreview()
    {
        selectedWords.Clear();
        wordSelectionManager.ClearSelection();
        CancelInvoke(nameof(ClearFeedback)); // Cancel any pending feedback clears
        feedbackManager.HideFeedback(); // Immediately hide feedback
        Debug.Log("Cleared preview selections.");
        Console.Clear();
    }
}
