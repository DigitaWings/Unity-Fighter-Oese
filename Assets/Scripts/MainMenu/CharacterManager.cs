using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour {

	public int numberOfUsers;
	public List<PlayerBase> players = new List<PlayerBase>(); // The list with all our players and player types

	//The list were we hold anything we need to know for each separate character,
	//for now, it's their id and their corresponding prefab
	public List<CharacterBase> characterList = new List<CharacterBase>();

	//We use this function to find characters from their id
	public CharacterBase returnPlayerWithID(string id)
	{
		CharacterBase retVal = null;

		for (int i = 0; i < characterList.Count; i++)
		{
			if(string.Equals(characterList[i].charId,id))
			{
				retVal = characterList[i];
				break;
			}
		}

		return retVal;
	}

	//We use this one to return th eplayer from his created character, states
	public PlayerBase returnPlayerFromStates(StateManager states)
	{
		PlayerBase retVal = null;

		for (int i = 0; i < players.Count; i++)
		{
			if(players[i].playerStates == states)
			{
				retVal = players[i];
				break;
			}
		}

		return retVal;
	}

	public static CharacterManager instance;
	public static CharacterManager GetInstance()
	{
		return instance;
	}

	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(this.GameObject);
	}
}

[System.Serializable]
public class CharacterBase
{
	public string charId;
	public GameObject prefab;
}

[System.Serializable]
public class PlayerBase
{
	public string playerId;
	public string inputId;
	public PlayerType playerType;
	public bool hasCharacter;
	public GameObject playerPrefab;
	public StateManager playerStates;
	public int score;

	public enum PlayerType
	{
		user, //Its a real human
		ai, //Skynet basically
		simulation //For multiplayer over network. no, that's not a promise..
	}
}