public class ArnoldController : MonoBehaviour
{
    // Variables for energy and blocking
    public int energy;
    public int maxEnergy;
    bool blocking;
    public int blockDamageReduction;

    // Other variables
    Animator animator;
    EnemyController boss;
    bool attacking;

    void Start()
    {
        animator = GetComponent<Animator>();
        boss = GameObject.Find("OldWoman").GetComponent<EnemyController>();

        // Set energy to 0 at the start
        energy = 0;
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
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }

        attacking = false;
    }

    IEnumerator SpecialAttack()
    {
        if (energy == maxEnergy)
        {
            attacking = true;

            // Play special attack animation
            animator.SetTrigger("SpecialAttack");

            // Wait for the special attack animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            // Deal damage to the boss
            boss.TakeDamage(20);

            // Reset energy
            energy = 0;

            attacking = false;
        }
        else
        {
            // Play block animation
            animator.SetTrigger("Block");

            // Wait for the block animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            // Reduce damage taken from the boss
            boss.TakeDamage(-blockDamageReduction);
        }
    }
}
