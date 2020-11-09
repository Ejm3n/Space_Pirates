using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject ExplosionPrefab;
    //private const float speed = 7f;
    private float speed;
    private float minrange = 3f;
    private float maxrange = 8f;
    private void Start()
    {
        speed = UnityEngine.Random.Range(minrange, maxrange);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);//просто типа астероид летит
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        var exp = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(col.gameObject);//убивает все во что попадает
        Destroy(gameObject);
        Destroy(exp,1f);
    }

}
