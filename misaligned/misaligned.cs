using System;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        static int printColorMap() {
            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            int i = 0, j = 0;
            for(i = 0; i < 5; i++) {
                for(j = 0; j < 5; j++) {
                    Console.WriteLine("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]);    //minorColors[i] instead of minorColors[j].
                }
            }
            return i * j;    // Returns 25, but we are asserting 24 to make the test fail
        }
        static void Main(string[] args) {
            int result = printColorMap();
            Debug.Assert(result == 24); //expected result is 25
            Console.WriteLine("All is well (maybe!)");
        }
    }
}
