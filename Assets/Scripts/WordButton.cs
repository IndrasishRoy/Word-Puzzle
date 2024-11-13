using UnityEngine;
using TMPro;

public class WordButton : MonoBehaviour
{
    public GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void OnButtonClicked()
    {
        string word = GetComponentInChildren<TextMeshProUGUI>().text;
        gameController.OnWordSelected(word);
        Debug.Log(word);
    }
}
