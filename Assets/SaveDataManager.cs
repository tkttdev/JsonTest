using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SaveDataManager : MonoBehaviour {

	public void SaveData<T> (T[] cData){
		string jData = JsonUtility.ToJson (cData[0]);
		byte[] bData = Encoding.ASCII.GetBytes (jData);
		byte[] encryptedData = EncryptData (bData);
		File.WriteAllBytes (Application.dataPath + "/savedata.txt", encryptedData);
	}

	public T LoadData<T> (){
		byte[] encryptedData = File.ReadAllBytes (Application.dataPath + "/savedata.txt");
		byte[] decodedData = DecodeData (encryptedData);
		string jData = Encoding.ASCII.GetString (decodedData);
		T data = JsonUtility.FromJson<T> (jData);
		return data;
	}

	private byte[] EncryptData(byte[] data){
		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael.KeySize = 128;
		rijndael.BlockSize = 128;

		string pw = "password";
		string salt = "saltsalt";

		byte[] bSalt = Encoding.UTF8.GetBytes (salt);
		Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes (pw, bSalt);
		deriveBytes.IterationCount = 1000;

		rijndael.Key = deriveBytes.GetBytes (rijndael.KeySize / 8);
		rijndael.IV = deriveBytes.GetBytes (rijndael.BlockSize / 8);

		ICryptoTransform encryptor = rijndael.CreateEncryptor ();
		byte[] encryptedData = encryptor.TransformFinalBlock (data, 0, data.Length);

		encryptor.Dispose ();

		return encryptedData;
	}

	private byte[] DecodeData(byte[] data){
		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael.KeySize = 128;
		rijndael.BlockSize = 128;

		string pw = "password";
		string salt = "saltsalt";

		byte[] bSalt = Encoding.UTF8.GetBytes (salt);
		Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes (pw, bSalt);
		deriveBytes.IterationCount = 1000;

		rijndael.Key = deriveBytes.GetBytes (rijndael.KeySize / 8);
		rijndael.IV = deriveBytes.GetBytes (rijndael.BlockSize / 8);

		ICryptoTransform decryptor = rijndael.CreateDecryptor ();
		byte[] decodedData = decryptor.TransformFinalBlock (data, 0, data.Length);

		decryptor.Dispose ();

		return decodedData;
	}


}
