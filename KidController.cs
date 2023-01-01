using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidController : MonoBehaviour
{
    // Variables for energy and blocking
    public int energy;
    public int maxEnergy;
    bool blocking;
    public int blockDamageReduction;
    public int health;

    // Other variables
    Animator animator;
    ArnoldController player;
    bool attacking;

    // UI Slider objects
    public Slider healthSlider;
    public Slider energySlider;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Arnold").GetComponent<ArnoldController>();

        // Set energy to 0 at the start
        energy = 0;

        // Set starting health value
        health = 200;
    }

    void Update()
    {
        if (health > 0)
        {
            // Follow the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.2f);

            // Choose a random attack
            int attack = Random.Range(0, 3);
            if (attack == 0)
            {
                // Punch
                animator.SetTrigger("Punch");
                player.TakeDamage(9);
            }
            else if (attack == 1)
            {
                // Kick
                animator.SetTrigger("Kick");
                player.TakeDamage(15);
            }
            else
            {
                // Special attack
                if (energy == maxEnergy)
                {
                    animator.SetTrigger("SpecialAttack");
                    player.TakeDamage(20);
                }
                else
                {
                    // Find the HealthBar and EnergyMeter game objects
HealthBar = GameObject.Find("KidHealthBar");
EnergyMeter = GameObject.Find("KidEnergyMeter");

// Update the health bar to reflect the current health value
HealthBar.transform.localScale = new Vector3(health / maxHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);

// Update the energy meter to reflect the current energy value
EnergyMeter.transform.localScale = new Vector3(energy / maxEnergy, EnergyMeter.transform.localScale.y, EnergyMeter.transform.localScale.z);
                   
void Update()
{
// Update health bar
float healthPercent = (float)health / (float)maxHealth;
healthBar.fillAmount = healthPercent;
// Update energy meter
float energyPercent = (float)energy / (float)maxEnergy;
energyMeter.fillAmount = energyPercent;

}

public void TakeDamage(int damage)
{
// Reduce health
health -= damage;

// Increase energy
energy += 10;
if (energy > maxEnergy)
{
    energy = maxEnergy;
}
}