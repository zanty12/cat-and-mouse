using UnityEngine;

public class CatWhite : MonoBehaviour, IBlocker
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�ˁ[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[�[��");
        }

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.moveLimit--;
            Debug.Log("moveLimit ���炵����I���̎c��: " + player.moveLimit);
        }
    }

    public void OnBlocked(PlayerController player)
    {
        if (player != null)
        {
            player.moveLimit--;
            player.moveLimit--;
            Debug.Log("moveLimit ���炵����I���̎c��: " + player.moveLimit);
        }
    }
}
