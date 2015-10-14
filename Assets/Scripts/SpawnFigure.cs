using UnityEngine;
using System.Collections;

public class SpawnFigure {

	private int[,] _figure;
	private int[,] _buffer;

	public int x = 4;
	public int y = 0;

	public SpawnFigure(int[,] _inarr) {
		_figure = _inarr;
	}

	public void DrawFigure(int[,] _destination) {

		if ((x+_figure.GetUpperBound(0)) > (_destination.GetUpperBound(0))) x = _destination.GetUpperBound(0)-_figure.GetUpperBound(0); 
		if (x < 0) x = 0; 

		for (int iy=0; iy<=_figure.GetUpperBound(1); iy++)
		for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) {
			if (_figure[ix, iy] == 1) _destination[ix+x, iy+y] = 1;
		}
	}

	public void RotateFigure() {

		_buffer = new int[_figure.GetUpperBound(1)+1, _figure.GetUpperBound(0)+1];
		int ti;
		for (int iy=0; iy<=_figure.GetUpperBound(1); iy++)
			for (int ix=0; ix<=_figure.GetUpperBound(0); ix++) {
			_buffer[iy, _figure.GetUpperBound(0)-ix] = _figure[ix, iy];
			ti = _figure.GetUpperBound(0)-ix;
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
