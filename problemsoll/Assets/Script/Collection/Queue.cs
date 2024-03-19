using System.Collections.Generic;
using UnityEngine;
public class Queue : MonoBehaviour
{
    private class Bullet
    {
        public GameObject gameObject;
        public bool isActive;
    }

    private Queue<Bullet> ballQueue = new Queue<Bullet>();
    public GameObject balls;
    public GameObject greenBox;
    public GameObject ballPrefab;

    void Start()
    {
        // 초기화 시 총알을 10개 생성하여 Queue에 넣음
        for (int i = 0; i < 10; i++)
        {
            GameObject bulletObject = Instantiate(balls);
            bulletObject.SetActive(false);
            Bullet bullet = new Bullet
            {
                gameObject = bulletObject,
                isActive = false
            };
            ballQueue.Enqueue(bullet);
        }
    }

    void Update()
    {
        // 좌클릭하여 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Queue에서 총알을 꺼내서 발사
        if (ballQueue.Count > 0)
        {
            Bullet bullet = ballQueue.Dequeue();
            bullet.isActive = true;
            bullet.gameObject.SetActive(true);
            bullet.gameObject.transform.position = greenBox.transform.position; // 초록색 박스의 위치로 설정
            Rigidbody rb = bullet.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.right * 10f; // 오른쪽으로 총알 발사
        }
    }
}