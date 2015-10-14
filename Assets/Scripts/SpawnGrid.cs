using UnityEngine;
using System.Collections;

public class SpawnGrid : MonoBehaviour {

	public GameObject grid_element;
	public Texture texWhite;
	public Texture texBlue;

	private Canvas canv;

	private int _x = 4;
	private int _y = 4;

	private int[,] _arr;

	SpawnFigure figL;

	void Start () {
		_arr = new int[10,20];

		CleArr ();
		_arr [0, 0] = 1;

		figL = new SpawnFigure(new int[,] {
			{1,0},
			{1,0},
			{1,1}
		});

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
	}

	void CleArr() {
		for (int iy=0; iy<20; iy++)
			for (int ix=0; ix<10; ix++)
				_arr [ix, iy] = 0;
	}

	void OnGUI () {
		for (int iy=1; iy<21; iy++)
		for (int ix=1; ix<11; ix++) {

			if(_arr[ix-1, iy-1] == 0) GUI.Label(new Rect(ix*25, iy*25, 30, 30), texWhite);
				else GUI.Label(new Rect(ix*25, iy*25, 30, 30), texBlue);
		}
		//Debug.Log("draw");

	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow))	figL.RotateFigure ();	//_y--;
		if (Input.GetKeyDown (KeyCode.DownArrow))	_y++;
		if (Input.GetKeyDown (KeyCode.LeftArrow)) _x--;
		if (Input.GetKeyDown (KeyCode.RightArrow))	_x++;
		CleArr ();
		//_arr [_x, _y] = 1;

		figL.DrawFigure(_arr, _x, _y);

		/*
		for (int iy=0; iy<=_figL.GetUpperBound(0); iy++)
			for (int ix=0; ix<=_figL.GetUpperBound(1); ix++) {
				if (_figL[iy, ix] == 1) _arr[ix+_x, iy+_y] = 1;
			}
			*/
	}
}
