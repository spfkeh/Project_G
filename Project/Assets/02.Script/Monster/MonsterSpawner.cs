using System.Collections;
using System.Collections.Generic;
using System.Globalization;
//using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _Target;
    [SerializeField] private GameObject _Wave;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    private bool spawnLeft = false;

    void Start()
    {

    }

    public void SpawnLeft()
    {
        GameObject obj = Instantiate(enemy, left.position, Quaternion.Euler(0, 0, 0));
        Monster monster = obj.GetComponent<Monster>();
        monster.targetPoint = _Target;
        monster.wave = gameObject;
    }

    public void SpawnRight()
    {
        GameObject obj = Instantiate(enemy, right.position, Quaternion.Euler(0, 180f, 0));
        Monster monster = obj.GetComponent<Monster>();
        monster.targetPoint = _Target;
        monster.wave = gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLeft();
        }
    }
}