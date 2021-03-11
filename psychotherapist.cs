using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Identification of necessary datas  \\
            char[] punctuations = { '.', ',', ';', '’', '”', '?', '!', '-', '{', '}', '(', ')', '[', ']' };

            char[] punctuationsForRule4 = { '.', '?', '!'};

            string[] stop_words = {"a", "after", "again", "all", "am", "and", "any", "are", "as", "at", "be", "been",
                                   "before", "between", "both", "but", "by", "can", "could", "for", "from", "had", "has", "he", "her", "here",
                                   "him", "in", "into", "I", "is", "it", "me", "my", "of", "on", "our", "she", "so", "such", "than", "that", "the",
                                   "then", "they", "this", "to", "until", "we", "was", "were", "with", "you"};

            string[] negative_words = {"stress", "depression", "sad", "angry", "hate", "pain", "abnormal", "abort", "abuse",
                                       "brittle", "hurt", "scared", "afraid", "upset", "confused", "lonely", "tired", "vulnerable", "guilty",
                                       "anxiety", "disappointment", "regret", "awful", "sick", "regretful", "unhappy", "sorrowful" , "troubled",
                                       "worried", "annoyed"};
            
            string[] question_words = { "Why", "Who", "When", "Where", "What", "How",};

            string[] WordsOfRule2 = { " Do you often think about this question ? ",
                                      "Why do you want to know ? "};

            //  Identification of necessary datas  \\


            string userInput = null;   
            Random rnd = new Random(); // -------> Random for program's random message

            //do-while loop for continuous conversation
            do
            {
                bool question = false; //------> If user ask to program any question, it will be "true" and program give a message to user according to this situation.
                bool negative = false; //------> If user say anythink that in the negative_words to program , it will be "true" and program give a message to user according to this situation.
                int RandomForRule2 = rnd.Next(0, 2); //----> Random for message on the rule 2
                int wordCounter = 0; // -----> word counter for rule 1. We have to count the words in rule 1. If word counter is bigger than 2 so any word appears more than 2 times
                                    //program give a message to user according to this situation.
                
                Console.Write("User: ");
                userInput = Console.ReadLine(); //-------> Taking input from user


                /////      RULE 1 IMPLEMENTATION    \\\\\\\

                //divide the sentence into words
                string[] words = null;
                string ProgramMessage = null; // where to keep messages for Rule1
                words = userInput.Split(' '); //----> seperating the sentence according to spaces.
                //divide the sentence into words

                //extracting punctuation in words
                for (int i = 0; i < words.Length; i++)
                {
                    for (int k = 0; k < punctuations.Length; k++)
                    {
                        if (words[i].Contains(punctuations[k]))
                            words[i] = words[i].Replace(Convert.ToString(punctuations[k]), string.Empty);
                    }
                }
                //extracting punctuation in words

                //separating words from stop_words if they are exist.
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < stop_words.Length; j++)
                    {
                        if (words[i].ToLower().Equals(stop_words[j].ToLower()))      // I did this because I dont need to count those words.
                        {                                                           // first for loop looks user's words, second looks words in the stop_words and seperate.
                            words[i] = words[i].Replace(words[i], string.Empty);
                        }
                    }
                }
                //separating words from stop_words if they are exist.

                //Finding the word that if it appears more tha 2 times
                for (int i = 0; i < words.Length; i++)
                {
                    wordCounter = 0;
                    for (int j = 0; j < words.Length; j++)                //first 'for' take a word from user's input and program enter second for. Second 'for' controls user's input
                    {                                                    // if there are same words, wordCounter is up.
                        if ((words[i].ToLower().Equals(words[j].ToLower())) && (words[i] != string.Empty))
                        {
                            wordCounter++;
                        }
                    }
                    if(wordCounter > 2)                         //if wordCounter is bigger than 2 program takes this word for program message.
                    {
                        ProgramMessage = words[i].ToLower();
                        break;
                    }
                }
                //Finding the word that if it appears more tha 2 times

                // Ask the user as more than 2 entered words
                if (wordCounter > 2)
                {
                    Console.Write("Program: ");
                    Console.WriteLine("Do you love "+ ProgramMessage +"?");
                }
                //Ask the user as more than 2 entered words

                /////      RULE 1 IMPLEMENTATION    \\\\\\\


                /////      RULE 2 IMPLEMENTATION    \\\\\\\

                //check for question word
                for (int i = 0; i < words.Length; i++)
                {                                                                           
                    for (int j = 0; j < question_words.Length; j++)               //first 'for' take a word from user's input and program enter second for. Second 'for' controls question_words
                    {                                                             // if there are same words, question will be true and program will give a message to user according to this situation
                        if (words[i].ToLower().Equals(question_words[j].ToLower()))
                        {
                            question = true;
                            Console.Write("Program: ");
                            Console.WriteLine(WordsOfRule2[RandomForRule2]);
                        }
                    }
                }
                //check for question word

                /////      RULE 2 IMPLEMENTATION    \\\\\\\

                /////      RULE 3 IMPLEMENTATION    \\\\\\\

                //check for negative word
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < negative_words.Length; j++)                 
                    {
                        if (words[i].ToLower().Equals(negative_words[j].ToLower()))   //first 'for' take a word from user's input and program enter second for. Second 'for' controls negative_words
                        {                                                             // if there are same words, negative will be true and program will give a message to user according to this situation
                            
                            negative = true;
                            ProgramMessage = words[i].ToLower();
                        }
                    }
                }
                if (negative == true)
                {
                    Console.Write("Program: ");
                    Console.WriteLine("Being " + ProgramMessage + " is bad for your health. How long do you feel " + ProgramMessage + "? Why do you feel " + ProgramMessage + "?");
                }
                //check for negative word

                /////      RULE 3 IMPLEMENTATION    \\\\\\\

                /////      RULE 4 IMPLEMENTATION    \\\\\\\

                //Identification of necessary variables for Rule 4
                int RandomForRule4 = rnd.Next(0, 2);
                string [] SentenceSeperator=null;
                string[] LastSentence = null;
                string TempForRule4;
                string ProgramOutput=null;
                //Identification of necessary variables for Rule 4

                //if other rules are not applied, program enters here...
                if (negative ==false && wordCounter <= 2 && question==false && userInput != "I have to go now.")
                {
                    SentenceSeperator = userInput.Split(punctuationsForRule4); //------> divide the user's input into sentences
                    TempForRule4 = SentenceSeperator[SentenceSeperator.Length-2]; //-----> put the last sentence of those sentences in the TempForRule4
                    LastSentence = TempForRule4.Split(' '); //------> seperating the sentence according to spaces.

                    //extracting punctuation in words
                    for (int i = 0; i < LastSentence.Length; i++)
                    {
                        for (int k = 0; k < punctuations.Length; k++)
                        {
                            if (LastSentence[i].Contains(punctuations[k]))
                                LastSentence[i] = LastSentence[i].Replace(Convert.ToString(punctuations[k]), string.Empty);
                        }
                    }
                    //extracting punctuation in words

                    //Converting pronouns..
                    for (int i = 0; i < LastSentence.Length; i++)
                    {
                        if (LastSentence[i] == "I")
                        {
                            LastSentence[i] = "You";
                        }
                        else if (LastSentence[i] == "My")
                        {
                            LastSentence[i] = "Your";
                        }
                        else if (LastSentence[i] == "my")
                        {
                            LastSentence[i] = "your";
                        }
                        else if (LastSentence[i] == "Myself")
                        {
                            LastSentence[i] = "Yourself";
                        }
                        else if (LastSentence[i] == "myself")
                        {
                            LastSentence[i] = "yourself";
                        }
                        else if(LastSentence[i].ToLower() == "myself")
                        {
                            LastSentence[i] = "yourself";
                        }
                        else if (LastSentence[i] == "am")
                        {
                            LastSentence[i] = "are";
                        }
                        else if (LastSentence[i] == "Am")
                        {
                            LastSentence[i] = "Are";
                        }
                        else if(LastSentence[i].ToLower() == "am")
                        {
                            LastSentence[i] = "are";
                        }
                        else if (LastSentence[i] == "Me")
                        {
                            LastSentence[i] = "You";
                        }
                        else if (LastSentence[i] == "me")
                        {
                            LastSentence[i] = "you";
                        }
                        else if (LastSentence[i].ToLower() == "me")
                        {
                            LastSentence[i] = "you";
                        }
                    }
                    //Converting pronouns..

                    //Creating the program message for Rule 4
                    for (int i = 0; i < LastSentence.Length; i++)
                    {
                        ProgramOutput = ProgramOutput + LastSentence[i] + " ";
                    }
                    string ProgramMessage1 = "You say" + ProgramOutput.ToLower() +"?";
                    string ProgramMessage2 = ProgramOutput + "," +" right?";
                    string[] ProgramMessages = { ProgramMessage1, ProgramMessage2 };
                    Console.Write("Program: ");
                    Console.WriteLine(ProgramMessages[RandomForRule4]);
                    //Creating the program message for Rule 4

                }
                /////      RULE 4 IMPLEMENTATION    \\\\\\\

            } while (userInput != "I have to go now."); //-----> If user's input is this, program will end.
            //do-while loop for continuous conversation

            //Program's last message..
            Console.Write("Program: ");
            Console.WriteLine("Goodbye.");
            //Program's last message..
            Console.ReadLine();
        }
    }
}
    
