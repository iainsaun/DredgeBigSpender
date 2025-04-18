using UnityEngine;

namespace BigSpender
{
	public class Loader
	{
		/// <summary>
		/// This method is run by Winch to initialize your mod
		/// </summary>
		public static void Initialize()
		{
			var gameObject = new GameObject(nameof(BigSpender));
			gameObject.AddComponent<BigSpender>();
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}