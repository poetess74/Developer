using System;
using System.Collections;
using UnityEngine;

public static class Utility {
     public static IEnumerator animPlayOneShot(Animator source, string clipName, string stateName, string valueName, float animIndex, bool reset) {
         int index = int.MinValue;
         var clips = source.runtimeAnimatorController.animationClips;

         for(int i = 0; i < clips.Length; i++) {
             if(clips[i].name == clipName) {
                 index = i;
                 break;
             }
         }

         if(index == int.MinValue) {
             for(int i = 0; i < clips.Length; i++) {
                 Debug.LogFormat("index: {0}, name: {1}", i, clips[i].name);
             }
             
             source.SetBool(stateName, false);
             throw new NullReferenceException(
                 "AnimationClip " + clipName + "(" + stateName + ")" + " does not match in Animator attached clips. Please check parameter again."
             );
         }

         source.SetFloat(valueName, animIndex);
         source.SetBool(stateName, true);
         Debug.LogFormat("animPlayOneShot: Changed Animator parameters - {0}: {1}, {2}: {3}", valueName, source.GetFloat(valueName), stateName, source.GetBool(stateName));
         Debug.LogFormat("animPlayOneShot: Selected \"{0}\" AnimationClip(index: {1}/{2}), Clip duration: {3}", clips[index].name, index, clips.Length - 1, clips[index].length);
         yield return new WaitForSeconds(clips[index].length);
         if(!reset) yield break;
         source.SetBool(stateName, false);
         source.SetFloat(valueName, 0f);
         Debug.LogFormat("animPlayOneShot: Changed Animator parameters - {0}: {1}, {2}: {3}", valueName, source.GetFloat(valueName), stateName, source.GetBool(stateName));
     }

     public static float remainResourceProcess(float maxValue, float cntValue, float addPoint) {
         return (cntValue + addPoint > maxValue) ? maxValue - cntValue : addPoint;
     }
     
     public static bool resourceResource(float cntValue, float subPoint) {
         return (cntValue - subPoint >= 0);
     }
}
