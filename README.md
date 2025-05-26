# MiniShell
 A simple Unix-like command-line shell built in C#.

## Features

- `pwd` – Print the current working directory  
- `cd [dir]` – Change the current directory  
- `ls [dir]` – List files in the directory
- `mkdir [name]` – Create a new directory  
- `touch [file]` – Create an empty file  
- `echo [text]` – Print arguments to standard output  
- `rm [file]` – Remove a file  
- `cat [file]` – Display contents of a file
-  `exit` – Exit the shell  
- Command parsing and execution with support for built-in and external commands  
- Extensible command system via `IBuiltInCommand` interface  

## Getting Started

1. Clone the repository  
2. Install mono
3. In the root directory of the project:
```bash
mcs -out:MiniShell.exe -recurse:'*.cs'
mono MiniShell.exe
```