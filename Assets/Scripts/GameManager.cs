using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int currentLevel;
	public int nrOfMoves;
	private int nrOfLevels;

//	public void Start()
//	{
//		PlayerPrefs.DeleteAll();
//	}

	public void Initialise(int nr)
	{
		nrOfMoves=nr;
		currentLevel=GetProgress();
	} 

	private int GetProgress()
	{
		int levelInt=0;

		for(int i=0; i<nrOfLevels+1; i++)
		{
			if(PlayerPrefs.HasKey(i.ToString()))
			{
				levelInt++;
			}
			else
			{
				levelInt++;
				break;
			}
		}
		return levelInt;
	}

	private int GetScore(string level)
	{
		return PlayerPrefs.GetInt(level);
	}

	private void SaveGame()
	{
		if(PlayerPrefs.HasKey(currentLevel.ToString()))
		{
			if(GetScore(currentLevel.ToString())>nrOfMoves)
			{
				PlayerPrefs.SetInt(currentLevel.ToString(),nrOfMoves);
			}else{
				PlayerPrefs.SetInt(currentLevel.ToString(),nrOfMoves);
			}
		}
	}

	public void StartGame()
	{
	this.gameObject.GetComponent<LevelHandler>().loadLevel(currentLevel);
	}

	public void GameFinished()
	{
		SaveGame();
		currentLevel++;
		nrOfMoves=0;
		this.gameObject.GetComponent<LevelHandler>().loadLevel(currentLevel);
	}

}

 


