using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInformation{

	public static GlobalInformation globalInfo;

	List<Unit> units = new List<Unit>();
	List<GameObject> obstacles = new List<GameObject>();

	public string previousScene;

}
