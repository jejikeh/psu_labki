#!/bin/bash

# Run Meson build
echo "Running Meson build..."
meson build

# Build server
echo "Building server..."
ninja -C build server

# Build client
echo "Building client..."
ninja -C build client

echo "Build process completed."