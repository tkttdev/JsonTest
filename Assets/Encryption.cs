using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public class Encryption : MonoBehaviour {

	public byte[] EncryptionData(byte[] data){
		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael.KeySize = 128;
		rijndael.BlockSize = 128;

		// パスワードから共有キーと初期化ベクターを作成
		string pw = "passward";
		string salt = "saltsalt";

		byte[] bSalt = Encoding.UTF8.GetBytes (salt);
		Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes (pw, bSalt);
		deriveBytes.IterationCount = 1000;        // 反復回数

		rijndael.Key = deriveBytes.GetBytes (rijndael.KeySize / 8);
		rijndael.IV = deriveBytes.GetBytes (rijndael.BlockSize / 8);

		// 暗号化
		ICryptoTransform encryptor = rijndael.CreateEncryptor ();
		byte[] encrypted = encryptor.TransformFinalBlock (data, 0, data.Length);

		encryptor.Dispose ();

		return encrypted;
	}

	public byte[] DecodingData(byte[] data){
		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael.KeySize = 128;
		rijndael.BlockSize = 128;

		// パスワードから共有キーと初期化ベクターを作成
		string pw = "passward";
		string salt = "saltsalt";

		byte[] bSalt = Encoding.UTF8.GetBytes (salt);
		Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes (pw, bSalt);
		deriveBytes.IterationCount = 1000;        // 反復回数

		rijndael.Key = deriveBytes.GetBytes (rijndael.KeySize / 8);
		rijndael.IV = deriveBytes.GetBytes (rijndael.BlockSize / 8);

		// 復号化
		ICryptoTransform decryptor = rijndael.CreateDecryptor ();
		byte[] plain = decryptor.TransformFinalBlock (data, 0, data.Length);

		decryptor.Dispose ();

		return plain;
	}
}
