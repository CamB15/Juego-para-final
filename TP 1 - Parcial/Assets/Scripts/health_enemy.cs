using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_enemy : MonoBehaviour
{
    private Image health_bar;
    private int current;
    private int max = 30;
    private Life player_health;
    private

    void Start()
    {
        health_bar = GetComponent<Image>();
        player_health = GameObject.FindWithTag("enemy").GetComponent<Life>();
    }
    private void Update()
    {
        current = player_health.life;
        health_bar.fillAmount = (float)current / (float)max;
    }
}
