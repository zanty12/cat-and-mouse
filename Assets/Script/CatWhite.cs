using UnityEngine;

public enum ARM_DIRECTION
{
    LEFT = 0,
    RIGHT,
    UP,
    DOWN
}

public class CatWhite : MonoBehaviour, IBlocker
{
    public GameObject catArm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ねーーーーーーーーーーーーーーーーーーーこ");
        }

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.moveLimit--;
            Debug.Log("moveLimit 減らしたよ！今の残り: " + player.moveLimit);
        }
    }

    public void OnBlocked(PlayerController player)
    {
        if (player != null)
        {
            player.moveLimit--;
            player.moveLimit--;
            Debug.Log("moveLimit 減らしたよ！今の残り: " + player.moveLimit);
        }
    }


    //手の長さと方向を設定する関数
    public void SetArm(int armLen, int armDir)
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        switch (armDir)
        {
            case 0: //左向きの手
                //右方向に指定マス分腕を伸ばす
                for (int i = 1; i <= armLen; i++)
                {
                    Instantiate(catArm, new Vector3(position.x + 1f * i, position.y, 0), Quaternion.identity, transform);
                }
                break;

            case 1: //右向きの手
                break;

            case 2: //上向きの手
                break;

            case 3: //下向きの手
                //上方向に指定マス分腕を伸ばす
                for (int i = 1; i <= armLen; i++)
                {
                    Instantiate(catArm, new Vector3(position.x, position.y + 1f * i, 0), Quaternion.identity, transform);
                }

                break;
        }
    }


    //噛みつかれた時の挙動関数
    public void Damage()
    {
        
    }
}
