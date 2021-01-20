using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public Rigidbody asteroidBody;//Сама модель астероида
    public float speed;
    public float rotationSpeed;


    private float size; //размер в процентах
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.5f, 2.0f); //размер астероида между 50% и 200%


        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroidBody.angularVelocity = Random.insideUnitSphere * rotationSpeed;


        float speedX = 0;
        if (Random.Range(0, 100) < 30)// в 30% случаев добавим скорость по оси Х
        {
            speedX = speed * Random.Range(-0.5f, 0.5f);
        }
        asteroidBody.velocity = new Vector3(speedX, 0, -speed) / size;
        asteroid.velocity = new Vector3(speedX,0,-speed) / size;


        asteroid.transform.localScale *= size;
    }
    
    // Вызывается при столкновении объекта с другим коллайдером (other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity); // показываем взрыв астероида

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);// player explosion
        }

        Destroy(gameObject);// уничтожаем астероид
        Destroy(other.gameObject);// уничтожаем другой объект

    }

}
