using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public Button playButton;

    public void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame() 
    {
        playButton.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Crowded_city");
    }
}
