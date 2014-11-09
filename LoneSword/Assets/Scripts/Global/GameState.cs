using UnityEngine;
using System.Collections.Generic;

/*
 * How to use:
 * 1. Place on a Game object in the scene that you want to be persistant throughout all levels.
 * 2. There is only one scene. All menu and gameplay will be performed in one scene.
 * 
 * @ Brian Chen
*/


public class GameState : Singleton {
	

	private int currentEnemies = 0;
	public int CurEnemies {
		set {
			currentEnemies = value;
			if (currentEnemies <= 0)
			{
				// Move on to the next area.
				GameObject.FindWithTag("Player").GetComponent<FollowWaypoint>().MoveToNextWaypoint();
			}
		}
		get{return currentEnemies;}
	}
	public int maxEnemiesInRound = 0;

	private int currentWaypoint = -1;

	private int nextWaypoint = -1;

	GameObject paths;

	public int totalEnemiesKilled = 0;

	public Transform NextWaypoint()
	{

		if (!paths)
		paths = GameObject.Find ("Paths");

		nextWaypoint ++;

		if (nextWaypoint >= 5 || nextWaypoint < 0)
		{
			nextWaypoint = 0;
		}
		UpdateToNextWaypoint();
		return paths.GetComponent<PlayerWaypoints> ().waypoints[nextWaypoint].transform;
	}

	public void UpdateToNextWaypoint()
	{
		if (!paths)
		paths = GameObject.Find ("Paths");
		paths.GetComponent<PlayerWaypoints> ().waypoints [nextWaypoint].collider.enabled = true;
		paths.GetComponent<PlayerWaypoints> ().waypoints [nextWaypoint].GetComponent<WaypointLinker>().waypointTrigger.enabled = true;
	}

	public void ResetWaypointNums()
	{
		currentWaypoint = -1;
		nextWaypoint = -1;
	}


#region Inherited functions
	protected override void DestroyIfMoreThanOneOnObject(){
		if (transform.GetComponents<GameState>().Length > 1){
			Debug.Log ("Destroying Extra " + this.GetType() + " Attachment");
			DestroyImmediate(this);
		}
	}
#endregion
}






