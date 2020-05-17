using System;
using System.Threading;

namespace Airport
{
    class Plane                                                                             // The Plane Class.
    {        
        int flightNumber;                                                                   // Each plane has a flight number.

        public void Flight()                                                                // The flight method that gets called in the Airport class. This does a lot of work. It creates a random flight number, it sets the itinerary, and calls the Takeoff, Cruising, and Landing methods in a loop
        {
            Random rand = new Random();                                                     // This is jus thow C# handles random number generators, it's an object you have to make.
            flightNumber = rand.Next(1000, 9999);                                           // Here we set the flightNumber to a random number between 1000 and 9999. Each time the program runs, you'll have a different flight number. An easy flair to add.
            
            Airport[] itinerary = new Airport[4];                                           // Here we create an array of 4 Airport objects
            itinerary[0] = new Airport("Albany", 0);                                        // Here we set the first object's name to Albany, and mileageTo to 0. Seeing how we never travel to Albany, we don't need a number here, but we can't keep it blank. It has to be set for it to be a valid object
            itinerary[1] = new Airport("NYC", 146);                                         // Here we set the second object's name to NYC and mileageTo to 146, this is the distance between Albany and NYC airports
            itinerary[2] = new Airport("Chicago", 740);                                     // Here we set the third object's name to Chicago and mileageTo 740, this is the distance between NYC and Chicago airports
            itinerary[3] = new Airport("Los Angeles", 1745);                                // Here we set the fourth object's name to Los Angeles and mileageTo to 1745, this is the distance between Chicago and LA airports. Remember to put the names in quotes, as it's a string and the string is anything inside quotes
           
            Console.WriteLine("Welcome to the " + itinerary[0].name + " Airport! \nWe will be boarding Flight #" + flightNumber + " to " + itinerary[itinerary.Length -1].name + " Airport shortly.\n");    // The console writes what's said. itinerary[0].name brings up the name of the first airport, Albany, and itinerary[itinerary.Length -1].name brings up LA's name, because the Length of the array is 4, and the number of LA in the array is 3. This is because arrays start at 0. At least in C#
            Thread.Sleep(5000);                                                             // In the java project, you'll have to create the Pause method he gave you code for, and you'd simply write Pause(5000) to have the program pause for 5 seconds. 1000 = 1 second.
            Console.WriteLine("Now boarding for Flight #" + flightNumber + ". Please board the flight.");   // More flavor text. You don't need to add this much, it will probably be better to keep it as simple as you can. 
            Thread.Sleep(5000);                                                             // I like to pause 5 seconds after most text to give enough time to read it
            Console.Clear();                                                                // This clears out the screen, allowing more to be written without it constantly scrolling. Not sure how java does this, but I'm sure they have a similiar command.
            Console.WriteLine("Hello! This is your captain speaking. \nWelcome aboard Flight #" + flightNumber + " traveling from the " + itinerary[0].name + " Airport to the " + itinerary[itinerary.Length - 1].name + " Airport.");
            Thread.Sleep(5000);
            Console.WriteLine("We will be making " + (itinerary.Length - 2) + " stops at the " + itinerary[1].name + " and " + itinerary[2].name + " Airports before arriving at our final destination.");  // Only thing I want to point out here is the (itinerary.Length - 2) is to make it so it would say how many stops minus the first airport and last airport. With a more simple program you don't need to do that. 
            Thread.Sleep(5000);
            Console.WriteLine("Preparations are complete, and we will begin taking off shortly. Please enjoy the flight.");
            Thread.Sleep(5000);


            for (int i = 0; i < itinerary.Length - 1; i++)                                  // Standard for loop, however for the length I made it itinerary.length - 1, because the arrary and the loop starts at 0, and the length is technically 4. The code inside the loop will cycle until we reach the destination.
            {
                Console.Clear();
                TakeOff(itinerary[i]);                                    // Calling the TakeOff method, passing in the current airport in the arguments to use in the method
                Cruise(itinerary[i + 1]);                                                   // Calling the Cruise method, passing in the destination (which is +1 from our current location) airport in order to calculate how long it will take in the method
                Land(itinerary[i + 1]);                                                     // Calling the Land method, passing in the destination in the arguments to use that information in the method
            }

            Console.Clear();
            Console.WriteLine("Thank you so much for flying with us today. We hope you had a comfortable flight."); // This is the final statement before the program closes. 
            Thread.Sleep(5000);
        }

        public void TakeOff(Airport departing)                         // The TakeOff Method, this code excutes in the loop in the Flight method. It's just fluff text. 
        {
            Console.Clear();
            Console.WriteLine("We have begun taxiing to the runway. Please be patient as we approach.");
            Thread.Sleep(5000);
            Console.WriteLine("We have arrived at the runway, and have begun taking off from the " + departing.name + " Airport. \nPlease remain seated as we start our ascent.");
            Thread.Sleep(5000);
        }

        public void Cruise(Airport destination)                         // The Cruise method. We use the destination airport data to calculate the travel time, and pause the program that amount of time.
        {
            Console.Clear();
            int travelTime = destination.mileageTo * 100;               // We take the mileageTo data belonging to the destination airport, and multiply it by 100. This gives us a decent amount of wait time between airports.
            Console.WriteLine("We have reached our cruising altitude. The fasten seat belts signs have been turned off. \nYou are free to move about the cabin." +
                "\nIt will take roughly " + travelTime / 1000 + " seconds to arrive at the " + destination.name + " Airport so please take this time to relax.\n"); // I divide the travelTime by 1000 because that will give us how many seconds it will take.
            
            if (travelTime <= 50000)                                    // This is just for fun, you don't need to do these elaborate if statement section. I just wanted to have the longer trips have some sort of update text. In this case, this identifies the short trip
                Thread.Sleep(travelTime - 5000);                        // For your program, you'll use the Pause() method. I made it subtract 5000 from the travel time, because I have a fluff text saying we're approaching soon, and then wait another 5000. 
            else if(travelTime > 100000)                                // This identifies the longest trip. I'm not 100% certain, but I think I have to put this first, because it's checking the if statements in order. So technically, the longest trip is also long enough to be true with the next if statement, and I think it would only do that code. In this case, it realizes it's over 100k, and does this code, then stops. 
            {
                Thread.Sleep(travelTime / 3);                           // I wanted extra fluff to happen on the longer trip, so I have them occur 1/3rd into the trip.
                Console.WriteLine("Please enjoy an inflight snack as our staff hands out refreshments.\n");
                Thread.Sleep(travelTime / 3);
                Console.WriteLine("We have turned on the fasten seat belt sign because we seem to have hit some turbulence. \nPlease remain seated while the fasten seat belt sign is on.\n");
                Thread.Sleep(10000);
                Console.WriteLine("We have turned off the fasten seat belt sign because the turbulence has ended. \nPlease feel free to move about the cabin again.\n");
                Thread.Sleep((travelTime / 3) - 15000);                 // I subtract 15000 here, 10000 for the turbulence wait, and 5000 for the last descent text that will occur soon, therefore the overall travelTime is still accurate.
            }
            else if (travelTime > 50000)                                // This identifies the medium length trip
            {
                Thread.Sleep(travelTime / 2);                           // Halfway through the trip, the next flavor text happens.
                Console.WriteLine("Please enjoy an inflight snack as our staff hands out refreshments.\n");
                Thread.Sleep((travelTime / 2) - 5000);                  // I subtract 5000 from the travel time here for the final descent text.
            }                                   
            Console.WriteLine("We have turned on the fasten seat belts signs as we have begun our approach to the " + destination.name + " Airport. \nWe will be landing shortly."); // Every flight ends with this descent text
            Thread.Sleep(5000);                                         // And then waits 5 seconds before Landing
        }

        public void Land(Airport destination)                           // The Land method, we use the destination in the arguements for flavor text in the console. 
        {
            Console.Clear();
            Console.WriteLine("We have touched down at the " + destination.name + " Airport. \nPlease be patient as we approach the Gate so we can refuel.");            
            Thread.Sleep(5000);
            Console.WriteLine("We have reached the Gate and will begin refueling. We will take off immediately after fully refueld.");
            Thread.Sleep(5000);
            Console.WriteLine("We are completely refueld, and will prepare to taxi back to the runway.");
            Thread.Sleep(5000);
        }
    }
}
