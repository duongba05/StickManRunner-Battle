using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyCount = 10;
    public GameObject enemyPrefab;

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-2f, 2f), 0.5f, Random.Range(-2f, 2f));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CrowdManager crowd = collision.gameObject.GetComponent<CrowdManager>();
            if (crowd != null)
            {
                if (crowd.crowdSize > enemyCount)
                {
                    Debug.Log("You Win!");
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Game Over!");
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}