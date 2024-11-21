using UnityEngine;
using TMPro;

public class WordButton : MonoBehaviour
{
    //public GameController gameController;
    public WordSelectionManager wordSelectionManager;

    private void Awake()
    {
        //gameController = FindObjectOfType<GameController>();
        wordSelectionManager = FindObjectOfType<WordSelectionManager>();
    }
    public void OnButtonClicked()
    {
        string word = GetComponentInChildren<TextMeshProUGUI>().text;
        //gameController.OnWordSelected(word);
        wordSelectionManager.SelectWord(word);
        Debug.Log(word);
    }
}
