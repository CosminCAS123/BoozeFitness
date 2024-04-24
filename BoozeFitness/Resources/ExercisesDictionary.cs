using Avalonia.Controls.Platform;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Resources
{
    public static class ExercisesDictionary
    {
     
        public enum MuscleGroup
        {
            Biceps,
            Forearms,
            Legs,
            Abs,
            Back,
            Shoulders,
            Chest,
            Triceps
        }
        public static Dictionary<string, string>? GetExerciseInfo { get; private set; }

        static ExercisesDictionary() => LoadInfo();
        
        public static class Biceps 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>(){DumbbellCurl , HammerCurl , PreacherCurl};
            }
            public static string DumbbellCurl = "Dumbbell Curl";

            public static string HammerCurl = "Hammer Curl";
            public static string PreacherCurl = "Preacher Curl";

        }
        public static class Forearms 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() { WristCurl , ReverseWristCurl , Pronation};
            }
            public static string WristCurl = "Wrist Curl";
            public static string ReverseWristCurl = "Reverse Wrist Curl";
            public static string Pronation = "Pronation";
         }
        public static class Legs
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() { BarbellSquat , RomanianDeadlift , CalfRaises};
            }
            public static string BarbellSquat =  "Barbell Squat";
            public static string RomanianDeadlift =  "Romanian Deadlift";
            public static string CalfRaises = "Calf Raises";
        }
        public static class Abs 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() { Crunches , LegRaises , RussianTwist};
            }
            public static string Crunches = "Crunches";
            public static string LegRaises = "Leg Raises";
            public static string RussianTwist = "Russian Twist";
        }
        public static class Back 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() {PullUps , ChinUps , Deadlift}; 
            }
            public static string PullUps = "Pull-Ups";
            public static string ChinUps = "Chin-Ups";
            public static string Deadlift = "Deadlift";
        }
        public static class Shoulders 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() {LateralRaises , MilitaryPress, FacePulls};
            }
            public static string LateralRaises =  "Lateral Raises";
            public static string MilitaryPress = "Military Press";
            public static string FacePulls = "Face Pulls";
        }
        public static class Chest 
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() { BenchPress , ChestFlies , InclinePress};
            }
            public static string BenchPress = "Bench Press";
            public static string ChestFlies = "Dumbbell Chest Fly";
            public static string InclinePress = "Incline Bench Press";

        }
        public static class Triceps
        {
            public static IEnumerable<string> GetAllExercises()
            {
                return new List<string>() { RopeExtension , SkullCrushers , CloseGripBench};
            }
            public static string RopeExtension = "Rope Pull-Down";
            public static string SkullCrushers = "Skull-Crushers";
            public static string CloseGripBench = "Close Grip Bench Press";
        }

      
        public static IEnumerable<string> GetAllExercises(MuscleGroup group)
        {
            switch (group)
            {
                case MuscleGroup.Biceps:
                    return Biceps.GetAllExercises();
                case MuscleGroup.Abs:
                    return Abs.GetAllExercises();

                case MuscleGroup.Forearms:
                    return Forearms.GetAllExercises();
                case MuscleGroup.Legs:
                    return Legs.GetAllExercises();
                case MuscleGroup.Shoulders:
                    return Shoulders.GetAllExercises();

                case MuscleGroup.Chest:
                    return Chest.GetAllExercises();
                case MuscleGroup.Triceps:
                    return Triceps.GetAllExercises();

                case MuscleGroup.Back:
                    return Back.GetAllExercises();
            }
            throw new ArgumentException();
        }
       
       
        private static void LoadInfo()
        {
            GetExerciseInfo = new Dictionary<string, string>();

            GetExerciseInfo[Biceps.HammerCurl] = "Hammer curls are a biceps exercise performed with a neutral grip, targeting the brachialis and brachioradialis muscles in addition to the biceps.";

            GetExerciseInfo[Biceps.DumbbellCurl] = "Dumbbell curls are a classic biceps exercise performed with dumbbells, focusing on isolating and strengthening the biceps muscles.";

            GetExerciseInfo[Biceps.PreacherCurl] = "Preacher curls are performed on a preacher bench, isolating the biceps by minimizing momentum and focusing on controlled movements.";

            GetExerciseInfo[Triceps.RopeExtension] = "Rope triceps extensions are a triceps isolation exercise performed with a rope attachment on a cable machine, targeting the triceps muscles.";

            GetExerciseInfo[Triceps.CloseGripBench] = "Close-grip bench press is a compound exercise primarily targeting the triceps, performed with a narrower grip than traditional bench press.";

            GetExerciseInfo[Triceps.SkullCrushers] = "Skull crushers, also known as lying triceps extensions, target the triceps muscles by extending the arms overhead while lying on a bench.";

            GetExerciseInfo[Shoulders.MilitaryPress] = "Military press, also known as overhead press, is a compound exercise targeting the shoulder muscles, performed by pressing a weight overhead from shoulder level.";

            GetExerciseInfo[Shoulders.LateralRaises] = "Lateral raises target the side deltoids, helping to build broader shoulders. This exercise involves lifting dumbbells or other weights out to the sides until the arms are parallel to the ground.";

            GetExerciseInfo[Shoulders.FacePulls] = "Face pulls are a shoulder exercise performed with a cable machine, targeting the rear deltoids and upper back muscles by pulling the rope attachment towards the face.";

            GetExerciseInfo[Legs.RomanianDeadlift] = "Romanian deadlifts primarily target the hamstrings and glutes, involving a hip hinge movement with a slight knee bend and maintaining tension on the hamstrings throughout.";

            GetExerciseInfo[Legs.CalfRaises] = "Calf raises are an isolation exercise for the calf muscles, involving raising the heels off the ground while standing to target the gastrocnemius and soleus muscles.";

            GetExerciseInfo[Legs.BarbellSquat] = "Barbell squats are a compound exercise targeting the quadriceps, hamstrings, glutes, and lower back. It involves squatting down with a barbell on the upper back.";

            GetExerciseInfo[Back.ChinUps] = "Chin-ups are a bodyweight exercise targeting the back and biceps, performed by pulling the body upward until the chin clears the bar.";

            GetExerciseInfo[Back.PullUps] = "Pull-ups are a bodyweight exercise targeting the back and biceps, performed by pulling the body upward until the chest reaches the bar.";

            GetExerciseInfo[Back.Deadlift] = "Deadlifts are a compound exercise targeting multiple muscle groups including the back, glutes, hamstrings, and core, involving lifting a barbell from the ground to hip level.";

            GetExerciseInfo[Abs.LegRaises] = "Leg raises target the lower abdominal muscles, involving lifting the legs while lying on the back to create a 'V' shape with the body.";

            GetExerciseInfo[Abs.RussianTwist] = "Russian twists are an abdominal exercise performed by rotating the torso from side to side while holding a weight or medicine ball, targeting the obliques and core muscles.";

            GetExerciseInfo[Abs.Crunches] = "Crunches are a classic abdominal exercise involving flexing the spine to lift the shoulders off the ground, targeting the rectus abdominis muscle.";

            GetExerciseInfo[Forearms.WristCurl] = "Wrist curls target the forearm flexors, involving curling the wrist to lift a weight, such as a dumbbell or barbell.";

            GetExerciseInfo[Forearms.ReverseWristCurl] = "Reverse wrist curls target the forearm extensors, involving extending the wrist against resistance to strengthen the muscles on the back of the forearm.";

            GetExerciseInfo[Forearms.Pronation] = "Pronation exercises target the muscles responsible for rotating the forearm, such as the pronator teres and pronator quadratus, often performed with a resistance band or dumbbell.";

            GetExerciseInfo[Chest.InclinePress] = "Incline bench press is a variation of the bench press performed on an inclined bench, targeting the upper chest muscles (pectoralis major) and anterior deltoids.";

            GetExerciseInfo[Chest.BenchPress] = "Bench press is a compound exercise targeting the chest, shoulders, and triceps, involving pressing a barbell away from the chest while lying on a flat bench.";

            GetExerciseInfo[Chest.ChestFlies] = "Chest flies target the chest muscles, involving bringing the arms together in a fly motion while holding weights, such as dumbbells or cables.";
        }

    }
}
