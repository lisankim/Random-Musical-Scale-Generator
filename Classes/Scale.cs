using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RMSG.Classes
{
    public class Scale
    {
        public List<string> usedList = new List<string>();

        /// <summary>
        /// Represents all the different scales
        /// </summary>
        public List<string> Scales { get; set; } = new List<string>();

        public Scale()
        {
            Scales.Add("C Major: 0 Sharps, 0 Flats");
            Scales.Add("a minor: 0 Sharps, 0 Flats");
            Scales.Add("G Major: 1 Sharp, F#");
            Scales.Add("e minor: 1 Sharp, F#");
            Scales.Add("D Major: 2 Sharps, F#,C#");
            Scales.Add("b minor: 2 Sharps, F#, C#");
            Scales.Add("A Major: 3 Sharps, F#, C#, G#");
            Scales.Add("F# minor: 3 Sharps, F#, C#, G#");
            Scales.Add("E Major: 4 Sharps, F#, C#, G#, D#");
            Scales.Add("c# minor: 4 Sharps, F#, C#, G#, D#");
            Scales.Add("B Major: 5 Sharps, F#, C#, G#, D#, A#");
            Scales.Add("g# minor: 5 Sharps, F#, C#, G#, D#, A#");
            Scales.Add("F# Major: 6 Sharps, F#, C#, G#, D#, A# E#");
            Scales.Add("D# minor: 6 Sharps, F#, C#, G#, D#, A#, E#");
            Scales.Add("C# Major: 7 Sharps, F#, C#, G#, D#, A#, E#, B#");
            Scales.Add("a# minor: 7 Sharps, F#, C#, G#, D#, A#, E#, B#");
            Scales.Add("F Major: 1 flat, B-flat");
            Scales.Add("d minor: 1 Flat, B-flat");
            Scales.Add("B-Flat Major: 2 flats, B-flat, E-Flat");
            Scales.Add("g minor: 2 Flats, B-flats, E-Flat");
            Scales.Add("E-Flat Major: 3 Flats, B-flat, E-flat, A-flat");
            Scales.Add("c minor: 3 flat, B-flat, E-flat, A-flat");
            Scales.Add("A-Flat Major: 4 Flat, B-flat, E-flat, A-flat, D-flat");
            Scales.Add("f minor: 4 flats, B-flat, E-flat, A-flat, D-flat");
            Scales.Add("D-Flat Major: 5 flats, B-flat, E-flat, A-flat, D-flat G-flat");
            Scales.Add("b-flat minor: 5 flat, 5 flats, B-flat, E-flat, A-flat, D-flat G-flat");
            Scales.Add("G-flat Major: 6 flat,  6 flats, B-flat, E-flat, A-flat, D-flat G-flat, C-flat");
            Scales.Add("e-flat minor:  6 flats, B-flat, E-flat, A-flat, D-flat G-flat, C-flat");
            Scales.Add("C-Flat Major: 7 flats,B-flat, E-flat, A-flat, D-flat G-flat, C-flat, F-flat");
            Scales.Add("a-flat minor: 7 flats,B-flat, E-flat, A-flat, D-flat G-flat, C-flat, F-flat");
        }

        public void Shuffle()
        {
            //Taking the list
            //diving the list in half
            //numberofscale =Scales.count
            int numberOfScales = 30;
            List<string> firstHalf = Scales.GetRange(0, Scales.Count / 2);
            Scales.RemoveRange(0, numberOfScales / 2);
            List<string> secondHalf = Scales.GetRange(0, Scales.Count);
            Scales = new List<string>();

            //repeating until you don't have any more scales
            Random rando = new Random();
            while (firstHalf.Count > 0 && secondHalf.Count > 0)
            {
                //take random third of the list from the first half
                int numberOfScalesInTheFirstHalf = rando.Next(1, 5);
                if (numberOfScalesInTheFirstHalf > firstHalf.Count)
                {
                    numberOfScalesInTheFirstHalf = firstHalf.Count;
                }
                List<string> fromFirstHalf = firstHalf.GetRange(0, numberOfScalesInTheFirstHalf);
                firstHalf.RemoveRange(0, numberOfScalesInTheFirstHalf);
                Scales.AddRange(fromFirstHalf);

                //take random third of the list from the second half
                int numberOfScalesInTheSecondHalf = rando.Next(1, 5);
                if (numberOfScalesInTheSecondHalf > secondHalf.Count)
                {
                    numberOfScalesInTheSecondHalf = secondHalf.Count;
                }
                List<string> fromSecondHalf = secondHalf.GetRange(0, numberOfScalesInTheSecondHalf);
                secondHalf.RemoveRange(0, numberOfScalesInTheSecondHalf);
                Scales.AddRange(fromSecondHalf);
            }
        }
        public string GetRandomScale()
        {
            Random rando = new Random();
            int randomIndex = rando.Next(0, Scales.Count);
            if (usedList.Count == Scales.Count)
            {
                usedList.Clear();
            }
            while (usedList.Contains(Scales[randomIndex]))
            {
                randomIndex = rando.Next(0, Scales.Count);
            }
            usedList.Add(Scales[randomIndex]);
            return Scales[randomIndex];

        }
        // remove oldList from Scales[randomIndex];
        //possible new menu #4-show the list of scales that I've done. 




        public void ScaleLog(string sotd)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "scaleLog.txt";
            string fullPath = Path.Combine(directory, filename);

            using (StreamWriter sw = new StreamWriter(fullPath, false)) //false will never override, therefore 
                                                                        //keep track of all the scales you practice using the random scale generator
            {
                sw.WriteLine(sotd);
            }
        }

    }
}
