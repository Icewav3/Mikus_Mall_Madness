using UnityEngine;

public class CharacterActor : MonoBehaviour
{
	public Character Character { get; private set; }
	public void Init(Character character)
	{
		Character = character;
	}
}