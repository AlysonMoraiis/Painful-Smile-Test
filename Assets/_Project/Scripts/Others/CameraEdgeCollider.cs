using UnityEngine;
using UnityEngine.Serialization;

public class CameraEdgeCollider : MonoBehaviour
{
    [FormerlySerializedAs("cam")] [SerializeField]
    private Camera _camera;

    private float _sizeX, _sizeY, _ratio;

    void Start()
    {
        var bottomLeft = (Vector2)_camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        var topLeft = (Vector2)_camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight, _camera.nearClipPlane));
        var topRight =
            (Vector2)_camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight,
                _camera.nearClipPlane));
        var bottomRight =
            (Vector2)_camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0, _camera.nearClipPlane));

        // add or use existing EdgeCollider2D
        var edge = GetComponent<EdgeCollider2D>() == null
            ? gameObject.AddComponent<EdgeCollider2D>()
            : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edge.points = edgePoints;
    }
}
