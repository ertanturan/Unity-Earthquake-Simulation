using System.IO;
using UnityEngine;

public abstract class ReadFromFile : MonoBehaviour
{

    protected abstract TextAsset TextAsset { get; set; }
    protected abstract string _Name { get; set; }
    protected abstract string _Directory { get; set; }

    public string Directory = "Data/Earthquake/Texts/";
    public string Name;

    public virtual void Awake()
    {
        _Directory = Directory;
    }

    
}
