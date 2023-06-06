using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public Image image;

    public GameObject[] categories;

    public void FillContent(string folder)
    {
        foreach (var category in categories)
        {
            category.SetActive(false);

            if (category.name.Equals(folder))
            {
                category.SetActive(true);
            }
        }

        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }

        string path = Application.dataPath;
        path += "/Resources/Sprites/Items/";
        path += folder;

        //string path = "Sprites/Items/";
        //path += folder;

        //Object[] textures = Resources.LoadAll(path, typeof(Texture2D));

        //foreach (var texture in textures)
        //{
        //    GameObject obj = Instantiate(prefab, parent.transform);
        //    Image image = obj.GetComponentInChildren<Image>();
        //    image.sprite = LoadNewSprite(texture as Texture2D);
        //    Button button = obj.GetComponent<Button>();
        //    button.onClick.AddListener(() => SwapImage(button.gameObject));
        //}

        foreach (var file in System.IO.Directory.GetFiles(path))
        {
            if (file.EndsWith(".meta"))
            {
                continue;
            }

            GameObject obj = Instantiate(prefab, parent.transform);
            Image image = obj.GetComponentInChildren<Image>();
            image.sprite = LoadNewSprite(LoadTexture(file));
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => SwapImage(button.gameObject));
        }
    }

    public void SwapImage(GameObject obj)
    {
        image.sprite = obj.GetComponentInChildren<Image>().sprite;
    }

    public Sprite LoadNewSprite(Texture2D texture, float PixelsPerUnit = 100.0f)
    {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Sprite NewSprite;
        Texture2D SpriteTexture = texture;
        SpriteTexture.filterMode = FilterMode.Point;
        SpriteTexture.wrapMode = TextureWrapMode.Clamp;
        NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
        return NewSprite;
    }

    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }
}
