using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class LevelHandler : MonoBehaviour 
{
	
	XmlDocument levelDoc;
	XmlNodeList levelList;
	List<string> levelArray;
	
	void Start () 
	{
		
		levelArray = new List<string> ();
		levelDoc = new XmlDocument();
		TextAsset xmlfile = Resources.Load ("levels", typeof(TextAsset)) as TextAsset;
		levelDoc.LoadXml (xmlfile.text);
		levelList = levelDoc.GetElementsByTagName("level");
		foreach (XmlNode leveldata in levelList) 
		{
			XmlNodeList levelinfo = leveldata.ChildNodes;
			Debug.Log (levelList.Count);
			foreach (XmlNode data in levelinfo) 
			{
				Debug.Log(data.Name);
				if(data.Name == "setup")
				{
					Debug.Log(data.InnerText);
					levelArray.Add(data.InnerText);
				}
			}
			
		}
		this.gameObject.GetComponent<GameManager>().Initialise(levelArray.Count);
		
	}

	public void loadLevel(int nr)
	{
		string levelArrTest = levelArray[nr - 1];
		string[] levString = levelArrTest.Split(',');
		foreach (string brick in levString)
		{
			GameObject.Find(brick).GetComponent<ColorSwitch>().change();
		}
		
	}
	
	
}
