using UnityEngine;
using System.IO;


public class CardExport : MonoBehaviour
{
    [SerializeField]
    private Vector2Int Resolution;

    [SerializeField]
    private string ImageName;

    [SerializeField]
    private string ExportPath;

    [SerializeField]
    private Camera RenderCamera;

    public void RenderToTexture()
    {
        RenderTexture RenderTex = new RenderTexture(Resolution.x, Resolution.y, 24);
        Texture2D Screenshot = new Texture2D(Resolution.x, Resolution.y, TextureFormat.RGBA32, false);

        RenderCamera.targetTexture = RenderTex;
        RenderCamera.Render();
        RenderCamera.targetTexture = null;

        Rect rect = new Rect(0, 0, Resolution.x, Resolution.y);
        RenderTexture.active = RenderTex;
        Screenshot.ReadPixels(rect, 0, 0);
        RenderTexture.active = null;

        Color[] Pixels = Screenshot.GetPixels();

        Screenshot.SetPixels(Pixels);

        ExportAsPNG(Screenshot);

        Destroy(RenderTex);
        Destroy(Screenshot);
    }

    private void ExportAsPNG(Texture2D img)
    {
        System.Guid guid = System.Guid.NewGuid();
        byte[] bytes = img.EncodeToPNG();
        string pathAbs = Application.dataPath + "/" + ExportPath;
        string filename = guid.ToString() + "_" + ImageName + "_" + Resolution.x + "x" + Resolution.y + ".png";
        if (!Directory.Exists(pathAbs))
        {
            Directory.CreateDirectory(pathAbs);
            Debug.Log("Created Drectory at " + pathAbs);
        }
        File.WriteAllBytes(pathAbs + "/" + filename, bytes);
        Debug.Log("Saved " + filename + " at " + pathAbs);
    }
}