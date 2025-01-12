import cv2
import numpy as np

# Load the image
image = cv2.imread('image_11.png')

# Check if image was successfully loaded
if image is None:
    print("Error: Image could not be read")
    exit()

angle = 45  # degrees

(height, width) = image.shape[:2]

center = (width // 2, height // 2)

rotation_matrix = cv2.getRotationMatrix2D(center, angle, 1.0)
rotated = cv2.warpAffine(image, rotation_matrix, (width, height))

lab = cv2.cvtColor(rotated, cv2.COLOR_BGR2LAB)

l, a, b = cv2.split(lab)

clahe = cv2.createCLAHE(clipLimit=3.0, tileGridSize=(8,8))
cl = clahe.apply(l)

limg = cv2.merge((cl,a,b))

final = cv2.cvtColor(limg, cv2.COLOR_LAB2BGR)

font = cv2.FONT_HERSHEY_COMPLEX
color = (100, 255, 100)
cv2.putText(final, 'Поворот и улучшение контраста на основе эквализации гистрограмы (CLAHE)', (10, 50), font, 1.5, color, 3, cv2.LINE_4)
cv2.putText(final, 'Автор - Ланцев Евгений, 21-ИТ-1', (10, 100), font, 1.5, color, 3, cv2.LINE_8)

cv2.imshow('Original Image', image)
cv2.imshow('Rotated and Contrast Enhanced', final)
cv2.waitKey(0)
cv2.destroyAllWindows()

cv2.imwrite('output_image_11.jpg', final)