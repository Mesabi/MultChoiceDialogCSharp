==============================
MULTIPLE-CHOICE DIALOG PROJECT
==============================
By Mesabi (North Seelinger)
Published: 8-20-22
Used for CSC 330 Concordia St. Paul
==============================
Purpose:
This project is an external DSL to be used for the creation of basic branching / multiple choice dialog conversations for use in Unity and Godot.
Currently, this is a .net console app for testing these conversations. 
==============================
Basics: 
A conversation is made up of DialogNodes and DialogOptions going downwards on a .txt document.
There are 2 sublclasses to DialogNode: DialogChoice and DialogSingle

These allow for the construction of conversations that can be looped back, or branch off into seperate trees. 

A basic conversation looks something like this:

0 | We are beginning a test conversation | Mesabi | 1
1 | I will now ask a question. | Mesabi | 2
2 | What would you like to do? | Mesabi | ?
? | End Conversation | 4
? | Restart at 1 | 1
? | Restart at 0| 0
4 | END | Mesabi | -1
END

To break this down.
Lines 0,1,4 are each DialogSingle objects. They are declared like this:
<pointer>|<text>|<actor>|<GoTo>

Pointer: Identifies where in the conversation the system is. These must be unique.
Text: Output as the conversation's text element. 
Actor: A secondary text field for more information, generally should be used to denote speaker. 
GoTo: Which pointer the DialogSingle will send the system to next

Line 2 is a DialogChoice Object, and it is followed by 3 DialogOption objects. Declaration:
<pointer>|<text>|<actor>| ?
? | <text> | <GoTo>
(Repeat up to 7 more times)

In DialogChoice, there is no GoTo, simply add a "?"
Follow this with the "?" in place of the pointer, to create DialogOptions. They do not have Actor fields. 

===========================

Important Info:
The '|' symbol is a reserve symbol, and cannot be used anywhere in a conversation. It is used as regex in the lexer. 
A GoTo of -1 immediately ends the conversation. 
END on the last line ends the file. 
A conversation must ALWAYS start at '0'

===========================
Advanced:
The Program will NOT recognize permanent loops, or errors in your GoTo statements.
The program does not recognize duplicate pointers. 
If there is ANY issue, it will still construct the Tree, but will return the first line to throw it off. 





