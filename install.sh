#!/bin/bash

# Variables
APP_URL=https://github.com/theophileTheKing/FastNotes/releases/download/0.1.0/FastNotes
APP_NAME="FastNotes"
EXECUTABLE_DIR=/usr/local/bin

# Download the app
echo "Downloading $EXECUTABLE_NAME..."
curl -L $APP_URL -o $EXECUTABLE_DIR/$APP_NAME

# Make the app executable
echo "Making $APP_NAME executable..."
chmod +x $EXECUTABLE_DIR/$APP_NAME

# Confirm installation
echo "$APP_NAME installed successfully !"
echo "Type 'FastNotes' to start the app"
