using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData  {
	public bool[] purchase = new bool[10];
	public int money = 0;

	public SaveData(){
		for (int i = 0; i < 10; i++) {
			purchase [i] = false;
			money = 0;
		}
	}
}
