using UnityEngine;
using System.Collections;

public class SpawnFigure {

	private int[,] _figure;
	private int[,] _buffer;

	public int x = 4;
	public int y = 0;

	public bool flagCollision = false;

	private int prev_x = 4;
	private int prev_y = 0;

	public SpawnFigure(int figureType) {
		switch (figureType) {
		case 0:
			_figure = new int[,] {
				{1,0},
				{1,0},
				{1,0},
				{1,0}
				};
			break;
		case 1:
			_figure = new int[,] {
				{1,1},
				{1,1}
			};
			break;
		case 2:
			_figure = new int[,] {
				{1,0},
				{1,0},
				{1,1}
			};
			break;
		case 3:
			_figure = new int[,] {
				{0,1},
				{0,1},
				{1,1}
			};
			break;
		case 4:
			_figure = new int[,] {
				{1,0},
				{1,1},
				{0,1}
			};
			break;
		case 5:
			_figure = new int[,] {
				{0,1},
				{1,1},
				{1,0}
			};
			break;
		case 6:
			_figure = new int[,] {
				{1,1,1},
				{0,1,0}
			};
			break;

		}
	}

	public void DrawFigure(int[,] _destination, int[,] _fixed) {

		if ((x+_figure.GetUpperBound(0)) > (_destination.GetUpperBound(0))) x = _destination.GetUpperBound(0)-_figure.GetUpperBound(0); 
		if (x < 0) x = 0; 

		if (y  > (_fixed.GetUpperBound(1) - _figure.GetUpperBound(1))) {
			flagCollision = true;
			x = prev_x;
			y = prev_y;

		}

		for (int iy=0; iy<=_figure.GetUpperBound(1); iy++)
			for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) {
				if ((_figure [ix, iy] == 1) && (_fixed [ix + x, iy + y] == 1)) {
					if (iy <= y) {
						flagCollision = true;
					}
				x = prev_x;
				y = prev_y;
			}
			}
		//if (!flagCollision)	
		for (int iy=0; iy<=_figure.GetUpperBound(1); iy++)
		for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) {
			if(_figure[ix, iy] == 1) _destination[ix+x, iy+y] = _figure[ix, iy];
		}

		//for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) 
			//_destination [x+ix, y + _figure.GetUpperBound (1)+1] = 2;
		//int py = _figure.GetUpperBound(1);

		prev_x = x;
		prev_y = y;

	}

	public void RotateFigure() {

		_buffer = new int[_figure.GetUpperBound(1)+1, _figure.GetUpperBound(0)+1];
		for (int iy=0; iy<=_figure.GetUpperBound(1); iy++)
			for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) {
			_buffer[iy, _figure.GetUpperBound(0)-ix] = _figure[ix, iy];
			//ti = _figure.GetUpperBound(0)-ix;
			//Debug.Log("iy: "+iy.ToString()+"ix: "+ti.ToString());
			}
		_figure = _buffer;
		/*
		Debug.Log(_figure.Rank.ToString());
		Debug.Log(_figure.GetUpperBound(0).ToString());
		Debug.Log(_figure.GetUpperBound(1).ToString());
		Debug.Log(_buffer.Rank.ToString());
		Debug.Log(_buffer.GetUpperBound(0).ToString());
		Debug.Log(_buffer.GetUpperBound(1).ToString());
		*/
	}
}
