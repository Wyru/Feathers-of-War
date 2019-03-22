using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLeves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Load1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Load2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Load3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
