using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    public int SceneIndex;
    /// <summary>
    /// Changes the scene to the corresponding scene with the name that the string SceneName is set to. 
    /// </summary>
    public void ChangeScene()
    {
	    SceneManager.LoadScene(SceneIndex);
    }
}