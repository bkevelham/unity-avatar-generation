using UnityEngine;

namespace BKUnity
{
	public class HumanoidAvatarBuilder : MonoBehaviour
	{
		private Animator _Animator;

		public void Awake()
		{
			_Animator = GetComponent<Animator>();
			HumanDescription description = AvatarUtils.CreateHumanDescription(gameObject);
			Avatar avatar = AvatarBuilder.BuildHumanAvatar(gameObject, description);
			avatar.name = gameObject.name;
			_Animator.avatar = avatar;
		}
	}
}