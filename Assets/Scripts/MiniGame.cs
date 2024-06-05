using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Added for TextMeshPro

public class MiniGame : MonoBehaviour
{
    public List<Button> buttons;
    private List<Button> shuffledButtons;
    private int counter = 0;

    void Start()
    {
        RestartTheGame();
    }

    public void RestartTheGame()
    {
        counter = 0;

        if (buttons == null || buttons.Count == 0)
        {
            Debug.LogError("Buttons list is not assigned or empty.");
            return;
        }

        shuffledButtons = buttons.OrderBy(button => Random.Range(0, 100)).ToList();
        Debug.Log("Shuffled buttons list created with " + shuffledButtons.Count + " elements.");

        for (int i = 0; i < shuffledButtons.Count; i++) // Ensure the loop runs within the bounds of the list
        {
            var button = shuffledButtons[i];
            var textComponent = button.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent == null)
            {
                Debug.LogError($"Button {button.name} does not have a TextMeshProUGUI component.");
                continue;
            }

            textComponent.text = (i + 1).ToString(); // Assign number from 1 to the number of buttons
            button.interactable = true;
            button.image.color = Color.white;
        }
    }

    public void PressButton(Button button)
    {
        if (button == null)
        {
            Debug.LogError("Pressed button is null.");
            return;
        }

        var textComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError($"Button {button.name} does not have a TextMeshProUGUI component.");
            return;
        }

        if (int.Parse(textComponent.text) - 1 == counter) // Adjusted comparison to match 1-based numbering
        {
            counter++;
            button.interactable = false;
            button.image.color = Color.green;
            if (counter == 10)
            {
                print("You win");
                StartCoroutine(PresentResult(true));
                SceneManager.LoadScene("Levels/Level3", LoadSceneMode.Single);
            }
        }
        else
        {
            StartCoroutine(PresentResult(false));
        }
    }
   

    public IEnumerator PresentResult(bool win)
    {
        if (!win)
        {
            foreach (var button in shuffledButtons)
            {
                button.image.color = Color.red;
                button.interactable = false;
            }
        }
        yield return new WaitForSeconds(2f);
        RestartTheGame();
    }
}
