Make the colors changeable from config file or CLI

# Next TODOs

- make a real executable out of this program

  - installer file

- Debug

  - secure the "fastNote <title> <content>" syntax

- trash for deleted notes

  - 'trash' command to enter the 'fastNote-trash' CLI, 'clean', 'list'; 'restore <file>'

- put number direcly after 'delete' or 'read'

# Help message

fastNote
v.1.0.3

Welcome to fastNote ! A simple CLI tool to take notes easily

Usage : fastNote [OPTIONS]
fastNote [SHORTCUTS]

Without any options : start the fastNote's CLI

[CLI OPTIONS]
quit, q - Quit the program
help, h - Show this help message and exit
clear, c - Clear the CLI

new, n - Create a new note, you will be prompted for the note's name and content
list, l - List all of your notes and give them an ID
read, r - Read a note, you can enter the note's ID or you will be prompted to enter it
delete, d - Delete a note, you can enter the note's ID or you will be prompted to enter it

version, v - Show version information
update - Check for updates and prompt you to install them

[OPTIONS]
--version, -v Show version information.
--help, -h Show this help message and exit.

[SHORTCUTS]
fastNote <note-title> : To take a note very quickly you can pass to fastNotes one or two arguments : the first argument will be taken as the title of your note, and you will be prompted to enter a content in your note.
eg : fastNote myNote

fastNote <note-title> <note-content> : To take a really quick note you can enter as a second argument the content of your note (between parenthesis for multiple words)
eg : fastNote myNote "the content of myNote"
