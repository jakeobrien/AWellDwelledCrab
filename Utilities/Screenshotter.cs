using UnityEngine;
using System.IO;

/// <summary>
/// Screenshotter.
/// </summary>

public class Screenshotter : MonoBehaviour
{

	[Header("Resolutions")]
	public bool useMinimumResolution;
	public Vector2 minimumResolution;
	public KeyCode _screenshotKey = KeyCode.LeftShift;

	[Header("Autotake")]
	[SerializeField]
	private bool _takePhoto;

	public void Update()
	{
		if ((Input.GetKeyDown(_screenshotKey) || _takePhoto))
		{
			Screenshot();
			_takePhoto = false;
		}
	}

	public void Screenshot()
	{

		string filename = "";
		if (!Application.isEditor)
		{
			filename = Application.persistentDataPath + "/" + filename;
		}
		else
		{
			Directory.CreateDirectory(Application.dataPath + "/../Screenshots/");
			filename = "Screenshots/" + System.DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".png";
		}

		int ratio = 4;

		if (useMinimumResolution)
		{
			float horizRatio = minimumResolution.x / Screen.width;
			float vertRatio = minimumResolution.y / Screen.height;

			ratio = Mathf.CeilToInt(Mathf.Max(horizRatio, vertRatio));
		}

		ScreenCapture.CaptureScreenshot(filename, ratio);
		Debug.Log("Screenshot taken");
	}
}
