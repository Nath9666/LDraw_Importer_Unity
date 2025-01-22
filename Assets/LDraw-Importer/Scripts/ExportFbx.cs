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
        pieces = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (pieceId != null)
        {
            RemoveOtherPiecesWithId(pieceId.name, pieceId);
            ExportToFbx(pieceId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FindFirstPieceWithId(string pieceId)
    {
        foreach (GameObject piece in pieces)
        {
            if (piece.name == pieceId) // Assuming the piece ID is stored in the name
            {
                return piece;
            }
        }
        return null;
    }

    void RemoveOtherPiecesWithId(string pieceId, GameObject firstPiece)
    {
        for (int i = pieces.Count - 1; i >= 0; i--)
        {
            if (pieces[i].name == pieceId && pieces[i] != firstPiece)
            {
                Destroy(pieces[i]);
                pieces.RemoveAt(i);
            }
        }
    }

    void ExportToFbx(GameObject piece)
    {
        // Define the path where the FBX file will be saved
        string path = "Assets/Exports/" + piece.name + ".fbx";

        // Ensure the directory exists
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

        // Export the GameObject to an FBX file
        ModelExporter.ExportObject(path, piece);

        Debug.Log("Exported " + piece.name + " to " + path);
    }
}