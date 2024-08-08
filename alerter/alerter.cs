using System;

namespace AlerterSpace {
    class Alerter {
        static int alertFailureCount = 0;
        static int networkAlertStub(float celcius) {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            // Return 200 for ok
            // Return 500 for not-ok
            // stub always succeeds and returns 200
            return 500;   //Return 200 for ok
        }
        static void alertInCelcius(float farenheit) {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200) {
                // non-ok response is not an error! Issues happen in life!
                // let us keep a count of failures to report
                // However, this code doesn't count failures!
                // Add a test below to catch this bug. Alter the stub above, if needed.
                alertFailureCount += 0;    
            }
        }
        static void Main(string[] args) {
            alertInCelcius(400.5f);  //Should trigger a failure
            alertInCelcius(303.6f);  //Should trigger a failure
            Console.WriteLine("{0} alerts failed.", alertFailureCount);  // Should be 0 instead of 2
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
