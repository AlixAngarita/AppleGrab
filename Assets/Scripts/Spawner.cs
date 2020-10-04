using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject apple;
    public float width;
    float spawningTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(time > spawningTime)
        {
            GameObject go = Instantiate(apple);
            go.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            time = 0;
            Destroy(go, 3);
            spawningTime = Random.Range(queueTime - 1.0f, queueTime);
        }

        time += Time.deltaTime;
    }
}
