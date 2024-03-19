using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 빨간색 박스에 도달하면 공 삭제
        if (other.gameObject.CompareTag("RedBox"))
        {
            Debug.Log("충돌 / 공 삭제");
            // Ball을 삭제
            Destroy(gameObject);
        }
    }
}
