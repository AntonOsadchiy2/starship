using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacesh : MonoBehaviour
{

    public static spacesh InstanceNew { get; set; }

    [SerializeField] private static float speed = 1f;

    public int food = 100;
    public int hungerCheck = 0;
    public int hungerMoreCheck = 0;
    public int hp = 100;

    private SpriteRenderer sprite;

    private int runningToTheRight = 0;
    private int runningToTheLeft = 0;
    private int runningUp = 0;
    private int runningDown = 0;
    private float coordinateX;
    private float coordinateXTwo;
    private int launchingTheCoroutine = 1;

    public GameObject skullLama;
    public GameObject lama;
    //public GameObject cloud;





    private void Awake()
    {
        InstanceNew = this;
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void Start()
    {


    }
    private void Update()
    {
        Vector3 dir = transform.right * 1;
        Vector3 dirTwo = transform.right * -1;
        Vector3 moveInput = transform.up * 1;
        Vector3 moveInputTwo = transform.up * -1;

        if (runningToTheRight == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = true;
        }
        if (runningToTheLeft == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dirTwo, speed * Time.deltaTime);
            sprite.flipX = false;
        }

        if (runningUp == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveInput, speed * Time.deltaTime);

        }
        if (runningDown == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveInputTwo, speed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        //GetHp();
        // GetEat();

        if (launchingTheCoroutine == 1)
        {
            StartCoroutine(Run());
        }

        if (food != 0)
        {
            // cloud.SetActive(false);
        }

        if (food <= 30)
        {
            StartCoroutine(RunRightOrLeft());
            //cloud.SetActive(true);

            if (coordinateX > coordinateXTwo) //движеится ли вправо
            {
                sprite.flipX = true;
            }
            if (coordinateX < coordinateXTwo) //движеится ли вправо
            {
                sprite.flipX = false;
            }

            launchingTheCoroutine = 0;
            runningToTheRight = 0;
            runningToTheLeft = 0;
            runningUp = 0;
            runningDown = 0;
            // this.GetComponent<Pathfinding.AIPath>().enabled = true; //
            StopCoroutine(Run());//new

            if (hungerMoreCheck == 0)
            {
                StartCoroutine(StarveFood());
            }

        }
        //new
        if (food <= 0)
        {
            if (hungerCheck == 0)
            {
                StartCoroutine(Starve());
            }
        }

        if (hp <= 0)
        {
            DieLama();
            Destroy(this.gameObject);
        }
    }

    public void EatGrass()
    {

        if (food >= 80)
        {
            food = 100;
        }
        if (food < 80)
        {
            food = food + 20;
        }

    }



    public void DieLama()
    {
        skullLama.SetActive(true);
        Instantiate(skullLama, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private IEnumerator Run(int stateRightOrLeft = 0, int stateUpOrDown = 0, float randomSecRunXRight = 0f, float randomSecRunXLeft = 0f, float randomSecRunUp = 0f, float randomSecRunDown = 0f, int randomHungry = 0)
    {
        if (food <= 0)
        {
            stateRightOrLeft = 0;
            stateUpOrDown = 0;
            randomSecRunXRight = 0;
            randomSecRunXLeft = 0;
            randomSecRunUp = 0;
            randomSecRunDown = 0;
            randomHungry = 0;
        }
        stateRightOrLeft = UnityEngine.Random.Range(1, 3); //выбирается случайно куда бежать вправо или влево
        stateUpOrDown = UnityEngine.Random.Range(1, 4); //выбирается случайно бежать вверх/вниз/не менять координаты Y

        if (stateRightOrLeft == 1)     //если бежать вправо
        {
            launchingTheCoroutine = 0;

            randomSecRunXRight = UnityEngine.Random.Range(1f, 25f); //выбирается случайное кол-во секунд бега вправо
            runningToTheRight = 1;  //в методе Update() начинает бежать вправо

            if (stateUpOrDown == 1)
            {
                randomSecRunUp = UnityEngine.Random.Range(1f, 25f);
                runningUp = 1;
            }
            if (stateUpOrDown == 2)
            {
                randomSecRunDown = UnityEngine.Random.Range(1f, 25f);
                runningDown = 1;
            }
            if (stateUpOrDown == 3)
            {
                runningUp = 0;
                runningDown = 0;
            }



            yield return new WaitForSeconds(randomSecRunXRight);
            runningToTheRight = 0;
            runningToTheLeft = 0;
            stateRightOrLeft = 0;

            stateUpOrDown = 0;
            runningUp = 0;
            runningDown = 0;

            randomHungry = UnityEngine.Random.Range(1, 10);
            if (food - randomHungry >= 0)
            {
                food = food - randomHungry;
            }
            else
            {
                food = 0;
            }
            launchingTheCoroutine = 1;






            //yield return new WaitForSeconds(1f);

        }
        if (stateRightOrLeft == 2)
        {
            launchingTheCoroutine = 0;


            randomSecRunXLeft = UnityEngine.Random.Range(1f, 25f);
            runningToTheLeft = 1;


            if (stateUpOrDown == 1)
            {
                randomSecRunUp = UnityEngine.Random.Range(1f, 25f);
                runningUp = 1;
            }
            if (stateUpOrDown == 2)
            {
                randomSecRunDown = UnityEngine.Random.Range(1f, 25f);
                runningDown = 1;
            }
            if (stateUpOrDown == 3)
            {
                runningUp = 0;
                runningDown = 0;
            }


            yield return new WaitForSeconds(randomSecRunXLeft);
            runningToTheRight = 0;
            runningToTheLeft = 0;
            stateRightOrLeft = 0;


            stateUpOrDown = 0;
            runningUp = 0;
            runningDown = 0;


            randomHungry = UnityEngine.Random.Range(1, 10);
            if (food - randomHungry >= 0)
            {
                food = food - randomHungry;
            }
            else
            {
                food = 0;
            }

            launchingTheCoroutine = 1;





            //yield return new WaitForSeconds(1f);
        }





    }
    private IEnumerator Starve()
    {
        if (food <= 0)
        {
            hungerCheck = 1;
            yield return new WaitForSeconds(2f);
            if (food <= 0)
            {
                hp = hp - 1;
            }
            yield return new WaitForSeconds(0.00000000000001f);
            hungerCheck = 0;
        }


    }

    private IEnumerator StarveFood()
    {
        if (food <= 30)
        {
            hungerMoreCheck = 1;
            yield return new WaitForSeconds(2f);

            if (food <= 30)
            {
                if (food - 2 <= 0)
                {
                    food = 0;
                }
                else
                {
                    food = food - 2;
                }
            }
            yield return new WaitForSeconds(0.00000000000001f);
            hungerMoreCheck = 0;
        }


    }

    private IEnumerator RunRightOrLeft()
    {
        coordinateX = this.gameObject.transform.position.x;
        yield return new WaitForSeconds(0.5f);
        coordinateXTwo = this.gameObject.transform.position.x;

    }
}
