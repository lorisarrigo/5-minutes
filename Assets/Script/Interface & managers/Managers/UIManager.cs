using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;

    [Header("Timer")]
    [SerializeField] TMP_Text timerTXT;
    [SerializeField] float timer;
    float minutes, seconds;

    public static event Action OnTimer;
    private void OnEnable()
    {
        Player.OnHit += Defillbar;
    }
    private void OnDisable()
    {
        Player.OnHit -= Defillbar;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        minutes = Mathf.Floor(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        timerTXT.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        if(timer <= 0)
        {
            timerTXT.gameObject.SetActive(false);
            OnTimer?.Invoke();
        }
    }

    private void Defillbar()
    { 
        if(Player.Instance.currentHealth == 2)
            heart3.SetActive(false);
        else if(Player.Instance.currentHealth == 1)
            heart2.SetActive(false);
        else if(Player.Instance.currentHealth == 0)
            heart1.SetActive(false);
    }
}
