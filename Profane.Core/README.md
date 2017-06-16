# Profane
Profane was written as a sample code / proof of concept of a language that is 

* ANTLR4 lexed and parsed
* Transpiled to C#
* Fed into roslyn C# script engine for execution

This comes with a very simple and limited grammar so the capabilities are pretty limited too. Please look at the Profane.g4 file under Profane.Core project for better understanding. 

Sample code in Profane:

```
derp a = 20 :) #Initialization

# basic if-else 
a > 2 ???
yep -> 
    a = 5 :)
kbye

# print
dump a :)
```
The Profane project comes with a [nancy](https://github.com/NancyFx/Nancy) module that accepts code as plain text in a HTTP POST and compiles it. Was built to put up a simple test code page in mind. 
