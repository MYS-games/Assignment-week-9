using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunTarget : MonoBehaviour
{
    [SerializeField] float enemyLife = 50f;
    private TextMeshProUGUI health;
    private float total_Enemy_Life;

    private void Start()
    {
        total_Enemy_Life = enemyLife;
        if (transform.tag == "Player")
        {
            GameObject obj = GameObject.Find("PlayerHealth");
            health = obj.GetComponent<TextMeshProUGUI>();
        } else if (transform.tag == "Enemy")
        {
            GameObject obj = GameObject.Find("EnemyHealth");
            health = obj.GetComponent<TextMeshProUGUI>();
        } else
        {
            GameObject obj = GameObject.Find("EngineHealth");
            health = obj.GetComponent<TextMeshProUGUI>();
            Debug.Log(transform.name + " --- " + health.text);
        }
    }
    public void takeDamage(float damageTaken)
    {
        enemyLife -= damageTaken;
        float life = float.Parse(health.text);
        life = (enemyLife / total_Enemy_Life) * 100;
        health.text = life.ToString();

        if (enemyLife <= 0f)
        {
            die();
        }
    }

    void die()
    {
        if (gameObject.tag  == "Player" || gameObject.tag == "Engine")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        Destroy(gameObject);
    }
}
