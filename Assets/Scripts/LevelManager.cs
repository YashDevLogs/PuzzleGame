using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelConfig_SO> levels;
    [SerializeField] private Image levelImageUI;
    [SerializeField] private TextMeshProUGUI instructionTextUI;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private GameObject wordbuttonPrefab;
    [SerializeField] private Image resultImageUI;
    [SerializeField] private GameObject congratulationsPanel;

    private int currentLevelIndex = 0;

    private void Start()
    {
        SetUpLevel();
    }

    private void SetUpLevel()
    {
        LevelConfig_SO currentLevel = levels[currentLevelIndex];

        //Display the image and description text
        levelImageUI.sprite = currentLevel.LevelImage;
        instructionTextUI.text = currentLevel.InstructionsText;

        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }

        foreach (string word in currentLevel.Words)
        {
            GameObject buttonObj = Instantiate(wordbuttonPrefab, buttonParent);
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = word;

            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => OnWordSelected(word));
        }


        congratulationsPanel.SetActive(false);
    }

    private void OnWordSelected(string selectedWord)
    {

        LevelConfig_SO currentLevel = levels[currentLevelIndex];

        // Check if the selected word is correct
        if (selectedWord == currentLevel.CorrectWord)
        {
            Debug.Log("Correct word selected");
            // Show the success image
            resultImageUI.sprite = currentLevel.SuccessSprite;
            // Load the next level after a delay
            congratulationsPanel.SetActive(true);
            Invoke(nameof(LoadNextLevel), 3f);
        }
        else
        {
            Debug.Log("Wrong word selected");
            // Show the failure image
            resultImageUI.sprite = currentLevel.FailureSprite;
            resultImageUI.gameObject.SetActive(true);
        }
    }

    private void LoadNextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex < levels.Count)
        {
            SetUpLevel();
        }
        else
        {
            Debug.Log("All levels completed!");
            // Optionally, you can show an end game panel or restart the game.
        }
    }
}
