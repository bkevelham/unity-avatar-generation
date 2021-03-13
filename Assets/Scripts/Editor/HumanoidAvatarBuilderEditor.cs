using UnityEditor;

namespace BKUnity
{
	[CustomEditor(typeof(HumanoidAvatarBuilder))]
	public class HumanoidAvatarBuilderEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox(
				"Note that the Animator above has an AnimatorController assigned, but does not have a Humanoid Avatar. " +
				"The Avatar is what we're going to create at runtime using this component. It will make use of the AvatarBuilder.BuildHumanAvatar API.\n\n" +
				"Using a utility function defined in AvatarUtils.cs, a HumanDescription will be created. This description contains information " +
				"on which bones can be found in the skeleton, and which transforms in the model map to which bones in Unity's Humanoid Avatar definition.\n\n" +
				"Note that this assumes that the model is standing in a T-Pose. If this is not the case, T-Pose information will need to be obtained by " +
				"other means and supplied in the CreateSkeleton function in AvatarUtils.cs.\n\n" +
				"While not demonstrated in this sample, this setup also allows you to generate an avatar with modified bone sizes. Simply adjust the joints " +
				"of the avatar in T-Pose to have longer limbs by modifying their local positions before calling CreateHumanDescription. " +
				"If you do so, make sure to adjust the position of the hips to account for increased or decreased leg length. That is, make sure the model " +
				"in T-Pose has their feet planted on the ground. If not this may result in Mecanim animation artefacts where feet will hover above the floor " +
				"or the knees will bend due to the hip being too close to the feet.", 
				MessageType.Info);

			DrawDefaultInspector();
		}
	}
}
