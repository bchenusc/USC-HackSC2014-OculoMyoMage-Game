﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * How to use:
 * 1. Construct the timer class in your singleton.
 * 2. In the singleton's update function, call Timer.update;
 * 
 * Notes:
 * 1. When you add a timer, the first call back is what you want the timer to do when the timer fires.
 * 2. The second call back is what you want the timer to do after the timer is done going off.
 * 	- For instance, if you make a timer repeat 10x and after 10x you want it to do something, that is the second callback.
 * 
 * @ Brian Chen
 * 
*/

public class Timer : Singleton  {
	
	public class TimerInstance{
		
		public event Action A_FireQueue;
		public bool b_looping;
		public float f_curTime;
		public float f_resetTime;
		public int i_triggerCount;
		public int i_loopThisManyTimes;
		public event Action A_AfterCallBackQueue;
		
		public bool b_removeMe;
		
		public void Fire(){
			A_FireQueue();
		}
		public bool FireHasQueue(){return A_FireQueue!=null;}
		
		public void AfterCallBack(){
			A_AfterCallBackQueue();
		}
		public bool AfterCallBackHasQueue(){return A_AfterCallBackQueue!=null;}
	}
	
	//public delegate void Action(); //use if no delegates class.
	private SortedList<string, TimerInstance> sl_pending = new SortedList<string, TimerInstance>();
	private SortedList<string, TimerInstance> sl_active = new SortedList<string, TimerInstance>();
	
	
	public void Update () {
		//Move from pending up to active.
		foreach (KeyValuePair<string, TimerInstance> kvp in sl_pending){
			
			sl_active.Add(kvp.Key, kvp.Value);
		}
		sl_pending.Clear();
		
		//Update each active timer.
		foreach (TimerInstance t in sl_active.Values){
			if (t.b_removeMe) continue;
			if (t.f_curTime > 0) {t.f_curTime-= Time.deltaTime;}
			if (t.f_curTime < 0) {t.f_curTime = 0;}
			if (t.f_curTime == 0){
				//Fire timer here
				if (t.FireHasQueue()){
					t.Fire();
				}
				t.i_triggerCount ++;
				
				if (t.b_looping || t.i_loopThisManyTimes > 0){
					
					if (!t.b_looping && t.i_triggerCount >= t.i_loopThisManyTimes){
						t.b_removeMe = true;
						if(t.AfterCallBackHasQueue()){
							t.AfterCallBack();
						}
					}else{
						t.f_curTime = t.f_resetTime;
					}
					
				}
				else {
					t.b_removeMe = true;
				}
			}
		}
		
		// Remove timers that need to be removed.
		for (int i = sl_active.Count - 1; i >= 0; i--)
		{
			if (sl_active.Values[i].b_removeMe)
			{
				sl_active.RemoveAt(i);
			}
		}
	}
	
	public bool Add(string name, Action callback, float time, bool looping, int loopForThisManyTimes = 0, Action afterCallback = null){
		
		if (!sl_active.ContainsKey(name)){
			//If the active timers doesn't contain a name that already exists create a new Timer instance.
			TimerInstance t = new TimerInstance();
			t.A_FireQueue += callback;
			t.f_resetTime = time;
			t.f_curTime = time;
			t.b_looping = looping;
			t.i_triggerCount = 0;
			t.i_loopThisManyTimes = loopForThisManyTimes;
			t.A_AfterCallBackQueue += afterCallback;
			
			t.b_removeMe = false;
			
			if (sl_pending.ContainsKey(name)){
				sl_pending.Remove(name);
			}
			sl_pending.Add(name, t);
			return true;
			
		}
		else return false;
	}
	
	public bool Remove(string name){
		if (sl_active.ContainsKey(name)){
			sl_active[name].b_removeMe = true;
			return true;
		}else{
			if (sl_pending.ContainsKey(name)){
				sl_pending[name].b_removeMe = true;
				return true;
			}
			return false;
		}
	}

	public void RemoveAll() {
		foreach (KeyValuePair<string, TimerInstance> kvp in sl_pending){
			kvp.Value.b_removeMe = true;
		}
		foreach (KeyValuePair<string, TimerInstance> kvp in sl_active){
			kvp.Value.b_removeMe = true;
		}
		
	}
	
	#region Inherited functions
	protected override void DestroyIfMoreThanOneOnObject(){
		if (transform.GetComponents<Timer>().Length > 1){
			Debug.Log ("Destroying Extra " + this.GetType() + " Attachment");
			DestroyImmediate(this);
		}
	}
	
	#endregion
	
}













