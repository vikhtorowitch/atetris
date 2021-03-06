﻿using UnityEngine;
using System.Collections;

public class SpawnGrid : MonoBehaviour {

	//public GameObject grid_element;
	public Texture texWhite;
	public Texture texBlue;
	public Texture texGreen;

	private Canvas canv;

	private int[,] _arr;
	private int[,] _fixed;

	public float defaultFallingSpeed = 1f;
	public float dropSpeed = 0.01f;

	private float fallingSpeed;

	private SpawnFigure activeFigure;
	private SpawnFigure nextFigure;

	private float timer = 0f;

	void Start () {

		fallingSpeed = defaultFallingSpeed;

		_arr = new int[10,20];
		_fixed = new int[10,20];

		CleArr (_arr);
		CleArr (_fixed);

		activeFigure = new SpawnFigure (6);

	}

	void CleArr(int[,] _clarr) {
		for (int iy=0; iy<_clarr.GetUpperBound(1)+1; iy++)
			for (int ix=0; ix<_clarr.GetUpperBound(0)+1; ix++)
				_arr [ix, iy] = 0;
	}

	void OnGUI () {
		/*
		float fl = (float)(Screen.width * 0.20);
		int cellWidth = Mathf.RoundToInt (fl);
		*/
		int cellWidth = 30;
		int cellGrid = 25;

		for (int iy=1; iy<21; iy++)
		for (int ix=1; ix<11; ix++) {

			int cell = _arr[ix-1, iy-1];

			if (cell == 0) GUI.Label(new Rect(ix*cellGrid, iy*cellGrid, cellWidth, cellWidth), texWhite);
			else if (cell == 1) GUI.Label(new Rect(ix*cellGrid, iy*cellGrid, cellWidth, cellWidth), texBlue);
			else if (cell == 2) GUI.Label(new Rect(ix*cellGrid, iy*cellGrid, cellWidth, cellWidth), texGreen);
		}
		//Debug.Log("draw");
		if (activeFigure.flagNoMoreSpace) {
			Debug.Log("nomorespace");
			//Time.timeScale = 0;
		GUI.Label(new Rect(Screen.width / 2 - Screen.width / 24, Screen.height / 3, Screen.width / 12, Screen.width / 24), "Game Over");
		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 24, Screen.height / 2, Screen.width / 12, Screen.width / 24), "Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}

	void CopyScreen(int[,] _source, int[,] _destination) {
		for (int iy=0; iy<20; iy++)
		for (int ix=0; ix<10; ix++) {
			_destination[ix, iy] = _source[ix, iy];			
		}

	}

	void Update () {

		timer += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.UpArrow))	activeFigure.RotateFigure (_fixed);	//_y--;
		if (Input.GetKeyDown (KeyCode.DownArrow))	fallingSpeed = dropSpeed;
		if (Input.GetKeyDown (KeyCode.LeftArrow)) activeFigure.x--;
		if (Input.GetKeyDown (KeyCode.RightArrow))	activeFigure.x++;

		if (timer >= fallingSpeed) {
			activeFigure.y++;
			timer = 0f;
		}

		if (!activeFigure.flagNoMoreSpace) {

			CleArr (_arr);
			//_arr [_x, _y] = 1;

			CopyScreen (_fixed, _arr);

			activeFigure.DrawFigure (_arr, _fixed);


			if (activeFigure.flagCollision) {
				//Debug.Log("collision");
				CopyScreen (_arr, _fixed);
				_arr = new int[10, 20];
				fallingSpeed = defaultFallingSpeed;
				activeFigure = new SpawnFigure (6);
			}
		}

	}

}
