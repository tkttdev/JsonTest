using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileTest : MonoBehaviour {

	//FileInfo fi;
	string jsonSv;
	byte[] encrypted;
	SaveDataManager svm = new SaveDataManager();

	public SaveData ls;

	public void Start(){
		SaveData[] sv = new SaveData[3];
		for (int i = 0; i < 3; i++) {
			sv [i] = new SaveData ();
		}
		Debug.Log (sv [0].money);
		svm.SaveData<SaveData> (sv);

		ls = svm.LoadData<SaveData> ();
		Debug.Log (ls.purchase[0]);
	}

	public void Write(){
		//SaveData sv = new SaveData ();
		//sv.level = 1;
		//sv.power = 10;
		//sv.n = "PIKOTAROU";
		//jsonSv = JsonUtility.ToJson (sv);
		//Debug.Log (jsonSv);
		//SaveData jsv = new SaveData ();
		//jsv = JsonUtility.FromJson<SaveData> (jsonSv);
		//byte[] jData = System.Text.Encoding.ASCII.GetBytes (jsonSv);
		//encrypted = en.EncryptionData (jData);
		//File.WriteAllBytes (Application.dataPath + "/test.txt", encrypted);
	}

	public void Read(){
		//byte[] enSD = File.ReadAllBytes (Application.dataPath + "/test.txt");
		//byte[] D = en.DecodingData (enSD);
		//Debug.Log (System.Text.Encoding.ASCII.GetString (D));
	}


}


