# Unity Humanoid Avatar Generation

Requirements

- Unity 2020.1.17f1 (Version used, but will likely work with many newer and older versions)

## Introduction

This repository contains a compact example demonstrating how to generate a Humanoid Avatar at runtime using the [AvatarBuilder.BuildHumanAvatar API](https://docs.unity3d.com/ScriptReference/AvatarBuilder.BuildHumanAvatar.html). The generated avatar can be supplied to an Animator component, which can then drive the avatar's animation using an AnimatorController. 

Open the SampleScene scene which contains the default Mixamo avatar. It has been set up with an AnimationController supplied to the Animator. Note however that the Avatar property has been left empty. When hitting play, the attached `HumanoidAvatarBuilder` component will take care of creating the Avatar. 

![](Doc/sampleavatarinspector.png)

## Some remarks

The sample was created because Unity's documentation contains very little information on how to use their API, nor does it supply a sample to the best of my knowledge. On various sites users have expressed that they are unable to use the API, or that it gives them non-functional results. 

### Invalid AABB errors

Some users report errors such as the following when applying an animation to their generated Avatar:

```
Invalid AABBa
IsFinite(outDistanceForSort)
IsFinite(outDistanceAlongView)
Invalid AABB aabb
Invalid AABB rkBox
```

This same issue may show itself by NaN values appearing in the positions of various transforms. 

This issue appears in Unity's own issue tracker as well: [AVATARBUILDER.BUILDHUMANAVATAR SETS NAN POSITIONS WITH SOME AVATARS](https://issuetracker.unity3d.com/issues/avatarbuilder-dot-buildhumanavatar-sets-nan-positions-with-some-avatars)

From what I have been able to tell this is due to an incorrect object name being supplied in the HumanDescription's HumanBone or SkeletonBone arrays. This in particular seems to happen when trying to generate an Avatar based on a (modified) HumanDescription retrieved from an existing Avatar. While object names may appear correct, an incorrect name in SkeletonBone's private member `parentName` may still cause issues. So build your HumanDescription from scratch. 

### Resizing avatars

Most people who I have seen trying to use this API, seem to want to do so to create avatars with different skeleton proportions. While this repository does not demonstrate that functionality, the principle is the same. 

The avatar in the SampleScene scene is standing in a T-Pose. This T-Pose is stored in the Avatar's skeleton definition via the `SkeletonBone` array. This implies that you can change bone lengths by modifying the local positions of the bone/joint transforms to lengthen or shorten bones. Do this **before creating the HumanDescription**. 

Note that it is not sufficient to just modify the bone length when modifying the legs. Make sure that any changes to the lengths of leg bones are reflected in the position of the hip bone. That is, move it up or down to ensure the avatar's feet are planted on the ground in their T-Pose. If not, your animation will either have feet hover above the floor, or see the avatar bend its knees to accomodate for an incorrectly placed hip joint. 

### Hardcoded definition

The repository contains a Mixamo avatar, and the code in `AvatarUtils.cs` contains a static dictionary mapping its bone/joint names to names Unity understands for Humanoid Avatars. If you use different software to create your skinned and rigged avatars, you will need to adapt this definition or generate the mapping at runtime. The hardcoded dictionary purely exists to explicitly show which GameObject in the Avatar's hierarchy gets mapped to which of Unity's Humanoid Avatar joints. 
