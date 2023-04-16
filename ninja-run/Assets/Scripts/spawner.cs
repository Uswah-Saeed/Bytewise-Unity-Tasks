using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monstorReference;
    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnMonstor;
    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonstors());
    }

    IEnumerator spawnMonstors()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monstorReference.Length);
            randomSide = Random.Range(0, 2);
            spawnMonstor = Instantiate(monstorReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnMonstor.transform.position = leftPos.position;
                spawnMonstor.GetComponent<monstor>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnMonstor.transform.position = rightPos.position;
                spawnMonstor.GetComponent<monstor>().speed = -Random.Range(4, 10);
                spawnMonstor.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }


    }














}
