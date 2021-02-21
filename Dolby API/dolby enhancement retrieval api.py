import os
import shutil
import requests

output_path = "C:\\Users\\Squishy3000\\Downloads\\better explosion.wav"

url = "https://api.dolby.com/media/output"
headers = {
    "x-api-key": "0AJDNdG6VqN24iGh05YICQY4s28m6yJx",
    "Content-Type": "application/json",
    "Accept": "application/json",
}

args = {
    "url": "dlb://in/example/my_betterexplosion_sound.wav",
}

with requests.get(url, params=args, headers=headers, stream=True) as response:
    response.raise_for_status()
    response.raw.decode_content = True
    print("Downloading from {0} into {1}".format(response.url, output_path))
    with open(output_path, "wb") as output_file:
        shutil.copyfileobj(response.raw, output_file)
