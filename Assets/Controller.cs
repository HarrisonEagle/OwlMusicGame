using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject fall;
    public Text score;
    public Text combo;
    public Text status;
    Color32 getcolor;
    int[] objects = {1,2,1,2,1,4,1,3,3,4,3,2,1,3,4,1,2,1,1,2,1,1,4,1,4,1,2,3,3,2,1,3,2,1,3,2,4,2,1,3,1,2,2,2,1,1, 3, 2, 1, 3, 4, 1, 2, 1, 1, 2, 1, 1, 4, 1, 4, 1, 2, 3, 3, 2, 1, 3, 2, 1, 3, 2, 4, 4, 1, 2, 1, 1, 2, 1, 1, 4, 1, 4, 1, 2, 3, 3, 2, 1, 3, 1, 2, 1, 1, 2, 1, 1, 4, 1, 4, 1, 2, 3 };
    private List<GameObject> objs = new List<GameObject>();
    // Start is called before the first frame update

    int index = 0;
    int aindex = 0;
    int acombo = 0;
    int ascore = 0;
    

    void Start()
    {
        Thread.Sleep(11000);
        getcolor = up.GetComponent<SpriteRenderer>().color;

        GameObject obj1 = Instantiate(fall);
        for (int i=0;i<objects.Length;i++)
        {
           
                GameObject obj = Instantiate(fall);
                Vector2 vec = obj.transform.position;
                if (objects[i] ==1)
                {
                    vec.x = -5.0f;
                }else if (objects[i] == 2)
                {
                    vec.x = 0.0f;
                }else if (objects[i] == 3)
                {
                    vec.x = 5.0f;
                }else if (objects[i] == 4)
                {
                    vec.x = 10.0f;
            }
            else
            {
                vec.x = -10.0f;
            }
                obj.transform.position = vec;
                objs.Add(obj);
                //StartCoroutine(FuncCoroutine(obj));

           

        }

        StartCoroutine(Createobj());

       

        index = 0;
        
    }


    void reccolor()
    {
        if (up.GetComponent<SpriteRenderer>().color != getcolor)
        {
            up.GetComponent<SpriteRenderer>().color = getcolor;
        }else if (down.GetComponent<SpriteRenderer>().color != getcolor)
        {
            down.GetComponent<SpriteRenderer>().color = getcolor;
        }else if (left.GetComponent<SpriteRenderer>().color != getcolor)
        {
            left.GetComponent<SpriteRenderer>().color = getcolor;
        }else if (right.GetComponent<SpriteRenderer>().color != getcolor)
        {
            right.GetComponent<SpriteRenderer>().color = getcolor;
        }
    }

    IEnumerator FuncCoroutine(GameObject fallobject)
    {
        Vector2 vec = fallobject.transform.position;
        vec.y = 40.0f;
        fallobject.transform.position = vec;
        while (true)
        {
            vec = fallobject.transform.position;
            vec.y -= 0.1f;
            fallobject.transform.position = vec;
            yield return new WaitForSeconds(0.01f);
        }
        // 何か処理
    }

    IEnumerator Createobj()
    { 
        while (index!=objs.Count)
        {
            if (objs[index].transform.position.x!=-10.0f)
            {
                StartCoroutine(FuncCoroutine(objs[index]));
            }
            index++;
            yield return new WaitForSeconds(0.5f);
        }
        // 何か処理
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))

        {
            
            up.GetComponent<SpriteRenderer>().color = Color.cyan;
            Invoke("reccolor", 0.2f);

            if (objs[aindex].transform.position.x == -5.0f&& objs[aindex].transform.position.y<=2.0f)
            {
                
                if (objs[aindex].transform.position.y >= -2.0f&& objs[aindex].transform.position.y <= -1.0f || objs[aindex].transform.position.y >= 1.0f && objs[aindex].transform.position.y <= 1.5f)
                {
                    ascore += 10;
                    status.text = "OK";
                    
                }
                else if (objs[aindex].transform.position.y > -1.0f && objs[aindex].transform.position.y <= -0.5f || objs[aindex].transform.position.y >= 0.5f && objs[aindex].transform.position.y < 1.0f)
                {
                    ascore += 20;
               
                    status.text = "Good";
                }
                else if (objs[aindex].transform.position.y > -0.5f && objs[aindex].transform.position.y <= 0.5f )
                {
                    ascore += 30;

                    
                    status.text = "Excellent!";
                }
                score.text = "Score:" + ascore;
                Destroy(objs[aindex]);
                acombo++;
                combo.text = "Combo:" + acombo;
                aindex++;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))

        {

            down.GetComponent<SpriteRenderer>().color = Color.cyan;
            Invoke("reccolor", 0.2f);

            if (objs[aindex].transform.position.x == 0.0f&& objs[aindex].transform.position.y<=2.0f)
            {
                if (objs[aindex].transform.position.y >= -2.0f && objs[aindex].transform.position.y <= -1.0f || objs[aindex].transform.position.y >= 1.0f && objs[aindex].transform.position.y <= 1.5f)
                {
                    ascore += 10;
                    status.text = "OK";

                }
                else if (objs[aindex].transform.position.y > -1.0f && objs[aindex].transform.position.y <= -0.5f || objs[aindex].transform.position.y >= 0.5f && objs[aindex].transform.position.y < 1.0f)
                {
                    ascore += 20;

                    status.text = "Good";
                }
                else if (objs[aindex].transform.position.y > -0.5f && objs[aindex].transform.position.y <= 0.5f)
                {
                    ascore += 30;


                    status.text = "Excellent!";
                }
                score.text = "Score:" + ascore;
                Destroy(objs[aindex]);
               
                acombo++;
                combo.text = "Combo:" + acombo;
                aindex++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))

        {

            left.GetComponent<SpriteRenderer>().color = Color.cyan;
            Invoke("reccolor", 0.2f);
            if (objs[aindex].transform.position.x == 5.0f&& objs[aindex].transform.position.y<=2.0f)
            {
                if (objs[aindex].transform.position.y >= -2.0f && objs[aindex].transform.position.y <= -1.0f || objs[aindex].transform.position.y >= 1.0f && objs[aindex].transform.position.y <= 1.5f)
                {
                    ascore += 10;
                    status.text = "OK";

                }
                else if (objs[aindex].transform.position.y > -1.0f && objs[aindex].transform.position.y <= -0.5f || objs[aindex].transform.position.y >= 0.5f && objs[aindex].transform.position.y < 1.0f)
                {
                    ascore += 20;

                    status.text = "Good";
                }
                else if (objs[aindex].transform.position.y > -0.5f && objs[aindex].transform.position.y <= 0.5f)
                {
                    ascore += 30;


                    status.text = "Excellent!";
                }
                score.text = "Score:" + ascore;

                Destroy(objs[aindex]);
                

                acombo++;
                combo.text = "Combo:" + acombo;
                aindex++;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))

        {

            right.GetComponent<SpriteRenderer>().color = Color.cyan;
            Invoke("reccolor", 0.2f);
            if (objs[aindex].transform.position.x == 10.0f&& objs[aindex].transform.position.y<=2.0f)
            {
                if (objs[aindex].transform.position.y >= -2.0f && objs[aindex].transform.position.y <= -1.0f || objs[aindex].transform.position.y >= 1.0f && objs[aindex].transform.position.y <= 1.5f)
                {
                    ascore += 10;
                    status.text = "OK";

                }
                else if (objs[aindex].transform.position.y > -1.0f && objs[aindex].transform.position.y <= -0.5f || objs[aindex].transform.position.y >= 0.5f && objs[aindex].transform.position.y < 1.0f)
                {
                    ascore += 20;

                    status.text = "Good";
                }
                else if (objs[aindex].transform.position.y > -0.5f && objs[aindex].transform.position.y <= 0.5f)
                {
                    ascore += 30;


                    status.text = "Excellent!";
                }
                score.text = "Score:" + ascore;
                Destroy(objs[aindex]);
                
                acombo++;
                combo.text = "Combo:" + acombo;
                aindex++;
            }
        }

        if (objs[aindex].transform.position.y<-2.0f)
        {
            Destroy(objs[aindex]);
            aindex++;
            status.text = "Miss";
            acombo = 0;
            combo.text = "Combo:" + acombo;
        }
    }
}
