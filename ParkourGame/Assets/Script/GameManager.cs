using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text Scoretext;
    void Start()
    {
        score = 0;
        Scoretext.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        score++;
        Scoretext.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Çýkýþ");
    }
}
