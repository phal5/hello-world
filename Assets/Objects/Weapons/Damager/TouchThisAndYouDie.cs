using UnityEngine;

public class TouchThisAndYouDie : MonoBehaviour
{
    [SerializeField] int _damage = 1;
    [SerializeField] GameObject _potato;
    [SerializeField] Potato _potatoComponent;
    [SerializeField] float _dissapearAfter = 3;

    float _timer = 0;

    private void Update()
    {
        if((_timer += Time.deltaTime) > _dissapearAfter)
        {
            _timer = 0;
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject == _potato)
        {
            _potatoComponent.Damage(_damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject == _potato)
        {
            _potatoComponent.Damage(_damage);
        }
    }
}
