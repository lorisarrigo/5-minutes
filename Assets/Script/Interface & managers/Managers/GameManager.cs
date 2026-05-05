using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum States
{
    Running,
    Pause
}
public class GameManager : MonoBehaviour
{
    States states;
    InputMap inputs;
    [SerializeField] GameObject PauseScreen, WinScreen, GOScreen;
    [SerializeField] AudioClip winSfx, gameOverSfx;
    bool isWinning;
    private void Awake()
    {
        inputs = new InputMap();
        states = States.Running;
    }
    private void OnEnable()
    {
        inputs.Enable();

        UIManager.OnTimer += Win;
        Player.OnGO += GameOver;

        if (states == States.Running)
            Running();
        else if (states == States.Pause)
            Pause();
    }
    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Pause.started -= ChangeState;

        UIManager.OnTimer -= Win;
        Player.OnGO -= GameOver;
    }
    private void ChangeState(InputAction.CallbackContext context)
    {
        if (states == States.Running)
            Pause();
        else if (states == States.Pause)
            Running();
    }
    private void Running()
    {
        states = States.Running;
        Time.timeScale = 1;
        inputs.Player.Pause.started += ChangeState;
        PauseScreen.SetActive(false);
    }
    private void Pause()
    {
        states = States.Pause;
        Time.timeScale = 0;
        inputs.Player.Pause.started += ChangeState;
        PauseScreen.SetActive(true);
    }
    private void Win()
    {
        if (!isWinning)
        {
            SFXManager.instance.PlaySfx(winSfx);
            isWinning = true;
        }
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        GOScreen.SetActive(true);
        SFXManager.instance.PlaySfx(gameOverSfx);
    }
}
