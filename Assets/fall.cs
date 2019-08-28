using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{

    public GameObject fallobject;
    // Start is called before the first frame update

    IEnumerator FuncCoroutine(int inity)
    {
        Vector2 vec = fallobject.transform.position;
        vec.y = inity;
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

    void Start()
    {
        StartCoroutine(FuncCoroutine(40));
    }

    

// Update is called once per frame
void Update()
    {
        
    }
}
