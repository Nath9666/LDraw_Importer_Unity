using UnityEditor;
using UnityEditor.Formats.Fbx.Exporter;
using UnityEngine;
using System.Collections.Generic;

public class ExportFbx : MonoBehaviour
{
    public GameObject pieceId;
    public List<GameObject> pieces;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pieceId != null)
        {
            ExportToFbx(pieceId);
        }
    }

    void ExportToFbx(GameObject piece)
    {
        // Define the path where the FBX file will be saved
        string path = "Assets/Exports/" + piece.name + ".fbx";
    
        // Ensure the directory exists
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
    
        // Create export options
        var exportOptions = new ExportModelSettings();
        exportOptions.ModelFormat = ModelSettings.ModelFormat.Fbx;
        exportOptions.FbxExportFormat = ExportSettings.ExportFormat.Binary;
    
        // Export the GameObject to an FBX file
        ModelExporter.ExportObject(path, piece, exportOptions);
    
        Debug.Log("Exported " + piece.name + " to " + path);
    }
}