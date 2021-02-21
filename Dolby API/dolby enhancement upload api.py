import os
import requests

# Set or replace these values

file_path = "C:\\Users\\Squishy3000\\Downloads\\explosion 40percent down.wav"
api_key = "0AJDNdG6VqN24iGh05YICQY4s28m6yJx"

# Declare your dlb:// location

url = "https://api.dolby.com/media/input"
headers = {
    "x-api-key": "0AJDNdG6VqN24iGh05YICQY4s28m6yJx",
    "Content-Type": "application/json",
    "Accept": "application/json",
}

body = {
    "url": "dlb://in/example/my_explosion_sound.wav",
}

response = requests.post(url, json=body, headers=headers)
response.raise_for_status()
data = response.json()
presigned_url = data["url"]

# Upload your media to the pre-signed url response

print("Uploading {0} to {1}".format(file_path, presigned_url))
with open(file_path, "rb") as input_file:
  requests.put(presigned_url, data=input_file)
