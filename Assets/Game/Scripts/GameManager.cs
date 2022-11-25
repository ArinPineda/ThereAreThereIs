using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
         //   DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

    }

    public IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void TeleportRelaxRoom()
    {
        MasterController.Instance.transform.position = new Vector3(-0.45f,-2.09f,32.44f);

    }

    public void TeleportOfficeRoom()
    {
        MasterController.Instance.transform.position = new Vector3(-7f, -1.732f, -22.59f);

    }









}
