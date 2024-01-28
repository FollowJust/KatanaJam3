using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer = 10.0f;

    private GameObject timeOverMessage;
    private bool isDead = false;
    private float timeAfterDeath = 0.0f;
    private GameObject timerCounerText;


    // Start is called before the first frame update
    void Start()
    {
        print("Game Start");
        timeOverMessage = GameObject.FindGameObjectWithTag("TimeOverMessage");
        timerCounerText = GameObject.FindGameObjectWithTag("TimerCounterMessage");
        if (timeOverMessage)
        {
            timeOverMessage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = (int)(timer * 100) / 100f;
        var a = timerCounerText.GetComponent<TextMeshProUGUI>();
        a.text = timer.ToString();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            print("Game Over");
            isDead = true;

            if (!timeOverMessage.activeSelf)
            {
                timeOverMessage.SetActive(true);
                timerCounerText.SetActive(false);
            }

            timeAfterDeath += Time.deltaTime;
            if (timeAfterDeath >= 2.0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
