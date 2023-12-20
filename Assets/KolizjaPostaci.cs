using UnityEngine;

public class KolizjaPostaci : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NazwaTaguObiektu"))
        {
            // Tutaj mo¿esz umieœciæ kod reakcji na kolizjê z danym obiektem
            //Debug.Log("Kolizja z obiektem o tagu: " + other.tag);

            // Przyk³ad: Zniszcz obiekt po kolizji
            Destroy(other.gameObject);
        }
    }
}