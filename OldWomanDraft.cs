public class EnemyController : MonoBehaviour
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

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Arnold").GetComponent<ArnoldController>();

        // Set energy to 0 at the start
        energy = 0;

        // Set starting health value
        health = 150;
    }

    void Update()
    {
        if (health > 0)
        {
            // Follow the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);

            // Choose a random attack or block
            int attack = Random.Range(0, 4);
            if (attack == 0)
            {
                // Punch
                animator.SetTrigger("Punch");
                player.TakeDamage(7);
            }
            else if (attack == 1)
            {
                // Kick
                animator.SetTrigger("Kick");
                player.TakeDamage(10);
            }
            else if (attack == 2)
            {
                // Special attack
                if (energy == maxEnergy)
                {
                    animator.SetTrigger("SpecialAttack");
                    player.TakeDamage(15);
                }
                else
                {
                    // Block
                    animator.SetTrigger("Block");
                    player.TakeDamage(-blockDamageReduction);
                }
            }
            else
            {
                // Block
                animator.SetTrigger("Block");
                player.TakeDamage(-blockDamageReduction);
            }
        }
        else
        {
            // Play death animation
            animator.SetTrigger("Death");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
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
}
