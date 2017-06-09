using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	private bool occupied;
	private bool currentlyMovable;
	private bool currentlyAttackable;
	private GameObject unit = null;
	private int xGridPosition;
	private int zGridPosition;
	public GameObject activatableUnit;

	private Material defaultMaterial;

	[SerializeField]
	private List<GameObject> adjacentTiles;

	// Use this for initialization
	void Start () {
		defaultMaterial = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentlyMovable || currentlyAttackable) {
			ActivateAnimation ();
		} else {
			DeactivateAnimation ();
		}
	}

	public void Setup(int xGrid, int zGrid){
		xGridPosition = xGrid;
		zGridPosition = zGrid;
		this.name = "Tile("+xGrid+")("+zGrid+")";
	}
		
	public void SetAllAdjacentTiles(){
		for (int i = -1; i <= 1; i+=2) {
				if (GameObject.Find ("Tile("+(xGridPosition+i)+")("+zGridPosition+")") != null) {
					//Debug.Log("Found: "+ "Tile("+(xGridPosition+i)+")("+(zGridPosition+j)+")");
					adjacentTiles.Add(GameObject.Find ("Tile("+(xGridPosition+i)+")("+zGridPosition+")"));
				}											
		}
		for (int j = -1; j <= 1; j+=2) {
			if (GameObject.Find ("Tile("+xGridPosition+")("+(zGridPosition+j)+")") != null) {
				//Debug.Log("Found: "+ "Tile("+(xGridPosition+i)+")("+(zGridPosition+j)+")");
				adjacentTiles.Add(GameObject.Find ("Tile("+xGridPosition+")("+(zGridPosition+j)+")"));
			}
		}
	}

	public void ShowUsableUnit(){
		activatableUnit.SetActive (true);
	}
	public void HideUsableUnit(){
		activatableUnit.SetActive (false);
	}

	public void Recolor(Material newMaterial){
		GetComponent<Renderer> ().material = newMaterial;
	}

	public void ResetColor(){
		GetComponent<Renderer> ().material = defaultMaterial;
		currentlyMovable = false;
		currentlyAttackable = false;
	}

	public void ReferenceUnit(GameObject unit){
		this.unit = unit;
		if (unit == null) {
			activatableUnit.SetActive (false);
			occupied = false;
		} else {
			occupied = true;
			if (unit.GetComponent<Unit> ().OwnedByPlayer) {
				activatableUnit.SetActive (true);
			}
		}	

	}

	public void ActivateAnimation(){
		this.GetComponent<Animator> ().enabled = true;
	}
	public void DeactivateAnimation(){
		this.GetComponent<Animator> ().enabled = false;
	}


	//Propertystuff (Autogenerating)
	public List<GameObject> AdjacentTiles {
		get {
			return adjacentTiles;
		}
	}
	public bool CurrentlyMovable {
		get {
			return currentlyMovable;
		}
		set {
			currentlyMovable = value;
		}
	}
	public bool Occupied {
		get {
			return occupied;
		}
		set {
			occupied = value;
		}
	}
	public GameObject Unit {
		get {
			return unit;
		}
	}
	public bool CurrentlyAttackable {
		get {
			return currentlyAttackable;
		}
		set {
			currentlyAttackable = value;
		}
	}
}
