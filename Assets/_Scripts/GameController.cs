using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    #region SingletonCode
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    //single pattern ends here
    #endregion  

    public void EndGameWin()    
    {
        SceneManager.LoadScene(3);
    }
    public void EndGameLoss()
    {
        SceneManager.LoadScene(4);
    }
    public void EndGameLossMulti()
    {
        SceneManager.LoadScene(5);
    }

}