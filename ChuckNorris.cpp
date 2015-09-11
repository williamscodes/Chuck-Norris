#include <iostream>
#include <string>
#include <bitset>

using namespace std;

// Function prototypes
string bitConvert (string message, string bits);
string norrisConvert (string bits);

int main()
{
    string MESSAGE;
    getline(cin, MESSAGE);

    // Declare the string to hold the message in bits
    string bitString = "";
    
    // Create the bit string calling the bitConvert function
    bitString = bitConvert (MESSAGE, bitString);
    
    // Convert the bit string calling the norrisConvert function
    bitString = norrisConvert (bitString);
    
    // Output the converted string
    cout << bitString << endl;
}

// Constructs the bit string based on 8 bits
string bitConvert (string message, string bitsConverted)
{
    for (int counter = 0; counter < message.length(); ++counter)
    {
        char s = message[counter];
        bitset<7> bits(s);
        bitsConverted += bits.to_string();
    }
    
    // Return string passed by arguement
    return bitsConverted;
}

// Convertes the string to the norris conversion
string norrisConvert (string bits)
{
    // Temp variables for string conversion manipulation
    string output = "";
    string temp = "";
    int isZero = -1;
    
    // For each element from beginning to end of string
    for (string::iterator it = bits.begin(); it != bits.end(); ++it)
    {
        // New zero is set to position of it
        int newIsZero = (*it == '0');
        
        // If newIsZero is equal to -1 the first index of temp should be 0
        if (newIsZero == isZero)
        {
            temp += "0";
        }
        // Else the first index does not contain a 1
        else
        {
            isZero = newIsZero;
            
            // If length is greater than 0 add a space to output
            if ((output.length()) > 0)
            {
                output += " ";
            }
            
            // Add temp value after prepended space
            output += temp;
            
            // If isZero is true there are no 1's in second series
            if (isZero)
            {
                temp = "00 0";
            }
            // Else there is a 1 in the second series
            else
            {
                temp = "0 0";
            }
        }
    }
    
    // If length is greater than 0 postpend a space and then postpend temp
    if ((temp.length()) > 0)
    {
        if ((output.length()) > 0)
        {
            output += " ";
        }
        
        output += temp;
    }
    
    // Return ouput
    return output;
}
