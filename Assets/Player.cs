using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //[SerializeField] GameObject ExplosionPrefab;
    [SerializeField] GameObject loseCan;
    [SerializeField] GameObject AmmoCan;
    private GameObject currentScreen;
    private int BulletCount = 1;
    private const float TimeTillBullet = 5f;
    private float BulletTimer = 5f;
    private float DeathTimer = 2f;
    public Text BulletCountText;
    public GameObject bullet;
    public Transform shotPoint;
    public int TotalTimerTickCount=0;
    public float speed;
    private bool Pressed = false;
    private bool paused = false;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        loseCan.SetActive(false);//работа с канвасами
        AmmoCan.SetActive(true);
        currentScreen = AmmoCan;
    }
    void Update()
    {
        BulletTimer -= Time.deltaTime; //таймер для подсчета текущих пуль
        if(BulletTimer <= 0)// если таймер тикает то добавляем пулю и ренюваем таймер
        {
            BulletCount++;
            BulletCountText.text = BulletCount.ToString();
            RenewTimer();
        }
        PlayerLooking();
        if (Input.GetKeyDown(KeyCode.Mouse0))//просто ходьба
        {
            Pressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Pressed = false;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)&& BulletCount>0)
        {
            Instantiate(bullet, shotPoint.position,transform.rotation );//спавн пули
            BulletCount -= 1;
            BulletCountText.text = BulletCount.ToString();//передача в UI
        }
        
    }
    private void PlayerLooking()//поворот и движение игрока
    {
        Vector3 MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        Vector2 direction = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        transform.up = direction;
        if(Pressed)
        {
            transform.position = Vector2.MoveTowards(transform.position, MousePosition, Time.deltaTime * speed);
        }
            
    }
    private void RenewTimer()
    {
        BulletTimer = TimeTillBullet;
        TotalTimerTickCount++;
    }
    private void OnDestroy()//когда умирает герой мы ставим игру на паузу и запускаем второй канвас
    {
        //var exp = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        //Destroy(exp, 1f);
        PauseGame();
    }
    public void ChangeState(GameObject state)//просто сменщик канвасов
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = !paused;
        ChangeState(loseCan);
    }
}


