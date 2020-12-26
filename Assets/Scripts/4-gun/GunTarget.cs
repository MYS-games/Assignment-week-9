using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (gameObject.tag  == "Player")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        Destroy(gameObject);
    }
}
