using System.Collections.Generic;
using UnityEngine;

public class BrailleDatabase : MonoBehaviour
{
    // Singleton pattern for easy access
    public static BrailleDatabase Instance;

    // Dictionary mapping letters to dot patterns
    private Dictionary<char, bool[]> letterPatterns = new Dictionary<char, bool[]>();
    private Dictionary<char, bool[]> numberPatterns = new Dictionary<char, bool[]>();
    private Dictionary<char, bool[]> punctuationPatterns = new Dictionary<char, bool[]>();
    
    // Additional information for each character
    private Dictionary<char, string> exampleWords = new Dictionary<char, string>();
    private Dictionary<char, string> audioDescriptions = new Dictionary<char, string>();

    private void Awake()
    {
        // Set up singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the database
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        // ALPHABET PATTERNS
        // Each pattern is represented as a 6-element boolean array
        // where true means the dot is active for that letter
        // The order is: [1, 2, 3, 4, 5, 6] matching standard Braille positions
        
        // Letter A - dot 1
        letterPatterns.Add('A', new bool[] { true, false, false, false, false, false });
        exampleWords.Add('A', "Apple");
        audioDescriptions.Add('A', "A as in Apple. Dot 1 only.");
        
        // Letter B - dots 1, 2
        letterPatterns.Add('B', new bool[] { true, true, false, false, false, false });
        exampleWords.Add('B', "Ball");
        audioDescriptions.Add('B', "B as in Ball. Dots 1 and 2.");
        
        // Letter C - dots 1, 4
        letterPatterns.Add('C', new bool[] { true, false, false, true, false, false });
        exampleWords.Add('C', "Cat");
        audioDescriptions.Add('C', "C as in Cat. Dots 1 and 4.");
        
        // Letter D - dots 1, 4, 5
        letterPatterns.Add('D', new bool[] { true, false, false, true, true, false });
        exampleWords.Add('D', "Dog");
        audioDescriptions.Add('D', "D as in Dog. Dots 1, 4, and 5.");
        
        // Letter E - dots 1, 5
        letterPatterns.Add('E', new bool[] { true, false, false, false, true, false });
        exampleWords.Add('E', "Elephant");
        audioDescriptions.Add('E', "E as in Elephant. Dots 1 and 5.");
        
        // Letter F - dots 1, 2, 4
        letterPatterns.Add('F', new bool[] { true, true, false, true, false, false });
        exampleWords.Add('F', "Fish");
        audioDescriptions.Add('F', "F as in Fish. Dots 1, 2, and 4.");
        
        // Letter G - dots 1, 2, 4, 5
        letterPatterns.Add('G', new bool[] { true, true, false, true, true, false });
        exampleWords.Add('G', "Goat");
        audioDescriptions.Add('G', "G as in Goat. Dots 1, 2, 4, and 5.");
        
        // Letter H - dots 1, 2, 5
        letterPatterns.Add('H', new bool[] { true, true, false, false, true, false });
        exampleWords.Add('H', "House");
        audioDescriptions.Add('H', "H as in House. Dots 1, 2, and 5.");
        
        // Letter I - dots 2, 4
        letterPatterns.Add('I', new bool[] { false, true, false, true, false, false });
        exampleWords.Add('I', "Ice");
        audioDescriptions.Add('I', "I as in Ice. Dots 2 and 4.");
        
        // Letter J - dots 2, 4, 5
        letterPatterns.Add('J', new bool[] { false, true, false, true, true, false });
        exampleWords.Add('J', "Jam");
        audioDescriptions.Add('J', "J as in Jam. Dots 2, 4, and 5.");
        
        // Letter K - dots 1, 3
        letterPatterns.Add('K', new bool[] { true, false, true, false, false, false });
        exampleWords.Add('K', "Kite");
        audioDescriptions.Add('K', "K as in Kite. Dots 1 and 3.");
        
        // Letter L - dots 1, 2, 3
        letterPatterns.Add('L', new bool[] { true, true, true, false, false, false });
        exampleWords.Add('L', "Lion");
        audioDescriptions.Add('L', "L as in Lion. Dots 1, 2, and 3.");
        
        // Letter M - dots 1, 3, 4
        letterPatterns.Add('M', new bool[] { true, false, true, true, false, false });
        exampleWords.Add('M', "Mouse");
        audioDescriptions.Add('M', "M as in Mouse. Dots 1, 3, and 4.");
        
        // Letter N - dots 1, 3, 4, 5
        letterPatterns.Add('N', new bool[] { true, false, true, true, true, false });
        exampleWords.Add('N', "Nest");
        audioDescriptions.Add('N', "N as in Nest. Dots 1, 3, 4, and 5.");
        
        // Letter O - dots 1, 3, 5
        letterPatterns.Add('O', new bool[] { true, false, true, false, true, false });
        exampleWords.Add('O', "Orange");
        audioDescriptions.Add('O', "O as in Orange. Dots 1, 3, and 5.");
        
        // Letter P - dots 1, 2, 3, 4
        letterPatterns.Add('P', new bool[] { true, true, true, true, false, false });
        exampleWords.Add('P', "Pen");
        audioDescriptions.Add('P', "P as in Pen. Dots 1, 2, 3, and 4.");
        
        // Letter Q - dots 1, 2, 3, 4, 5
        letterPatterns.Add('Q', new bool[] { true, true, true, true, true, false });
        exampleWords.Add('Q', "Queen");
        audioDescriptions.Add('Q', "Q as in Queen. Dots 1, 2, 3, 4, and 5.");
        
        // Letter R - dots 1, 2, 3, 5
        letterPatterns.Add('R', new bool[] { true, true, true, false, true, false });
        exampleWords.Add('R', "Rabbit");
        audioDescriptions.Add('R', "R as in Rabbit. Dots 1, 2, 3, and 5.");
        
        // Letter S - dots 2, 3, 4
        letterPatterns.Add('S', new bool[] { false, true, true, true, false, false });
        exampleWords.Add('S', "Sun");
        audioDescriptions.Add('S', "S as in Sun. Dots 2, 3, and 4.");
        
        // Letter T - dots 2, 3, 4, 5
        letterPatterns.Add('T', new bool[] { false, true, true, true, true, false });
        exampleWords.Add('T', "Tree");
        audioDescriptions.Add('T', "T as in Tree. Dots 2, 3, 4, and 5.");
        
        // Letter U - dots 1, 3, 6
        letterPatterns.Add('U', new bool[] { true, false, true, false, false, true });
        exampleWords.Add('U', "Umbrella");
        audioDescriptions.Add('U', "U as in Umbrella. Dots 1, 3, and 6.");
        
        // Letter V - dots 1, 2, 3, 6
        letterPatterns.Add('V', new bool[] { true, true, true, false, false, true });
        exampleWords.Add('V', "Violin");
        audioDescriptions.Add('V', "V as in Violin. Dots 1, 2, 3, and 6.");
        
        // Letter W - dots 2, 4, 5, 6
        letterPatterns.Add('W', new bool[] { false, true, false, true, true, true });
        exampleWords.Add('W', "Water");
        audioDescriptions.Add('W', "W as in Water. Dots 2, 4, 5, and 6.");
        
        // Letter X - dots 1, 3, 4, 6
        letterPatterns.Add('X', new bool[] { true, false, true, true, false, true });
        exampleWords.Add('X', "X-ray");
        audioDescriptions.Add('X', "X as in X-ray. Dots 1, 3, 4, and 6.");
        
        // Letter Y - dots 1, 3, 4, 5, 6
        letterPatterns.Add('Y', new bool[] { true, false, true, true, true, true });
        exampleWords.Add('Y', "Yellow");
        audioDescriptions.Add('Y', "Y as in Yellow. Dots 1, 3, 4, 5, and 6.");
        
        // Letter Z - dots 1, 3, 5, 6
        letterPatterns.Add('Z', new bool[] { true, false, true, false, true, true });
        exampleWords.Add('Z', "Zebra");
        audioDescriptions.Add('Z', "Z as in Zebra. Dots 1, 3, 5, and 6.");
        
        // NUMBER PATTERNS
        // In Braille, numbers use the same patterns as letters A-J but are preceded by a number sign
        // For this app, we'll just store their patterns directly
        
        // Number 1 (same as letter A)
        numberPatterns.Add('1', new bool[] { true, false, false, false, false, false });
        audioDescriptions.Add('1', "Number 1. Dot 1 only.");
        
        // Number 2 (same as letter B)
        numberPatterns.Add('2', new bool[] { true, true, false, false, false, false });
        audioDescriptions.Add('2', "Number 2. Dots 1 and 2.");
        
        // Number 3 (same as letter C)
        numberPatterns.Add('3', new bool[] { true, false, false, true, false, false });
        audioDescriptions.Add('3', "Number 3. Dots 1 and 4.");
        
        // Number 4 (same as letter D)
        numberPatterns.Add('4', new bool[] { true, false, false, true, true, false });
        audioDescriptions.Add('4', "Number 4. Dots 1, 4, and 5.");
        
        // Number 5 (same as letter E)
        numberPatterns.Add('5', new bool[] { true, false, false, false, true, false });
        audioDescriptions.Add('5', "Number 5. Dots 1 and 5.");
        
        // Number 6 (same as letter F)
        numberPatterns.Add('6', new bool[] { true, true, false, true, false, false });
        audioDescriptions.Add('6', "Number 6. Dots 1, 2, and 4.");
        
        // Number 7 (same as letter G)
        numberPatterns.Add('7', new bool[] { true, true, false, true, true, false });
        audioDescriptions.Add('7', "Number 7. Dots 1, 2, 4, and 5.");
        
        // Number 8 (same as letter H)
        numberPatterns.Add('8', new bool[] { true, true, false, false, true, false });
        audioDescriptions.Add('8', "Number 8. Dots 1, 2, and 5.");
        
        // Number 9 (same as letter I)
        numberPatterns.Add('9', new bool[] { false, true, false, true, false, false });
        audioDescriptions.Add('9', "Number 9. Dots 2 and 4.");
        
        // Number 0 (same as letter J)
        numberPatterns.Add('0', new bool[] { false, true, false, true, true, false });
        audioDescriptions.Add('0', "Number 0. Dots 2, 4, and 5.");
        
        // PUNCTUATION PATTERNS
        // Period - dots 2, 5, 6
        punctuationPatterns.Add('.', new bool[] { false, true, false, false, true, true });
        audioDescriptions.Add('.', "Period. Dots 2, 5, and 6.");
        
        // Comma - dot 2
        punctuationPatterns.Add(',', new bool[] { false, true, false, false, false, false });
        audioDescriptions.Add(',', "Comma. Dot 2 only.");
        
        // Question mark - dots 2, 3, 6
        punctuationPatterns.Add('?', new bool[] { false, true, true, false, false, true });
        audioDescriptions.Add('?', "Question mark. Dots 2, 3, and 6.");
        
        // Exclamation mark - dots 2, 3, 5
        punctuationPatterns.Add('!', new bool[] { false, true, true, false, true, false });
        audioDescriptions.Add('!', "Exclamation mark. Dots 2, 3, and 5.");
    }

    // Get the pattern for a specific letter
    public bool[] GetPatternForLetter(char letter)
    {
        // Convert to uppercase for consistency
        char upperLetter = char.ToUpper(letter);
        
        if (letterPatterns.ContainsKey(upperLetter))
        {
            return letterPatterns[upperLetter];
        }
        
        // Return empty pattern if letter not found
        Debug.LogWarning("Letter not found in Braille database: " + letter);
        return new bool[] { false, false, false, false, false, false };
    }
    
    // Get the pattern for a number
    public bool[] GetPatternForNumber(char number)
    {
        if (numberPatterns.ContainsKey(number))
        {
            return numberPatterns[number];
        }
        
        // Return empty pattern if number not found
        Debug.LogWarning("Number not found in Braille database: " + number);
        return new bool[] { false, false, false, false, false, false };
    }
    
    // Get the pattern for punctuation
    public bool[] GetPatternForPunctuation(char punctuation)
    {
        if (punctuationPatterns.ContainsKey(punctuation))
        {
            return punctuationPatterns[punctuation];
        }
        
        // Return empty pattern if punctuation not found
        Debug.LogWarning("Punctuation not found in Braille database: " + punctuation);
        return new bool[] { false, false, false, false, false, false };
    }
    
    // Get pattern for any character (letter, number, or punctuation)
    public bool[] GetPatternForCharacter(char character)
    {
        // Check if it's a letter
        if (char.IsLetter(character))
        {
            return GetPatternForLetter(character);
        }
        // Check if it's a number
        else if (char.IsDigit(character))
        {
            return GetPatternForNumber(character);
        }
        // Otherwise try punctuation
        else
        {
            return GetPatternForPunctuation(character);
        }
    }
    
    // Get audio description for a character
    public string GetAudioDescription(char character)
    {
        if (audioDescriptions.ContainsKey(character))
        {
            return audioDescriptions[character];
        }
        else if (audioDescriptions.ContainsKey(char.ToUpper(character)))
        {
            return audioDescriptions[char.ToUpper(character)];
        }
        
        return "Character not found in database.";
    }
    
    // Get example word for a letter
    public string GetExampleWord(char letter)
    {
        char upperLetter = char.ToUpper(letter);
        
        if (exampleWords.ContainsKey(upperLetter))
        {
            return exampleWords[upperLetter];
        }
        
        return "";
    }
    
    // For debugging - print a character's pattern
    public void DebugPrintPattern(char character)
    {
        bool[] pattern = GetPatternForCharacter(character);
        string patternString = "";
        
        for (int i = 0; i < pattern.Length; i++)
        {
            patternString += pattern[i] ? "●" : "○";
            if (i == 2) patternString += "\n"; // Line break after dot 3
        }
        
        Debug.Log($"Braille pattern for {character}:\n{patternString}");
    }
}