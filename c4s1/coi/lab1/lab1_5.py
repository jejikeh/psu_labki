import cv2
import numpy as np

image = cv2.imread('image_5.png')

if image is None:
    print("Error: Image could not be read")
    exit()

angle = 45

(height, width) = image.shape[:2]

center = (width // 2, height // 2)

rotation_matrix = cv2.getRotationMatrix2D(center, angle, 1.0)
rotated = cv2.warpAffine(image, rotation_matrix, (width, height))

alpha = 1.5
beta = 0

final = cv2.convertScaleAbs(rotated, alpha=alpha, beta=beta)

font = cv2.FONT_HERSHEY_COMPLEX
cv2.putText(final, 'Поворот, линейное улучшение контраста', (10, 30), font, 0.7, (0, 255, 255), 1, cv2.LINE_4)
cv2.putText(final, 'Автор - Артем Герасимюк, 21-ИТ-2', (10, 50), font, 0.7, (0, 255, 255), 1, cv2.LINE_8)

cv2.imshow('Original Image', image)
cv2.imshow('Rotated and Contrast Enhanced', final)
cv2.waitKey(0)
cv2.destroyAllWindows()

cv2.imwrite('output_image_5.jpg', final)