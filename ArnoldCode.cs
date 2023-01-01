// Other variables
Animator animator;
EnemyController boss;
bool attacking;
public int health;
public Image HealthBar;
public Image EnergyMeter;

void Start()
{
    animator = GetComponent<Animator>();
    boss = GameObject.Find("OldWoman").GetComponent<EnemyController>();

    // Set energy to 0 at the start
    energy = 0;
    EnergyMeter.fillAmount = (float) energy / maxEnergy;

    // Set starting health value
    health = 100;
    HealthBar.fillAmount = (float) health / 100;
}

void Update()
{
    // Check if the player is using a controller or keyboard
    if (Input.GetAxis("Horizontal") != 0 || Input.GetButtonDown("Jump") || Input.GetButtonDown("Punch") || Input.GetButtonDown("Kick") || Input.GetButtonDown("SpecialAttack") || Input.GetButtonDown("Block"))
    {
        // Use controller input
        ...
    }
    else
    {
        // Use keyboard input
        ...
    }
}

void Attack()
{
    attacking = true;

    // Play punch animation
    animator.SetTrigger("Punch");
    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    // Deal damage to the boss
    boss.TakeDamage(5);

    // Increase energy
    energy += 10;
    if (energy > maxEnergy)
    {
        energy = maxEnergy;
    }
    EnergyMeter.fillAmount = (float) energy / maxEnergy;

    attacking = false;
}

IEnumerator Kick()
{
    attacking = true;

    // Play kick animation
    animator.SetTrigger("Kick");
    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    // Deal damage to the boss
    boss.TakeDamage(7);

    // Increase energy
    energy += 10;
    if (energy > max
