using System;

namespace AlerterSpace {
    class Alerter {
        static int alertFailureCount = 0;
         static Func<float, int> networkAlert = (celcius) => {
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            return 200; 
        }
         public static void SetNetworkAlertFunction(Func<float, int> alertFunction) {
            networkAlert = alertFunction;
        }
        static void alertInCelcius(float farenheit) {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkAlert(celcius);
            if (returnCode != 200) {
                alertFailureCount += 1;
            }
        }
        static void Main(string[] args) {
            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Debug.Assert(alertFailureCount == 2); 
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
