import os
import requests

# Set or replace these values
api_key = "0AJDNdG6VqN24iGh05YICQY4s28m6yJx"
body = {
  "input" : "dlb://in/example/my_explosion_sound.wav",
  "output" : "dlb://in/example/my_betterexplosion_sound.wav"
}

url = "https://api.dolby.com/media/enhance"
headers = {
  "x-api-key": "0AJDNdG6VqN24iGh05YICQY4s28m6yJx",
  "Content-Type": "application/json",
  "Accept": "application/json"
}

response = requests.post(url, json=body, headers=headers)
response.raise_for_status()
print(response.json())
