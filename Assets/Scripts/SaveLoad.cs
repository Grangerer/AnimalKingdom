using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine;

public static class SaveLoad {


	public static List<Player> savedPlayers = new List<Player>();

	public static void SavePlayer(){
		savedPlayers.Add(Player.current);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize(file, SaveLoad.savedPlayers);
		file.Close();
	}

	public static void LoadPlayer(){
		Debug.Log(Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {	
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

			SaveLoad.savedPlayers = (List<Player>)bf.Deserialize(file);
			file.Close();
		}
	}


}
