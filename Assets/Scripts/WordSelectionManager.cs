/*using UnityEngine;
using System.Collections.Generic;

public class WordSelectionManager : MonoBehaviour
{
    [Header("Level Data")]
    public LevelData currentLevelData;        // Reference to the current LevelData
    public SelectedWordsDisplay wordsDisplay; // Reference to SelectedWordsDisplay
    public FeedbackManager feedbackManager;   // Reference to FeedbackManager
    public WordValidator wordValidator;       // Reference to WordValidator

    private List<string> selectedWords = new List<string>();

    private void Start()
    {
        if (wordValidator == null)
        {
            wordValidator = FindObjectOfType<WordValidator>();
        }
        else {
            Debug.LogError("WordValidator is not assigned in WordSelectionManager!");
        }

        ClearSelection();
    }

    public void SelectWord(string word)
    {
        if (selectedWords.Count < 2)
        {
            selectedWords.Add(word);
            Debug.Log("Selected word: " + word);  // Log every word selected
            Debug.Log("Selected words list: " + string.Join(", ", selectedWords)); // Log the current list

            wordsDisplay.UpdateDisplay(selectedWords);

            if (selectedWords.Count == 2)
            {
                Debug.Log("Validating words: " + string.Join(" ", selectedWords) + " with " + string.Join(", ", currentLevelData.correctWords));
                bool isCorrect = wordValidator.Validate(selectedWords, currentLevelData.correctWords);

                if (isCorrect)
                {
                    feedbackManager.DisplayFeedback("Correct!", Color.green);
                    Invoke(nameof(ClearSelection), feedbackManager.feedbackDisplayTime);
                    feedbackManager.FeedbackCount(1);
                }
                else
                {
                    feedbackManager.DisplayFeedback("Wrong! Try Again.", Color.red);
                    Invoke(nameof(ClearSelection), feedbackManager.feedbackDisplayTime);
                }
            }
        }
    }


    public void ClearSelection()
    {
        selectedWords.Clear();
        wordsDisplay.ClearDisplay();
        feedbackManager.HideFeedback();
        Debug.Log("Selection cleared and ready for new selection.");
    }
}*/

using System.Collections.Generic;
using UnityEngine;
using System;

public class WordSelectionManager : MonoBehaviour
{
    public event Action<bool> OnWordsValidated; // Event for notifying validation result
    public SelectedWordsDisplay wordsDisplay;   // View for displaying selected words
    public WordValidator wordValidator;         // Model for validating words
    public LevelData currentLevelData;          // Model for level data

    private List<string> selectedWords = new List<string>();

    private void Start()
    {
        ClearSelection();
    }

    public void SelectWord(string word)
    {
        if (selectedWords.Count < 2)
        {
            selectedWords.Add(word);
            wordsDisplay.UpdateDisplay(selectedWords);

            if (selectedWords.Count == 2)
            {
                ValidateSelectedWords();
            }
        }
    }

    private void ValidateSelectedWords()
    {
        bool isCorrect = wordValidator.Validate(selectedWords, currentLevelData.correctWords);
        OnWordsValidated?.Invoke(isCorrect); // Notify GameManager about validation result
        Invoke(nameof(ClearSelection), 1.5f); // Delay to allow feedback to be displayed
    }

    public void ClearSelection()
    {
        selectedWords.Clear();
        wordsDisplay.ClearDisplay();
    }
}
