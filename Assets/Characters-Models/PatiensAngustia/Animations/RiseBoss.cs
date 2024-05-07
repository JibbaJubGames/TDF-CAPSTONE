using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseBoss : MonoBehaviour
{
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = this.gameObject;
        boss.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 8.5f, transform.position.z), 1 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        boss.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 25.5f, transform.position.z), 1* Time.deltaTime);
    }
}