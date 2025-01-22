using System.Collections;
using System.Collections.Generic;
using LDraw; // Assurez-vous que ce namespace est correct
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    [SerializeField] private Vector3 _OriginPlaneNormalDirection;
    [SerializeField] private string _pieceName;
    [SerializeField] private string _piecePath;
    [SerializeField] private Material _pieceMaterial;

    void Start()
    {
        ImportPiece();
    }

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var trs = transform.ExtractLocalTRS();
            var reflected = trs.HouseholderReflection(_OriginPlaneNormalDirection);
            transform.ApplyLocalTRS(reflected);
        }
    }

    private void ImportPiece()
    {
        var ldrawModel = LDrawModel.Create(_pieceName, _piecePath);
        if (ldrawModel != null)
        {
            GameObject piece = ldrawModel.CreateMeshGameObject(Matrix4x4.identity, _pieceMaterial, transform);
            if (piece != null)
            {
                piece.transform.position = Vector3.zero; // Positionne l'objet à l'origine de la scène
                piece.transform.rotation = Quaternion.identity; // Réinitialise la rotation de l'objet
                Debug.Log("Piece imported successfully");
                Debug.Log("Piece name: " + ldrawModel.Name);
            }
            else
            {
                Debug.LogError("Failed to create the mesh GameObject");
            }
        }
        else
        {
            Debug.LogError("Piece not imported");
        }
    }
}