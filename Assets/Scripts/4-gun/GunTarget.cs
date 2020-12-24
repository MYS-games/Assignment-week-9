using UnityEngine;

public class GunTarget : MonoBehaviour
{
    [SerializeField] float enemyLife = 50f;
    
    public void takeDamage(float damageTaken)
    {
        enemyLife -= damageTaken;

        if (enemyLife <= 0f)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
