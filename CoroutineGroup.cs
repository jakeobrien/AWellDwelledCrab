using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CoroutineGroup : IEnumerator 
{

	private List<IEnumerator> _coroutines;
	private IEnumerator _currentCoroutine;

	public CoroutineGroup(params IEnumerator[] args)
	{
		_coroutines = args.ToList();
	}

	public bool MoveNext()
	{
		for (int i = _coroutines.Count - 1; i >= 0; i--)
		{
			_currentCoroutine = _coroutines[i];
			if (!_currentCoroutine.MoveNext())
			{
				 _coroutines.RemoveAt(i);
			}
		}
		return _coroutines.Any();
	}

	public object Current { get { return null; } }

	public void Reset() {}

}
