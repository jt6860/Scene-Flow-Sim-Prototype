using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    public string selectedColor;
    private bool isColorSelected;
    public Button startButton;
    public Button exitButton;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        selectedColor = color.ToString();
        Debug.Log("In MenuUIHandler.cs: " + selectedColor);
        PlayerPrefs.SetString("Color", selectedColor);
        isColorSelected = true;

    }
    
    private void Start()
    {
        ColorPicker.Init();

        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitGame);
        
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    private void StartGame()
    {
        if (isColorSelected)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main");
        }
    }

    private void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
