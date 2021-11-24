using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject timeLine;
    public GameObject ferstPers;
    public GameObject secentPers;
    public GameObject cutCame;
    public GameObject player;
    //public GameObject triggerplayer;
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutCame.SetActive(true);
        ferstPers.SetActive(true);
        timeLine.SetActive(true);
        secentPers.SetActive(true);
        player.SetActive(false);
        //triggerplayer.SetActive(false);
        StartCoroutine(FinishCut());

    }
    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(24);
        cutCame.SetActive(false);
        ferstPers.SetActive(false);
        timeLine.SetActive(false);
        secentPers.SetActive(false);
        player.SetActive(true);
        //triggerplayer.SetActive(true);

    }
}
