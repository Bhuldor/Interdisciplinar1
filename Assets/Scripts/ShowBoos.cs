using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoos : MonoBehaviour
{
    public GameObject boss;
    public AudioSource bossSound;

    private void OnTriggerEnter(Collider other)
    {
        boss.SetActive(true);
        bossSound.Play();
        Destroy(this, 1f);
    }
}
