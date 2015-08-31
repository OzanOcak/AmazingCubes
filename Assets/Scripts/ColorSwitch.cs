using UnityEngine;
using System.Collections;

public class ColorSwitch : MonoBehaviour 
{
	public bool isBlue=true;
	public bool isGreen=false;
	public bool isRed=false;	
	public bool isYellow=false;	
//	private Vector3 bluePos;
	private Vector3 greenPos;
	private Vector3 redPos;
	private Vector3 yellowPos;


	void Start () 
	{
		 
		//bluePos=this.transform.Find("blue").transform.position;
		greenPos=this.transform.Find("green").transform.position;
		redPos=this.transform.Find("red").transform.position;
		yellowPos=this.transform.Find("yellow").transform.position;
	}

	public void change () 
	{
		if(isBlue)
		{
			isBlue=false;
			isGreen=true;
			this.transform.Find("green").position=new Vector3(greenPos.x,greenPos.y,greenPos.z-.15f);
		}
		else if(isGreen)
		{
			isGreen=false;
			this.transform.Find("green").position=new Vector3(greenPos.x,greenPos.y,greenPos.z+.15f);
			isRed=true;
			this.transform.Find("red").position=new Vector3(redPos.x,redPos.y,redPos.z-.15f);
		}
		else if(isRed)
		{
			isRed=false;
			this.transform.Find("red").position=new Vector3(redPos.x,redPos.y,redPos.z+.15f);
			isYellow=true;
			this.transform.Find("yellow").position=new Vector3(yellowPos.x,yellowPos.y,yellowPos.z-.15f);
		}
		else if(isYellow)
		{
			isGreen=false;
			this.transform.Find("yellow").position=new Vector3(yellowPos.x,yellowPos.y,yellowPos.z+.15f);
			isBlue=true;
		}
	
	}
}
