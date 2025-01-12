import os
import cv2
import numpy as np

config_file = 'yolov4.cfg'
weights_file = 'yolov4.weights'
classes_file = 'coco.names'

with open(classes_file, 'r') as f:
    classes = [line.strip() for line in f.readlines()]

net = cv2.dnn.readNetFromDarknet(config_file, weights_file)
net.setPreferableBackend(cv2.dnn.DNN_BACKEND_OPENCV)
net.setPreferableTarget(cv2.dnn.DNN_TARGET_CPU)

allowed_classes = ["horse", "cow"]

image_dir = "images"
images = [os.path.join(image_dir, f) for f in os.listdir(image_dir) if f.endswith(".jpg")]

confidenceThresholds = [0.9, 0.7, 0.5, 0.3]
nms_threshold = 0.4

ground_truth = {
    '01.jpg': [('horse', 50, 50, 100, 100)],
    '02.jpg': [('cow', 60, 60, 120, 120)]
}

def calculate_iou(box1, box2):
    x1, y1, w1, h1 = box1
    x2, y2, w2, h2 = box2

    xi1 = max(x1, x2)
    yi1 = max(y1, y2)
    xi2 = min(x1 + w1, x2 + w2)
    yi2 = min(y1 + h1, y2 + h2)

    inter_area = max(0, xi2 - xi1) * max(0, yi2 - yi1)
    box1_area = w1 * h1
    box2_area = w2 * h2

    union_area = box1_area + box2_area - inter_area
    return inter_area / union_area if union_area > 0 else 0

print("Image         | Confidence  | TP| FP| FN |Precision| Recall")
print("-" * 60)

for image_file in images:
    image = cv2.imread(image_file)
    height, width = image.shape[:2]

    blob = cv2.dnn.blobFromImage(image, 1 / 255.0, (416, 416), swapRB=True, crop=False)
    net.setInput(blob)
    ln = net.getLayerNames()
    ln = [ln[i - 1] for i in net.getUnconnectedOutLayers()]

    for th in confidenceThresholds:
        class_ids = []
        confidences = []
        boxes = []

        outs = net.forward(ln)

        for out in outs:
            for detection in out:
                scores = detection[5:]
                class_id = np.argmax(scores)
                confidence = scores[class_id]

                if confidence > th and classes[class_id] in allowed_classes:
                    center_x = int(detection[0] * width)
                    center_y = int(detection[1] * height)
                    w = int(detection[2] * width)
                    h = int(detection[3] * height)
                    x = int(center_x - w / 2)
                    y = int(center_y - h / 2)

                    class_ids.append(class_id)
                    confidences.append(float(confidence))
                    boxes.append([x, y, w, h])

        indices = cv2.dnn.NMSBoxes(boxes, confidences, th, nms_threshold)

        detected_objects = []
        if len(indices) > 0:
            for i in indices.flatten():
                x, y, w, h = boxes[i]
                label = str(classes[class_ids[i]])
                detected_objects.append((label, x, y, w, h))

        true_objects = ground_truth.get(image_file, [])
        tp = 0
        fp = 0
        fn = 0

        matched = set()
        for detected in detected_objects:
            detected_label, detected_box = detected[0], detected[1:]
            match_found = False

            for i, (true_label, *true_box) in enumerate(true_objects):
                if i not in matched and detected_label == true_label and calculate_iou(detected_box, true_box) > 0.5:
                    tp += 1
                    matched.add(i)
                    match_found = True
                    break

            if not match_found:
                fp += 1

        fn = len(true_objects) - len(matched)

        precision = tp / (tp + fp) if (tp + fp) > 0 else 0
        recall = tp / (tp + fn) if (tp + fn) > 0 else 0

        print(f"{image_file} | {th:.1f}         | {tp} | {fp} | {fn} | {precision:.3f}    | {recall:.3f}")