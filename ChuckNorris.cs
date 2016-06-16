/**************
 * DIRECTIVES *
 *************/
using System;
using System.Text;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class program
{
    static void Main(string[] args)
    {
        /*************************
         * VARIABLE DECLARATIONS *
         ************************/
        string MESSAGE = Console.ReadLine();
        string Encoded = " ";
        int count0 = 0;
        int count1 = 0;
        bool newGrp = true;
        StringBuilder sb = new StringBuilder();

        // Write an action using Console.WriteLine()
        foreach (char c in MESSAGE.ToCharArray())
        {
            sb.Append(Convert.ToString(c, 2).PadLeft(7, '0'));
        }

        // store the string builder cast to string
        MESSAGE = sb.ToString();

        // For each char in message string
        foreach (char c in MESSAGE.ToCharArray())
        {
            // Newgrp will evaluate to true by default
            if (newGrp)
            {
                // If the char is 0 change to chuck norris encoding 00
                if (c == '0')
                {
                    Encoded += "00 ";
                }
                // Else encoded is 0 for chuck norris encoding
                else
                {
                    Encoded += "0 ";
                }
                // Change new group to false
                newGrp = false;
            }

            // Count the number of zeros and ones within the string
            if (c == '0' && count1 == 0)
            {
                count0++;
            }
            else if (c == '1' && count0 == 0)
            {
                count1++;
            }
            // Else it is another character
            else
            {
                // Change encoding for all zeros if count is greater than 0
                if (count0 != 0)
                {
                    for (int i = 0; i < count0; i++)
                    {
                        Encoded += "0";
                    }

                    count0 = 0;
                    count1++;
                }
                // Change encoding for all ones if count is greater than 0
                else if (count1 != 0)
                {
                    for (int i = 0; i < count1; i++)
                    {
                        Encoded += "0";
                    }

                    count1 = 0;
                    count0++;
                }
                // Add space to encoded and set new group to true
                Encoded += " ";
                newGrp = true;
                if (newGrp)
                {
                    if (c == '0')
                    {
                        Encoded += "00 ";
                    }
                    else
                    {
                        Encoded += "0 ";
                    }
                    newGrp = false;
                }
            }
        }

        // If count0 is not equal to 0 add 0 to Encoded until count the length of count0 is met
        if (count0 != 0)
        {
            for (int i = 0; i < count0; i++)
            {
                Encoded += "0";
            }
            count0 = 0;
        }
        // // If count0 is not equal to 0 add 0 to Encoded until count the length of count0 is met
        else if (count1 != 0)
        {
            for (int i = 0; i < count1; i++)
            {
                Encoded += "0";
            }
            count1 = 0;
        }

        // Trim residual white space
        Encoded = Encoded.Trim();

        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(Encoded);
    }
}
