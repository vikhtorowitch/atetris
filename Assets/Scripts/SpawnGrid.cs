using UnityEngine;
using System.Collections;

public class SpawnGrid : MonoBehaviour {

	//public GameObject grid_element;
	public Texture texWhite;
	public Texture texBlue;
	public Texture texGreen;

	private Canvas canv;

	private int[,] _arr;
	private int[,] _fixed;

	public float fallingSpeed = 1f;

	SpawnFigure figL;

	void Start () {
		_arr = new int[10,20];
		_fixed = new int[10,20];

		CleArr (_arr);
		CleArr (_fixed);

		figL = new SpawnFigure (6);

		//Debug.Log(_figL.Rank.ToString());
		//Debug.Log(_figL.GetUpperBound(0).ToString());
		//Debug.Log(_figL.GetUpperBound(1).ToString());

		/*
		Vector3 vec;
		for (int iy=1; iy<11; iy++)
			for (int ix=1; ix<11; ix++) {
				//vec.x = 
				//Instantiate (grid_element);
				GUI.Label(new Rect(ix, iy, 50, 50), "#");
			} */
		StartCoroutine(fallingFigures());
	}

	void CleArr(int[,] _clarr) {
		for (int iy=0; iy<_clarr.GetUpperBound(1)+1; iy++)
			for (int ix=0; ix<_clarr.GetUpperBound(0)+1; ix++)
				_arr [ix, iy] = 0;
	}

	void OnGUI () {
		for (int iy=1; iy<21; iy++)
		for (int ix=1; ix<11; ix++) {

			int cell = _arr[ix-1, iy-1];

			if (cell == 0) GUI.Label(new Rect(ix*25, iy*25, 30, 30), texWhite);
			else if (cell == 1) GUI.Label(new Rect(ix*25, iy*25, 30, 30), texBlue);
			else if (cell == 2) GUI.Label(new Rect(ix*25, iy*25, 30, 30), texGreen);
		}
		//Debug.Log("draw");

	}

	void CopyScreen(int[,] _source, int[,] _destination) {
		for (int iy=0; iy<20; iy++)
		for (int ix=0; ix<10; ix++) {
			_destination[ix, iy] = _source[ix, iy];			
		}

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow))	figL.RotateFigure ();	//_y--;
		if (Input.GetKeyDown (KeyCode.DownArrow))	fallingSpeed = 0f;
		if (Input.GetKeyDown (KeyCode.LeftArrow)) figL.x--;
		if (Input.GetKeyDown (KeyCode.RightArrow))	figL.x++;


		CleArr (_arr);
		//_arr [_x, _y] = 1;

		CopyScreen (_fixed, _arr);

		figL.DrawFigure(_arr, _fixed);

		if (figL.flagCollision) {
			Debug.Log("collision");
			CopyScreen (_arr, _fixed);
			_arr = new int[10,20];
			fallingSpeed = 1f;
			figL = new SpawnFigure (6);
		}

		/*
		for (int iy=0; iy<=_figL.GetUpperBound(0); iy++)
			for (int ix=0; ix<=_figL.GetUpperBound(1); ix++) {
				if (_figL[iy, ix] == 1) _arr[ix+_x, iy+_y] = 1;
			}
			*/
	}

	IEnumerator fallingFigures()
	{
		while(true)
		{
			if(figL != null) figL.y++;
			yield return new WaitForSeconds(fallingSpeed);
		}
	}
}
