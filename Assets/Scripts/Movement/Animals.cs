using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animals : MonoBehaviour
{
    /////������������//////
    public bool runningToTheRight { get; set; }  //0 -�� ����� ������, 1 - ����� ������
    public bool runningToTheLeft { get; set; }  //0 -�� ����� �����, 1 - ����� �����
    public bool runningUp { get; set; }  //0 -�� ����� �����, 1 - ����� �����
    public bool runningDown { get; set; }  //0 -�� ����� ����, 1 - ����� ����

    public int runningRightOrLeft { get; set; }
    public int runningUpOrDown { get; set; }
    /////��������������//////
    public int food { get; set; }
    public int maxfood { get; set; }
    public int hp { get; set; }
    public int hungerCheck { get; set; }
    public int genderBoy { get; set; }
    public static float speed { get; set; }
    public string thisIsClass { get; set; }
    public string defaultTag { get; set; }
    public bool helmOfDominator { get; set; }
    public bool defWinter { get; set; }
    /////��������///////
    public float timer { get; set; }
    public bool timerActive { get; set; }
    public bool runCoroutine { get; set; }
    public bool runCoroutineRunForFood { get; set; }
    /////��� �����������///////
    public bool readyLove { get; set; }
    public int timeSecToFirstLove { get; set; }
    public bool readyCoroutineLove { get; set; }
    /////��������
    public bool readyCoroutineGrow { get; set; }
    ///////info
    public string infoClass { get; set; }
    public int infoFood { get; set; }
    public int infoHp { get; set; }

    //

    public abstract IEnumerator RunRightOrLeft();

    public void GoDie()
    {
        Destroy(this.gameObject);
    }

    public void Eat()
    {
        if (food >= maxfood / 100 * 80)
        {
            food = maxfood;
        }
        if (food < maxfood / 100 * 80)
        {
            food = food + maxfood / 100 * 20;

            if (hp < maxfood / 100 * 95)
            {
                hp = hp + food - maxfood / 100 * 95;
            }
            if (hp == maxfood / 100 * 95)
            {
                hp = maxfood;
            }
            if (hp > maxfood / 100 * 95)
            {
                hp = maxfood;
            }
        }
    }

    public IEnumerator FallInLoveColdown()
    {
        readyCoroutineLove = true;
        yield return new WaitForSeconds(40f);
        readyLove = true;
        readyCoroutineLove = false;
    }
    public IEnumerator GrowOld()
    {
        readyCoroutineGrow = true;
        yield return new WaitForSeconds(170f);
        Destroy(this.gameObject);
    }
   
    
  
    public void SetTagByGender()
    {
        //���� ���� ��� �� ����
        if (genderBoy == 0)
        {
            if (readyLove == true)
            {
                this.gameObject.tag = defaultTag + "Male";
            }
        }
        if (genderBoy == 1)
        {
            if (readyLove == true)
            {
                this.gameObject.tag = defaultTag + "Female";
            }
        }

        if (readyLove == false)
        {
            this.gameObject.tag = defaultTag;
        }
    }
    public void SetMotionVectors()
    {
        if (hungerCheck == 0)
        {
            if (runningRightOrLeft == 1)
            {
                runningToTheRight = false;
                runningToTheLeft = false;
                runningUp = false;
                runningDown = false;

            }
            if (runningRightOrLeft == 2)
            {
                runningToTheRight = true;
                runningToTheLeft = false;

                if (runningUpOrDown == 1)
                {
                    runningUp = false;
                    runningDown = false;
                }
                if (runningUpOrDown == 2)
                {
                    runningUp = true;
                    runningDown = false;
                }
                if (runningUpOrDown == 3)
                {
                    runningDown = true;
                    runningUp = false;
                }
            }
            if (runningRightOrLeft == 3)
            {
                runningToTheLeft = true;
                runningToTheRight = false;

                if (runningUpOrDown == 1)
                {
                    runningUp = false;
                    runningDown = false;
                }
                if (runningUpOrDown == 2)
                {
                    runningUp = true;
                    runningDown = false;
                }
                if (runningUpOrDown == 3)
                {
                    runningDown = true;
                    runningUp = false;
                }
            }
        }
    }
    /// <summary>
    //public abstract void Run();
    //public abstract void Eat();
    //public void Live()
    //{
    //    if (food < 50)
    //    {
    //        Run();
    //    }
    //    else
    //    {
    //        Eat();
    //    }
    //}
    /// </summary>

    //kc
    //ku

}
