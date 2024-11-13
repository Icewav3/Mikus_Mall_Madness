using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class LimitCameraColors : MonoBehaviour
{
	[SerializeField]
	private Texture2D _paletteImage;

	private List<Color> _colors = new List<Color>();
	private Material _material;
	private Shader _shader;

	protected Material material
	{
		get
		{
			if(_material == null)
			{
				_shader = Shader.Find("Oxysoft/RetroPixelMax");
				_material = new Material(_shader) { hideFlags = HideFlags.DontSave };
			}

			return _material;
		}
	}

	private void Awake()
	{
		Color[] pixels = _paletteImage.GetPixels();
		_colors = new HashSet<Color>(pixels).ToList();
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if(material && _colors.Count > 0)
		{
			material.SetInt("_ColorCount", _colors.Count);
			material.SetColorArray("_Colors", _colors);

			Graphics.Blit(source, destination, material);
		}
		else
		{

			Graphics.Blit(source, destination);

		}
	}

	private void OnDisable()
	{
		if(_material)
		{
			DestroyImmediate(_material);
		}
	}
}
