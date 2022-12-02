using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendoSkill : MonoBehaviour
{
    [SerializeField] GameObject kenki;
    [SerializeField] Friend kendo;
    float cost;

    public void Skill()
    {
        if(kendo.detect.DetectiveObj != null)
        {
            Vector3 position = kendo.detect.DetectiveObj.transform.position;
            Vector3 KenkiPos = new Vector3(kendo.transform.position.x, kendo.transform.position.y - 0.5f, kendo.transform.position.z);
            GameObject Obj = Instantiate(kenki, KenkiPos, Quaternion.identity);
            Kenki Ki = Obj.GetComponent<Kenki>();

            if (kendo.transform.position.x > position.x)
            {
                Ki.left();
            }
            else if (kendo.transform.position.x < position.x)
            {
                Ki.Right();
            }
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Skill();
        }
    }
}