using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HEALTHBAR : MonoBehaviour
{
    [SerializeField] private HEALTH playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    

    private void Start()
    {
        totalHealthBar.fillAmount= playerHealth.currentHealth/5;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 5;
    }
}
