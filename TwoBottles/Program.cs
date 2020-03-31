using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoBottles
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Problem:
            // Pour from bottles of two different sizes in order
            // to measure specific amount of water
            // Bottles are 3 and 5 litres, 
            // measure shortest way to measure x litre(s).
            // Two possible directions for pouring -->
            // 1) To small bottle
            // 2) To big bottle
            // Stop when any bottle contains the sought amount of water
            var smallBottle = 3;
            var bigBottle = 5;
            Console.WriteLine("Hur många liter vill du mäta upp?" + System.Environment.NewLine + "Avsluta med '-1'");
            var soughtLitres = 0;
            soughtLitres = Int32.Parse(Console.ReadLine());
            while (soughtLitres != -1)
            {
                while (soughtLitres < 0)
                {
                    Console.WriteLine("Du kan ej ange ett negativt tal.");
                    try
                    {
                        soughtLitres = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(160);
                    }
                }

                // Pour from both directions
                // Return smallest value
                try
                {
                    var fromSmallToBigBottleMoves = Pour(smallBottle, bigBottle, soughtLitres);
                    var fromBigToSmallBottleMoves = Pour(bigBottle, smallBottle, soughtLitres);
                    var moves = new List<int> { fromSmallToBigBottleMoves, fromBigToSmallBottleMoves };

                    Console.WriteLine("Kortast antal steg: " + moves.Min());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                Console.WriteLine();
                Console.WriteLine("Prova gärna igen:");
                soughtLitres = Int32.Parse(Console.ReadLine());
            }
        }

        public static int Pour(int startBottle, int destinationBottle, int soughtLitres)
        {
            var waterCombinations = new HashSet<Tuple<int, int>>();
            var moves = 0;
            var waterInBottle1 = 0;
            var waterInBottle2 = 0;
            Console.WriteLine("Häll från " + startBottle + "-litersflaskan till " + destinationBottle + "-litersflaskan:");

            // Loop as long as we have no solution
            while (waterInBottle1 != soughtLitres && waterInBottle2 != soughtLitres)
            {
                if (waterInBottle1 == 0)
                {
                    waterInBottle1 = startBottle;
                    moves++;
                    WriteStep(moves, waterInBottle1, waterInBottle2);
                }
                AddWaterCombination(waterInBottle1, waterInBottle2, waterCombinations);
                if (DoIHaveTheAmountOfWater(waterInBottle1, waterInBottle2, soughtLitres)) { break; }
                else
                {
                    // If the sum of the water in both bottles contain more than
                    // what second bottle can contain, only pour the amount it can hold
                    // and remove that amount from the first bottle
                    if (waterInBottle1 + waterInBottle2 > destinationBottle)
                    {
                        waterInBottle1 = waterInBottle1 - (destinationBottle - waterInBottle2);
                        waterInBottle2 = destinationBottle;
                        moves++;
                        WriteStep(moves, waterInBottle1, waterInBottle2);
                    }
                    // Else empty the water in the first bottle into the second bottle
                    else
                    {
                        waterInBottle2 = waterInBottle1 + waterInBottle2;
                        waterInBottle1 = 0;
                        moves++;
                        WriteStep(moves, waterInBottle1, waterInBottle2);
                    }
                    AddWaterCombination(waterInBottle1, waterInBottle2, waterCombinations);
                    if (DoIHaveTheAmountOfWater(waterInBottle1, waterInBottle2, soughtLitres)) { break; }
                    else
                    {
                        // Empty second bottle if first bottle is not empty
                        // Otherwise the loop will go back to start and we pour
                        // the water from first bottle to second bottle
                        if (waterInBottle1 != 0)
                        {
                            waterInBottle2 = 0;
                            moves++;
                            WriteStep(moves, waterInBottle1, waterInBottle2);
                        }
                    }
                }
            }
            Console.WriteLine("-------------");
            return moves;
        }

        /// <summary>
        /// Add combination of water in bottles,
        /// if we have seen the combination before we throw exception
        /// </summary>
        /// <param name="waterInBottle1"></param>
        /// <param name="waterInBottle2"></param>
        /// <param name="waterCombinations"></param>
        private static void AddWaterCombination(int waterInBottle1, int waterInBottle2, HashSet<Tuple<int, int>> waterCombinations)
        {
            if (waterCombinations.Contains(Tuple.Create(waterInBottle1, waterInBottle2)))
            {
                throw new Exception("Loop funnen, inga möjliga lösningar finns.");
            }
            else
            {
                waterCombinations.Add(Tuple.Create(waterInBottle1, waterInBottle2));
            }
        }

        /// <summary>
        /// Check if any water bottle contain
        /// the desired amount of water
        /// </summary>
        /// <param name="waterInBottle1"></param>
        /// <param name="waterInBottle2"></param>
        /// <param name="soughtLitres"></param>
        /// <returns></returns>
        private static bool DoIHaveTheAmountOfWater(int waterInBottle1, int waterInBottle2, int soughtLitres)
        {
            if (waterInBottle1 == soughtLitres ||
                waterInBottle2 == soughtLitres)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Write the step to console
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="waterInBottle1"></param>
        /// <param name="waterInBottle2"></param>
        private static void WriteStep(int moves, int waterInBottle1, int waterInBottle2)
        {
            Console.WriteLine("Steg " + moves + " (" + waterInBottle1 + "," + waterInBottle2 + ")");
        }
    }
}
