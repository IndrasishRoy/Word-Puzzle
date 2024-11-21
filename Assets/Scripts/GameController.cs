/*using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour
{
    public LevelManager levelManager;
    public LevelUI levelUI;
    public WordSelectionManager wordSelectionManager;
    public FeedbackManager feedbackManager;
    public GameObject nextLevelPanel;

    private List<string> selectedWords = new List<string>();

    private void Start()
    {
        if (levelManager.currentLevel != null)
            InitializeLevel();
    }

    public void InitializeLevel()
    {
        nextLevelPanel.SetActive(false);
        selectedWords.Clear();
        levelUI.DisplayWords(levelManager.currentLevel.words);
    }

    public void OnWordSelected(string word)
    {
        Debug.Log("Word selected in GameController: " + word);

        selectedWords.Add(word);
        Debug.Log("Calling SelectWord in WordSelectionManager: " + word);
        wordSelectionManager.SelectWord(word);  // This triggers SelectWord
        CheckSolution();
    }

    private void CheckSolution()
    {
        var correctWords = levelManager.currentLevel.correctWords;
        bool isCorrect = correctWords.Count == selectedWords.Count && new HashSet<string>(correctWords).SetEquals(selectedWords);

        if (isCorrect)
            levelManager.currentLevel.onLevelSolved?.Invoke();

        if(feedbackManager.count == (correctWords.Capacity / 2))
        {
            StartCoroutine(OnLevelComplete());
        }
    }

    private IEnumerator OnLevelComplete()
    {
        yield return new WaitForSeconds(1.6f); // Wait for feedback to be hidden
        nextLevelPanel.SetActive(true);
        Debug.Log("Half of the correct words matched! Level complete.");
    }
}
*/

using UnityEngine;

public class GameController : MonoBehaviour
{
    public LevelManager levelManager;
    public LevelUI levelUI;
    public WordSelectionManager wordSelectionManager;
    public FeedbackManager feedbackManager;
    public GameObject nextLevelPanel;

    private void Start()
    {
        InitializeLevel();
        wordSelectionManager.OnWordsValidated += HandleWordValidation; // Subscribe to word validation event
    }

    private void InitializeLevel()
    {
        nextLevelPanel.SetActive(false);
        levelUI.DisplayWords(levelManager.currentLevel.words);
    }

    private void HandleWordValidation(bool isCorrect)
    {
        if (isCorrect)
        {
            feedbackManager.DisplayFeedback("Correct!", Color.green);
            Invoke(nameof(LevelComplete), feedbackManager.feedbackDisplayTime);
        }
        else
        {
            feedbackManager.DisplayFeedback("Wrong! Try Again.", Color.red);
        }
    }

    private void LevelComplete()
    {
        nextLevelPanel.SetActive(true);
        Debug.Log("Level Complete!");
    }

    private void OnDestroy()
    {
        wordSelectionManager.OnWordsValidated -= HandleWordValidation; // Unsubscribe from event
    }
}
