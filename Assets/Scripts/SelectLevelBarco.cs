using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelBarco : MonoBehaviour
{
    public string Level1;
    public string WorldSelect;

    public void level1()
    {
        SceneManager.LoadScene(Level1);
    }

    public void worldSelect()
    {
        SceneManager.LoadScene(WorldSelect);
    }

}
