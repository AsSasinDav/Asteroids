using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    public GameObject smallAsteroidPrefab;



    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke(nameof(DisableBullet), maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            IncreaseScore();
            SplitAsteroid();
            Destroy(collision.gameObject);
            DisableBullet();
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            DisableBullet();
        }
    }

    private void DisableBullet()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }


    private void SplitAsteroid()
    {
        for (int i = 0; i < 2; i++)
        {
            
            GameObject smallAsteroid = Instantiate(smallAsteroidPrefab, transform.position, Quaternion.identity);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            smallAsteroid.GetComponent<Rigidbody>().velocity = randomDirection * 5f; 

            Destroy(smallAsteroid,maxLifeTime);
        }
    }
}
