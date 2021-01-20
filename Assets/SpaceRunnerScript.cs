using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRunnerScript : MonoBehaviour
{
    public GameObject laserShot;//�������
    public Transform laserGun;//�����

    public float shotDelay; //�������� ����� ����������

    private float nextShotTime = 0; //����� ����. ��������

    public float speed; //����. ��������
    public float tilt; //����. ��������
    public float xMin, xMax, zMin, zMax;
    private Rigidbody StarShip;



    // Start is called before the first frame update
    void Start()
    {
        StarShip = GetComponent<Rigidbody>();
        //StarShip.velocity = new Vector3(15,0,25);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");// ���� ������ �� �����������
        float moveVertical = Input.GetAxis("Vertical");// ���� ������ �� ���������
        
        StarShip.velocity = new Vector3(moveHorizontal,0,moveVertical)*speed;

        float clampedX = Mathf.Clamp(StarShip.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(StarShip.position.z, zMin, zMax);

        StarShip.position = new Vector3(clampedX,0,clampedZ);

        StarShip.rotation = Quaternion.Euler(StarShip.velocity.z * tilt, 0 , -StarShip.velocity.x * tilt);

        //make a shot
        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            // ������ ����� ��������
            Instantiate(laserShot, laserGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }
}
