using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void FlappyMode() {
        PlayerController.gameMode = PlayerController.GameMode.flappy;
        SceneManager.LoadScene("Game");
    }
    public void SwimMode() {
        PlayerController.gameMode = PlayerController.GameMode.swim;
        SceneManager.LoadScene("Game");
    }
}
