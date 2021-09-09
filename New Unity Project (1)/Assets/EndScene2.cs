using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene2 : MonoBehaviour
{
    public GameObject bruh;
    public GameObject heath;
    public void Hello()
    {
        heath.SetActive(true);
    }
    public void dDie()
    {
        //olho = GameObject.Find("Enemy");

        Debug.Log("Enemy died!");

        bruh.SetActive(false);

        SceneManager.LoadScene(3);


    }
}
