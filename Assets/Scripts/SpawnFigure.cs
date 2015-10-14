using UnityEngine;
using System.Collections;

public class SpawnFigure {

	private int[,] _figure;
	private int[,] _buffer;

	public SpawnFigure(int[,] _inarr) {
		_figure = _inarr;
	}

	public void DrawFigure(int[,] _destination, int _x, int _y) {
		for (int iy=0; iy<=_figure.GetUpperBound(0); iy++)
		for (int ix=0; ix<=_figure.GetUpperBound(1); ix++) {
			if (_figure[iy, ix] == 1) _destination[ix+_x, iy+_y] = 1;
		}
	}

	public void RotateFigure() {

		_buffer = new int[_figure.GetUpperBound(1)+1, _figure.GetUpperBound(0)+1];
		for (int iy=0; iy<=_figure.GetUpperBound(0); iy++)
			for (int ix=0; ix<=_figure.GetUpperBound(1); ix++) {
			_buffer[ix, iy] = _figure[iy, ix];
			}
		_figure = _buffer;
		Debug.Log(_figure.Rank.ToString());
		Debug.Log(_figure.GetUpperBound(0).ToString());
		Debug.Log(_figure.GetUpperBound(1).ToString());
		Debug.Log(_buffer.Rank.ToString());
		Debug.Log(_buffer.GetUpperBound(0).ToString());
		Debug.Log(_buffer.GetUpperBound(1).ToString());

	}
}
