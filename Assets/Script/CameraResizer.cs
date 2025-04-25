using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    public Camera mainCamera;
    public int mapWidth = 10;
    public int mapHeight = 8;
    public float tileSize = 1f;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = mapHeight * tileSize / 2f;
        float cameraWidth = mapWidth * tileSize / 2f / screenAspect;

        mainCamera.orthographicSize = Mathf.Max(cameraHeight, cameraWidth);

        // カメラ位置をマップ中央に合わせる
        float centerX = (mapWidth - 1) * tileSize / 2f;
        float centerY = (mapHeight - 1) * tileSize / 2f;
        mainCamera.transform.position = new Vector3(centerX, centerY, -10f);
    }
}
