using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI feedbackText;              // Reference to Text component for feedback
    public float feedbackDisplayTime = 1.5f;          // Duration to show feedback for incorrect answers
    public int count = 0;

    public void DisplayFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
        feedbackText.gameObject.SetActive(true);
    }

    public void FeedbackCount(int c)
    {
        count = c;
        Debug.Log("Count: " + count);
    }

    public void HideFeedback()
    {
        feedbackText.gameObject.SetActive(false);
    }
}
