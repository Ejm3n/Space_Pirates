using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    void Update()//двигаем пулю оттуда откуда она вышла
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

}
