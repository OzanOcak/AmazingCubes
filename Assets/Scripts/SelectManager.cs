using UnityEngine;
using System.Collections;

public class SelectManager : MonoBehaviour 
{

	
	void Start () 
	{
		
		int count = 1;
		
		for(int i = 0; i<5; i++)
		{
			for(int j = 0; j<5; j++)
			{
				GameObject tmpGb = Instantiate(Resources.Load("Plane", typeof(GameObject))) as GameObject;
				tmpGb.transform.position = new Vector3(j*1.5f-3f,i*-1.5f+3,0);
				tmpGb.name = count.ToString();
				count++;
			}
		}

	}
//
//	private void LoadLevel(int levelNum) {
//		this.gameObject.GetComponent<LevelHandler>().loadLevel(levelNum);
//	}


//	private bool levelLoaded = false;

	void Update () 
	{
//		if(/*Input.anyKeyDown && */levelLoaded == false) {
//			LoadLevel(1);
//			levelLoaded = true;
//		}
		
		if(Input.GetMouseButtonUp(0))
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit,100))
			{
				try{
					makeMove(int.Parse(hit.collider.gameObject.name));
				}catch{
					
				}
			}
			
		}
		
		
	}
	
	void makeMove(int name)
	{
		
		//this.gameObject.GetComponent<engine> ().playClickSound ();
		
		turn (name);
		turn (name + 5);
		turn (name - 5);
		if(name%5 !=0){
			turn (name+1);
		}
		if(name%5 !=1){
			turn (name-1);
		}
		CheckIfGameOver();
	}
	
	void turn(int name)
	{
		if(name<1 || name>25)return;
		
		GameObject turnObj = GameObject.Find (name.ToString ()).gameObject;
		turnObj.GetComponent<ColorSwitch> ().change();
		
	}
	private void CheckIfGameOver()
	{
		this.gameObject.GetComponent<GameManager>().nrOfMoves++;

		for (int i=1; i<=26; i++)
		{
			if (GameObject.Find(i.ToString()).GetComponent<ColorSwitch>().isGreen&&
			    GameObject.Find(i.ToString()).GetComponent<ColorSwitch>().isRed&&
			    GameObject.Find(i.ToString()).GetComponent<ColorSwitch>().isYellow)
			{
				Debug.Log (i.ToString());
				return;
			}
			//Debug.Log ("this is red");
		}

		this.gameObject.GetComponent<GameManager>().GameFinished();
		Debug.Log ("gamefinished");
	 }

}
	

