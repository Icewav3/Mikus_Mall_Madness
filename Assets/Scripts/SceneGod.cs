using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGod : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		LoadScene();
		ToggleScene(SampleScene);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void LoadScene()
	{
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
	}

	public void DeLoadScene()
	{
		SceneManager.UnloadSceneAsync("SampleScene");
	}

	public void ToggleScene(Scene scene)
	{
		SceneManager.SetActiveScene(scene);
	}
}
