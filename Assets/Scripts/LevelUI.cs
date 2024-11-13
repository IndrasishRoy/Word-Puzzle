using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LevelUI : MonoBehaviour
{
    public Transform wordContainer;  // Parent object for word buttons
    public GameObject wordButtonPrefab;

    private List<Button> wordButtons = new List<Button>();

    public void DisplayWords(List<string> words)
    {
        foreach (Transform child in wordContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (string word in words)
        {
            GameObject wordObj = Instantiate(wordButtonPrefab, wordContainer);
            Button wordButton = wordObj.GetComponent<Button>();
            wordButton.GetComponentInChildren<TextMeshProUGUI>().text = word;
            wordButton.onClick.AddListener(() => wordObj.GetComponent<WordButton>().OnButtonClicked());
        }
    }
}
