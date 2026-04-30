using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerTXT;
    //[SerializeField] GameObject timerHolder;

    [SerializeField] float timer;
    float minutes;
    float seconds;
    public static event Action OnTimer;
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
}
