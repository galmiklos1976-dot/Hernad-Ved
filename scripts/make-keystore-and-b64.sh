#!/bin/bash
set -e

echo "This script creates an Android keystore (interactive) and outputs a base64-encoded file for Codemagic."

read -p "Keystore filename [my-release-key.jks]: " KEYSTORE
KEYSTORE=${KEYSTORE:-my-release-key.jks}
read -p "Alias [my-key-alias]: " ALIAS
ALIAS=${ALIAS:-my-key-alias}

# Prompt for passwords
read -s -p "Key password: " KEYPASS; echo
read -s -p "Store password (press enter to use same as key): " STOREPASS; echo
STOREPASS=${STOREPASS:-$KEYPASS}

# Create keystore using keytool (this will prompt for Distinguished Name if not provided)
keytool -genkeypair -v -keystore "$KEYSTORE" -alias "$ALIAS" -keyalg RSA -keysize 2048 -validity 10000 -storepass "$STOREPASS" -keypass "$KEYPASS" -dname "CN=Hernad Ved, OU=Dev, O=Company, L=City, ST=State, C=HU"

echo "Keystore created: $KEYSTORE"

# Encode to base64 in one line (for Codemagic)
if command -v base64 >/dev/null 2>&1; then
  base64 -w0 "$KEYSTORE" > "$KEYSTORE.b64"
  echo "Base64 file: $KEYSTORE.b64"
  echo "---- Base64 content start ----"
  cat "$KEYSTORE.b64"
  echo "---- Base64 content end ----"
else
  echo "base64 command not found. If on macOS without -w, use: base64 $KEYSTORE > $KEYSTORE.b64"
fi