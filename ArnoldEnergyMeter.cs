// Calculate the current energy as a percentage of the maximum energy
float energyPercentage = (float)player.energy / (float)player.maxEnergy;

// Set the value of the EnergyMeter UI element
EnergyMeter.value = energyPercentage;
