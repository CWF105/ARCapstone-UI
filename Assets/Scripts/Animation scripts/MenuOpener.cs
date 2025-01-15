using UnityEngine;

public class MenuOpener : MonoBehaviour {
    public GameObject panel;

    public void OpenPanel() {
        Animator animator = panel.GetComponent<Animator>();
        if(animator != null) {
            bool isOpen = animator.GetBool("open");
            animator.SetBool("Open", !isOpen);
        }
    }
}