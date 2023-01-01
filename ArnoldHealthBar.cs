// Calculate the current health as a percentage of the maximum health
float healthPercentage = (float)player.health / (float)player.maxHealth;

// Set the value of the HealthBar UI element
HealthBar.value = healthPercentage;
