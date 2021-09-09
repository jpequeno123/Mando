using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject bruh;
    public void dDie()
    {
        //olho = GameObject.Find("Enemy");

        Debug.Log("Enemy died!");

        bruh.SetActive(false);

        Application.Quit();


    }
}
