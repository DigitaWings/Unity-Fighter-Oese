using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SelectScreenManager : MonoBehaviour 
{
	public int numberOfPlayers = 1;
	public List <PlayerInterfaces> p1Interfaces = new List<PlayerInterfaces>();
	public PotraitInfo[] potraitPrefabs; // All our enteries as potraits
	public int maxX; // How many potraits we have on the x and y NOTE: This are hardcodeed!
	public int maxY;
	PotraitInfo[,] charGrid; // The grid we are making to select entries

	public GameObject potraitCanvas; // The canvas that holds all the potraits

	bool loadlevel; // if we are loading the level
	public bool bothPlayersSelected;

	CharacterManager charManager;

	#region Singleton
	public static SelectScreenManager instance;
	public static SelectScreenManager Getinstance()
	{
		return instance;
	}

	void Awake()
	{
		instance = this;
	}
	#endregion

	void Start()
	{
		// We start by getting the reference to the character manager
		charManager = CharacterManager.GetInstance();
		numberOfPlayers = charManager.numberOfUsers;

		// And we create the grid
		charGrid = new PotraitInfo[maxX, maxY];

		int x = 0;
		int y = 0;

		potraitPrefabs = potraitCanvas.GetComponentsInChildren<PotraitInfo>();

		// We need to go into all our potraits
		for (int i = 0; i < potraitPrefabs.Length; i++)
		{
			// And assign a grid position
			potraitPrefabs[i].posX += x;
			potraitPrefabs[i].posY += y;

			charGrid[x, y] = potraitPrefabs[i];

			if (x < maxX - 1)
			{
				x++;
			}
			else
			{
				x = 0;
				y++;
			}
		} 
	}

	void Update()
	{
		if (!loadLevel)
		{
			for (int i = 0; i < p1Interfaces.Count; i++)
			{
				if (i < numberOfPlayers)
				{
					if (!charManager.players[i].hasCharacter)
					{
						p1Interfaces[i].playerBase = charManager.players[i];

						HandleSelectorPosition(p1Interfaces[i]);
						HandleSelectScreenInput(p1Interfaces[i], charManager.players[i].inputId);
						HandleCharacterPreview(p1Interfaces[i]);
					}
				}
				else
				{
					charManager.players[i].hasCharacter = true;
				}
			}
		}
	}

	if(bothPlayersSelected)
	{
		Debug.Log("loading");
		StartCoroutine("LoadLevel"); // And start the coroutine to load the level
		loadLevel = true;
	}
	else
	{
		if(charManager.players[0].hasCharacter
			&& charManager.players[1].hasCharacter)
		{
			bothPlayersSelected = true;
		}

	}



	void HandleSelectScreenInput(PlayerInterfaces p1, string playerId)
{
	#region Grid Navigation

	/*To navigate in the grid
	* we simply change the active x and y to select what entry is active
	* we also smooth out the input so if the user keeps pressing the button
	* it won't switch more than once over half a second 
	*/
}
}