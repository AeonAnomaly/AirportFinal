

namespace Airport
{
    class Airport                                                           // The Airport Class
    {
        public string name;                                                 // Each Airport needs a name
        public int mileageTo;                                               // Each Airport needs a mileage to translate into flight time

        public Airport (string nameOfAirport, int mileageToAirport)         // This allows us to create a new airport object in a different class, and assign it a name and mileaga in the arguements (arguements are things in the parentheses)
        {
            name = nameOfAirport;                                           // This takes the string nameOfAirport in the arguments, and gives the airport a name based on that string
            mileageTo = mileageToAirport;                                   // This takes the int mileageToAirport in the arguments, and gives the airport mileage based on that int
        }

        static void Main(string[] args)                                     // This is the main function that runs when the program starts
        {
            Plane flightToLA = new Plane();                                 // We create a new Plane, that we created in the Plane Class
            flightToLA.Flight();                                            // This calls the Plane's Flight() method and is where most of the program runs
        }
    }
}
