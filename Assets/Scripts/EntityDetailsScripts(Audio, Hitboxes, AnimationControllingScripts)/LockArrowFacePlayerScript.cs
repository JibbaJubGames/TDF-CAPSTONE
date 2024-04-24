using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockArrowFacePlayerScript : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Jerbulcha");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 npcPos = gameObject.transform.position;
            Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
            Quaternion rotation = Quaternion.LookRotation(delta);
            gameObject.transform.rotation = rotation;
        }
        else { return; }
    }
}
