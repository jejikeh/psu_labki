import io
import paho.mqtt.publish as publish
from PIL import Image

import requests
import shutil

category = 'nature'
api_url = 'https://api.api-ninjas.com/v1/randomimage?category={}'.format(category)
response = requests.get(api_url, headers={'X-Api-Key': 'VsCxPWFYd80ouFBQqdSLOQ==zcx6kJ6hu0fSyBSt', 'Accept': 'image/jpg'}, stream=True)
if response.status_code == requests.codes.ok:
    with open('img.jpg', 'wb') as out_file:
        shutil.copyfileobj(response.raw, out_file)
else:
    print("Error:", response.status_code, response.text)


# Load an image
image = Image.open('img.jpg')

# Convert the image to a byte array
byte_array = io.BytesIO()
image.save(byte_array, format='JPEG')
byte_array = byte_array.getvalue()

publish.single("minor/jejikeh/lab2", byte_array, hostname="mqtt.eclipseprojects.io")