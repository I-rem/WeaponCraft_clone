using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireRateGate : MonoBehaviour
{
    public float maxBonus = 5f;
    public float bonusIncreaseRate = 0.1f;
    public int gateType; // 0: FireRate 1: FireRange
    private string[] gates = { "FireRate", "FireRange" };
    public float currentBonus = 0f;

    public TextMeshPro textMeshPro;

    private void Start()
    {
        if (currentBonus < 0)
            textMeshPro.text = $"<color=red>{gates[gateType]}" + $" <color=red>\n{currentBonus}</color>";
        else
            textMeshPro.text = $"<color=green>{gates[gateType]}" + $"<color=green>\n{currentBonus}</color>";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && currentBonus < maxBonus)
        {
            currentBonus += bonusIncreaseRate;
            if (currentBonus > maxBonus)
                currentBonus = maxBonus;
        }
        else if (other.CompareTag("Player"))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            playerShooting.ApplyBonus(currentBonus, gateType);
        }
            

    }

    void Update()
    {
         if (currentBonus < 0)
            textMeshPro.text = $"<color=red>{gates[gateType]}" + $" <color=red>\n{currentBonus}</color>";
        else
            textMeshPro.text = $"<color=green>{gates[gateType]}" + $"<color=green>\n{currentBonus}</color>";
    }
}
