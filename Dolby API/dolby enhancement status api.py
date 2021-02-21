import os
import requests

url = "https://api.dolby.com/media/enhance"
headers = {
  "x-api-key": "0AJDNdG6VqN24iGh05YICQY4s28m6yJx",
  "Content-Type": "application/json",
  "Accept": "application/json"
}

params = {
  "job_id": "142e6dd9-cc11-4d0c-8d0a-dceee973a6ea"
}

response = requests.get(url, params=params, headers=headers)
response.raise_for_status()
print(response.json())
