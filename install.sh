#!/bin/bash

# Variables
MAIN_URL=https://github.com/theophileTheKing/FastNotes/releases/download/0.1.0/FastNotes
MAIN_NAME="FastNotes"
EXECUTABLE_DIR=/opt/fastNotes

SCRIPT_URL=https://raw.githubusercontent.com/theophileTheKing/FastNotes/refs/heads/main/fn
SCRIPT_NAME="fn"
SCRIPT_DIR=/usr/local/bin

# Download the app
echo "Downloading $MAIN_NAME..."
curl -L $MAIN_URL -o $EXECUTABLE_DIR/$MAIN_NAME
curl -L $SCRIPT_URL -o $SCRIPT_DIR/$SCRIPT_NAME

# Make the app executable
echo "Making $MAIN_NAME executable..."
chmod +x $EXECUTABLE_DIR/$MAIN_NAME
chmod +x $SCRIPT_DIR/$SCRIPT_NAME

# Confirm installation
echo "$MAIN_NAME installed successfully !"
echo "Type 'fn' to start the app"
