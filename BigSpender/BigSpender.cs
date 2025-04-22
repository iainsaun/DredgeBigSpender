using UnityEngine;
using Winch.Core;

namespace BigSpender
{
	public class BigSpender : MonoBehaviour
	{
		public void Awake()
		{
			WinchCore.Log.Debug($"{nameof(BigSpender)} has loaded!");
		}
	}
}
