using UnityEngine;
using Winch.Core;
/// <summary>
/// This is the place to write the code, also, my first comment.
/// </summary>
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
