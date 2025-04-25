using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 追従するオブジェクト（プレイヤーなど）
    public float tileSize = 1f;

    private float camHeight;
    private float camWidth;
    private int mapWidth;
    private int mapHeight;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void SetBounds(int width, int height)
    {
        mapWidth = width;
        mapHeight = height;

        float aspect = (float)Screen.width / Screen.height;

        // 表示領域計算
        camHeight = Mathf.Max(height * tileSize / 2f, width * tileSize / 2f / aspect);
        cam.orthographicSize = 5;

        camWidth = camHeight * aspect;

        // 初期位置はマップ中央
        transform.position = new Vector3(
            (mapWidth - 1) * tileSize / 2f,
            (mapHeight - 1) * tileSize / 2f,
            -10f
        );
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void LateUpdate()
    {
        if (target == null || mapWidth == 0 || mapHeight == 0) return;

        Vector3 targetPos = target.position;

        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = camHalfHeight * cam.aspect;

        // マップ全体のサイズ
        float mapWidthWorld = mapWidth * tileSize;
        float mapHeightWorld = mapHeight * tileSize;

        // 最小・最大制限（絶対座標）
        float minX = camHalfWidth - (mapWidthWorld * 0.5f);
        float maxX = (mapWidthWorld * 0.5f) - camHalfWidth;
        float minY = camHalfHeight - (mapHeightWorld * 0.5f);
        float maxY = (mapHeightWorld * 0.5f) - camHalfHeight;

        // カメラ制限ロジック（lock 判定）
        bool lockX = (mapWidthWorld < camHalfWidth * 2f);
        bool lockY = (mapHeightWorld < camHalfHeight * 2f);

        // マップ中央
        float mapCenterX = 0;
        float mapCenterY = 0;

        // 最終座標
        float x = lockX ? mapCenterX : Mathf.Clamp(targetPos.x, minX, maxX);
        float y = lockY ? mapCenterY : Mathf.Clamp(targetPos.y, minY, maxY);


        transform.position = new Vector3(x, y, -10f);
        Vector3 pos = new Vector3(targetPos.x, minX, maxX);
    }

}
