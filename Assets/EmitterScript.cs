using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay; // задержка между запусками

    private float nextLaunchTime; // время следующего запуска
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            
            // Выбираем случайную точку по оси Х
            float left = -transform.localScale.x/2;
            float right = transform.localScale.x / 2;

            float posX = Random.Range(left, right);
            float posY = transform.position.y;
            float posZ = transform.position.z;

            // запуск астероида
            Instantiate(asteroid, new Vector3(posX, posY, posZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
