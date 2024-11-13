using UnityEngine;
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
}

