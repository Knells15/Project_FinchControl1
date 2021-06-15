using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{


    class Program
    {

        // *************************************************
        //
        // Title: Finch Control 
        // Application Type: Console
        // Description: Starter solution with the helper methods,
        //              opening and closing screens, and the menu
        // Author: Nelson, Kelley
        // Dated Created: 6/1/2021
        // Last Modified: 6/14/2021
        //
        // **************************************************
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();

            MyName();
 
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

        }


        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");
                Console.WriteLine("This module is currently under development and some choices may not work.");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 300; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 10);
            }
            for (int lightSoundLevel = 300; lightSoundLevel > 0; lightSoundLevel--)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 10);
                finchRobot.noteOff();
            }

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                             *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its talent for dancing!");
            DisplayContinuePrompt();

            finchRobot.setMotors(125, 125);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 255, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, 125);
            finchRobot.wait(1000);
            finchRobot.setLED(255, 255, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, -125);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 255, 255);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, 125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch robot will now show off its talent dancing and playing music!");
            DisplayContinuePrompt();

            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setMotors(125, 125);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 255, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, 125);
            finchRobot.wait(1000);
            finchRobot.setLED(255, 255, 0);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setMotors(125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, -125);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 255, 255);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(300);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.setMotors(125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(-125, 125);
            finchRobot.wait(1000);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(700);
            finchRobot.noteOff();
            finchRobot.setMotors(125, -125);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");

        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>
        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points ");
                Console.WriteLine("\tb) Frequency of Data Points ");
                Console.WriteLine("\tc) Get Data ");
                Console.WriteLine("\td) Show Data ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                       numberOfDataPoints = DataRecorderNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderFrequencyOfData();
                        break;

                    case "c":
                        temperatures = DataRecorderGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *           Data Recorder >  Number of Data Points              *
        /// *****************************************************************
        /// </summary>
        static int DataRecorderNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;

            DisplayScreenHeader("Number of Data Points");

            Console.WriteLine("Number of Data Points: "); 
            userResponse = Console.ReadLine();
            Console.WriteLine($"You have chosen {userResponse} number of data points.");

            int.TryParse(userResponse, out numberOfDataPoints);
            DisplayContinuePrompt();


            return numberOfDataPoints;
        }

        /// <summary>
        /// *****************************************************************
        /// *           Data Recorder >  Frequency of Data Points           *
        /// *****************************************************************
        /// </summary>
        static double DataRecorderFrequencyOfData()
        {
            double dataPointFrequency;
            string userResponse;

            DisplayScreenHeader("Frequency of Data Points");

            Console.WriteLine("Frequency of Data Points: ");
            userResponse = Console.ReadLine();
            Console.WriteLine($"You have chosen {userResponse} number of frequency data points.");

            double.TryParse(userResponse, out dataPointFrequency);
            
            DisplayContinuePrompt();


            return dataPointFrequency;
        }

        /// <summary>
        /// *****************************************************************
        /// *                 Data Recorder >  Get Data                     *
        /// *****************************************************************
        static double[] DataRecorderGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            int lightsensor;

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of Data Point: {numberOfDataPoints}");
            Console.WriteLine($"Data point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("The Finch Robot is ready to begin recording temperatures and light sensors.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"Reading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("Now reading Left Light Sensors.");

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                lightsensor = finchRobot.getLeftLightSensor();
                Console.WriteLine($"Reading Left Light Sensor{index + 1}: {lightsensor.ToString("n2")}");
                int waitInSeconds = (int)(lightsensor * 1000);
                finchRobot.wait(waitInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("Now reading Right Light Sensors.");


            for (int index = 0; index < numberOfDataPoints; index++)
            {
                lightsensor = finchRobot.getRightLightSensor();
                Console.WriteLine($"Reading Right Light Sensor{index + 1}: {lightsensor.ToString("n2")}");
                int waitInSeconds = (int)(lightsensor * 1000);
                finchRobot.wait(waitInSeconds);
            }


            DisplayContinuePrompt();

            return temperatures;
        }



        /// <summary>
        /// *****************************************************************
        /// *                 Data Recorder >  Show Data                    *
        /// *****************************************************************
        /// </summary>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            double fahrenheit;
            double celsius = 0;

            Console.WriteLine(
                "Recording #".PadLeft(20) +
                "Temperature".PadLeft(20)
                );

            Console.WriteLine(
                "-----------".PadLeft(20) +
                "-----------".PadLeft(20)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {

                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(22)
                    );

            }

            Console.WriteLine("Celsius: " + celsius);
            fahrenheit = (celsius * 9) / 5 + 32;
            Console.WriteLine("Fahrenehit: " + fahrenheit);


            DisplayContinuePrompt();
                    
        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                         *
        /// *****************************************************************
        /// </summary>
        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitAlarmSystemMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Alarm System Menu");
                Console.WriteLine("This module is currently under development and some choices may not work.");
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Under Construction ");
                Console.WriteLine("\tb) Under Construction ");
                Console.WriteLine("\tc) Under Construction ");
                Console.WriteLine("\td) Under Construction ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        break;

                    case "b":

                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitAlarmSystemMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitAlarmSystemMenu);
        }
        #endregion

        #region USER PROGRAMMING

        /// <summary>
        /// *****************************************************************
        /// *                     User Programming Menu                     *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("User Programming Menu");
                Console.WriteLine("This module is currently under development and some choices may not work.");
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Under Construction ");
                Console.WriteLine("\tb) Under Construction ");
                Console.WriteLine("\tc) Under Construction ");
                Console.WriteLine("\td) Under Construction ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":

                        break;

                    case "b":

                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgrammingMenu);
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT
        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tConnecting to Finch robot. \n\tPlease be sure the USB cable is connected to the robot and computer before continuing.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOn(523);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            Console.WriteLine("\tThe Finch robot is now connected.");

            DisplayMenuPrompt("Main Menu");

            return robotConnected;
        }
        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tThe application is about to disconnect the Finch Robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to the Finch Control App\nThis application was created so that you can see what the Finch robot can do.");
            Console.WriteLine();

            MyName();

            Console.WriteLine();
            Console.Write("Please connect to Finch robot on next screen.");
            Console.WriteLine();


            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tThank you for checking out the Finch Control App!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        //
        // display my name
        //
        static void MyName(string name = "Kelley")
        {
  

            Console.WriteLine();
            Console.WriteLine($"My name is {name}. I hope you enjoy the app I have been working on.");


        }
        #endregion
    }

}
