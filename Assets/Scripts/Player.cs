using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public static float limitX = 9.1f;
    public static float limitY = 5.2f;

    public GameObject gun, bulletPrefab, menuPause, Reiniciar;
    public ObjectPool bulletPool;

    private Rigidbody _rigid;

    public static int SCORE = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);


        Vector2 tp = transform.position;

        if(tp.x > limitX)
        {
            tp.x = -limitX;
        } else if (tp.x < -limitX)
        {
            tp.x = limitX;
        } else if (tp.y > limitY)
        {
            tp.y = -limitY;
        } else if (tp.y < -limitY)
        {
            tp.y = limitY;
        }

        transform.position = tp;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = bulletPool.GetBullet();
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;

        }

        if (Time.timeScale == 0f && Input.GetKeyDown(KeyCode.Escape))
        {
            Reanudar();
        }

        else if(Time.timeScale == 1f && Input.GetKeyDown(KeyCode.Escape))
        {
           Pausar();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2")) 
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
    }

    private void Pausar()
    {
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }

    private void Reanudar()
    {
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }




}
