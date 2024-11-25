using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGod : MonoBehaviour
{
	[SerializeField] private string exploreScene;
	[SerializeField] private string combatScene;
	public static SceneGod SInstance { get; private set; }
	public List<Character> EnemyCharacters;
	public bool WonLastBattle { get; private set; } = false;
	private enum GameState { Explore, Combat }

	private GameState _currentState;

	/// <summary>
	/// Initializes the SceneGod instance and ensures it persists across scenes.
	/// </summary>
	/// <remarks>
	/// This method is responsible for setting up the singleton instance of the SceneGod
	/// and ensuring it is not destroyed when loading new scenes. It also destroys duplicate
	/// instances that already exist in other scenes.
	/// </remarks>
	private void Awake()
	{
		// kill itself if there is another
		if (SInstance != null && SInstance != this)
		{
			if (SInstance.gameObject.scene.buildIndex != gameObject.scene.buildIndex)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			SInstance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}

	void Start()
	{
		//EnterCombatState(); testing
	}

	/// <summary>
	/// Transitions the application into the combat state.
	/// </summary>
	/// <remarks>
	/// This method sets up the environment and parameters required for the combat state.
	/// </remarks>
	/// <param name="characters">The list of characters from the encounter</param>
	public void EnterCombatState(List<Character> characters)
	{
		if (_currentState != GameState.Combat)
		{
			EnemyCharacters = characters;
			_currentState = GameState.Combat;
			SceneManager.LoadScene(combatScene);
		}
		else
		{
			Debug.LogWarning("Already in Combat Scene!");
		}
	}

	/// <summary>
	/// Transitions the application into the exploration state.
	/// </summary>
	/// <remarks>
	/// This method is responsible for setting up the environment required for the exploration state.
	/// </remarks>
	/// <param name="victory">Whether the player has won the last encounter</param>
	public void EnterExploreState(bool victory)
	{
		if (_currentState != GameState.Explore)
		{
			WonLastBattle = victory;
			_currentState = GameState.Explore;
			SceneManager.LoadScene(exploreScene);
		}
		else
		{
			Debug.LogWarning("Already in Explore Scene!");
		}
	}
}