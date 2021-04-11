using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PraticalTask3_LinearAndBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial build lists
            /*List<string> movieList = new List<string> { "movie1", "movie2", "movie3" };
            Console.WriteLine("Expected position for movie1 is 0 and for movie4 is -1");
            Console.WriteLine("Movie position for movie1 is at: {0}", LinearSearch.Search(movieList, "movie1"));
            Console.WriteLine("Movie position for movie4 is at: {0}", LinearSearch.Search(movieList, "movie4"));

            List<string> movieList2 = new List<string> { "movie1", "movie2", "movie3", "movie4", "movie5", "movie6" };
            Console.WriteLine("Expected position for movie1 is 0 and for movie4 is 3 and movie7 is -1");
            Console.WriteLine("Movie position for movie1 is at: {0}", BinarySearch.Search(movieList2, "movie1", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie4 is at: {0}", BinarySearch.Search(movieList2, "movie4", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie7 is at: {0}", BinarySearch.Search(movieList2, "movie7", 0, movieList2.Count - 1));
            Console.WriteLine("Movie position for movie3 is at: {0}", BinarySearch.Search(movieList2, "movie3", 0, movieList2.Count - 1));*/
            UserInput.UserSearch();
        }

    }
    class LinearSearch
    {
        public static int Search(List<string> movieList, string searchItem)
        {
            bool flag = false;
            int recordPosition = 0;
            //itterate through list till item is found or not
            foreach (string movie in movieList)
            {
                if (movie == searchItem)
                {
                    flag = true;
                    break;
                }
                //movie not at current index increase recordPosition
                recordPosition++;
            }
            if (flag == false) { return recordPosition = -1; }
            else { return recordPosition; }
        }
    }
    class BinarySearch
    {
        public static int Search(List<string> movieList, string searchItem, int left, int right)
        {
            int recordPosition = 0;

            //check to see if left is smaller as it means the list hasn't been fully searched
            if (left < right)
            {
                int middle = (left + right - 1) / 2;
                //if middle indexed item == searchItem then found, otherwise compare to see if larger or smaller
                if (movieList[middle] == searchItem)
                {
                    // movie found
                    recordPosition = middle;
                    return recordPosition;
                }
                //check to see if larger than middle
                else if (searchItem.CompareTo(movieList[middle]) > 0)
                {
                    //movie can't be in left partition
                    return Search(movieList, searchItem, middle + 1, right);
                }
                //check to see if smaller than middle
                else if (searchItem.CompareTo(movieList[middle]) < 0)
                {
                    //movie can't be in right partition
                    return Search(movieList, searchItem, left, middle - 1);
                }
                else
                {
                    return Search(movieList, searchItem, left, right - 1);
                }
            }
            recordPosition = -1;
            return recordPosition;
        }
    }
    class UserInput
    {
        static char binaryOrLinear;
        static string searchMovieRequest;
        static bool searchLoop = true;
        static bool searchingLoop = true;

        public static void UserSearch()
        {
            //declare variables
            bool continueFlag = true;           
            var chosenFile = new List<string>();
            char keyPressed;
            char fileKey;
            

            //loop for user to keep searching
            while (continueFlag)
            {
                //create bools and reset to true for mutiple file searches
                bool searchFileAgain = true;
                bool fileLoop = true;
                searchingLoop = true;
                searchLoop = true;
                //initial message
                Console.WriteLine("\r\nDo you wish to perform a movie search?");
                Console.WriteLine("Press Y to procceed or N to cancel");
                //save key pressed  
                keyPressed = Console.ReadKey(true).KeyChar;
                //perform search move into next step
                if (keyPressed == 'y')
                {
                    //ask user for which movie file to load
                    //create list variables for coresponding movie data files
                    Console.WriteLine();
                    Console.WriteLine("Which movie list do you want to search from:");
                    Console.WriteLine("Press 1 for Movie list 20");
                    Console.WriteLine("Press 2 for Movie list 100");
                    Console.WriteLine("Press 3 for Movie list 200");
                    Console.WriteLine("Press 4 for Movie list 100k");
                    Console.WriteLine("Press 5 for Movie list 400k");
                    Console.WriteLine("Press 6 for Movie list 2mil");

                    //loop til a file is chosen
                    while (fileLoop)
                    {

                        fileKey = Console.ReadKey(true).KeyChar;
                        // if statements to decide which list to create and use
                        //20 list
                        if (fileKey == '1')
                        {
                            List<string> movieList20 = new List<string>();
                            string movieFile20Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles20.txt";
                            movieList20 = File.ReadAllLines(movieFile20Path).ToList();
                            chosenFile = movieList20;
                            fileLoop = false;
                        }
                        //100 list
                        else if (fileKey == '2')
                        {
                            List<string> movieList100 = new List<string>();
                            string movieFile100Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\moviesTopGrossing100.txt";
                            movieList100 = File.ReadAllLines(movieFile100Path).ToList();
                            chosenFile = movieList100;
                            fileLoop = false;
                        }
                        //200 list
                        else if (fileKey == '3')
                        {
                            List<string> movieList200 = new List<string>();
                            string movieFile200Path = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\moviesTopGrossing200.txt";
                            movieList200 = File.ReadAllLines(movieFile200Path).ToList();
                            chosenFile = movieList200;
                            fileLoop = false;
                        }
                        //100k list
                        else if (fileKey == '4')
                        {
                            List<string> movieList100k = new List<string>();
                            string movieFile100kPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles100K.txt";
                            movieList100k = File.ReadAllLines(movieFile100kPath).ToList();
                            chosenFile = movieList100k;
                            fileLoop = false;
                        }
                        //400k list
                        else if (fileKey == '5')
                        {
                            List<string> movieList400k = new List<string>();
                            string movieFile400kPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\movieTitles400K.txt";
                            movieList400k = File.ReadAllLines(movieFile400kPath).ToList();
                            chosenFile = movieList400k;
                            fileLoop = false;
                        }
                        //2mil list
                        else if (fileKey == '6')
                        {
                            List<string> movieList2mil = new List<string>();
                            string movieFile2milPath = @"C:\Users\User\Desktop\class\Algorithms\PraticalTask3_LinearAndBinarySearch\data\searchassessment\MovieTitles_2million.txt";
                            movieList2mil = File.ReadAllLines(movieFile2milPath).ToList();
                            chosenFile = movieList2mil;
                            fileLoop = false;
                        }
                        else
                        {
                            Console.WriteLine("Press 1, 2, 3, 4, 5, 6 for the file you wish to load");
                        }
                    }

                    //loop til search method is chosen
                    while(searchLoop)
                    {
                        Console.WriteLine("Press B for binary search or press L for linear search");
                        binaryOrLinear = Console.ReadKey(true).KeyChar;
                        if(binaryOrLinear == 'b')
                        {
                            searchLoop = false;
                        }
                        else if (binaryOrLinear == 'l')
                        {
                            searchLoop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid key pressed");
                        }
                    }
                  
                    //loop til searching is done in current file
                    while(searchingLoop)
                    {
                        //request search item
                        Console.WriteLine("Enter the movie you wish to search for:\r\n");
                        searchMovieRequest = Console.ReadLine();
                        
                        //perform search
                        if(binaryOrLinear == 'b')
                        {
                            BinarySearch.Search(chosenFile, searchMovieRequest, 0, chosenFile.Count - 1);
                        }
                        else
                        {
                            Console.WriteLine(LinearSearch.Search(chosenFile, searchMovieRequest));
                        }
                        //ask user if want to perform another search on the same file
                        while (searchFileAgain)
                        {
                            Console.WriteLine("Do you wish to search this file again? \r\n Press y for yes or n for no");
                            char keyPress = Console.ReadKey(true).KeyChar;
                            if(keyPress == 'y') { searchFileAgain = true; break; }
                            else if(keyPress == 'n') { searchingLoop = false; searchFileAgain = false; }
                            else
                            {
                                Console.WriteLine("Incorrect key pressed, press y to search file again or n to end search");
                            }
                        }
                    }
                    
                }
                //end while loop statement
                else if (keyPressed == 'n')
                {
                    Console.WriteLine("Ending movie search program");
                    continueFlag = false;
                }
                else { Console.WriteLine("Incorrect key pressed, press y to search or n to end search"); }
            }
        }
    }
}
