This is a psychotherapist program that continuously reads a text from the user and then gives a response based on some rules and keywords in the text until the user enters "I have to go now.".

This problem falls under the domain of Artificial Intelligence. The program will simulate the behavior of a psychotherapist. The user (patient) starts the conversation by writing a text. Then the computer (psychotherapist) asks a question related to the text. 

The program  interacts with user in simple English language and simulate a conversation as a type of chatbot.

The program ignores 14 punctuation marks, which are stored in the array punctuations, such as points, comma, semi comma, single and double quotation marks, question marks, exclamation points, dash and brackets.
 
char[] punctuations = {., ,, ;, ’,”, ?, !, -, {, }, (, ), [, ]}

Program works well, when the user uses uppercase or lower case letters, or mixes them up.
