#!/bin/bash

# Variables
APP_URL=https://github.com/theophileTheKing/FastNotes/releases/download/0.1.0/FastNotes
EXECUTABLE_NAME=fn
EXECUTABLE_DIR=/usr/local/bin
MAIN_INSTALL_DIR=/opt/fastNotes
APP_NAME="FastNotes"

# Creating the folders
echo "Creating $MAIN_INSTALL_DIR..."
mkdir -p $MAIN_INSTALL_DIR

# Download the app
echo "Downloading $EXECUTABLE_NAME..."
curl -L $APP_URL -o $MAIN_INSTALL_DIR

# Copy the executable
echo "Copying $EXECUTABLE_NAME to $EXECUTABLE_DIR..."
cp $EXECUTABLE_NAME $EXECUTABLE_DIR

# Make the app executable
echo "Making $APP_NAME executable..."
chmod +x $MAIN_INSTALL_DIR/$APP_NAME
chmod +x $EXECUTABLE_DIR/$EXECUTABLE_NAME

# Confirm installation
echo "$APP_NAME installed successfully !"
echo "Type 'fn' to start the app"
