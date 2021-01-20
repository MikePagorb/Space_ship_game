using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public Rigidbody asteroidBody;//���� ������ ���������
    public float speed;
    public float rotationSpeed;


    private float size; //������ � ���������
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.5f, 2.0f); //������ ��������� ����� 50% � 200%


        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroidBody.angularVelocity = Random.insideUnitSphere * rotationSpeed;


        float speedX = 0;
        if (Random.Range(0, 100) < 30)// � 30% ������� ������� �������� �� ��� �
        {
            speedX = speed * Random.Range(-0.5f, 0.5f);
        }
        asteroidBody.velocity = new Vector3(speedX, 0, -speed) / size;
        asteroid.velocity = new Vector3(speedX,0,-speed) / size;


        asteroid.transform.localScale *= size;
    }
    
    // ���������� ��� ������������ ������� � ������ ����������� (other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity); // ���������� ����� ���������

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);// player explosion
        }

        Destroy(gameObject);// ���������� ��������
        Destroy(other.gameObject);// ���������� ������ ������

    }

}
