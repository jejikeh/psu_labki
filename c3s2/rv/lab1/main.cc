#include "raylib.h"
#include "raymath.h"
#include <iostream>

#define CLUSTER_COUNT 6

#define CIRCLE_RADIUS 4
#define MEAN_RADIUS (CIRCLE_RADIUS * 2)

#define MIN_X -20
#define MAX_X 20
#define LEN_X (MAX_X - MIN_X)

#define MIN_Y -20
#define MAX_Y 20
#define LEN_Y (MAX_Y - MIN_Y)

#define BORDER_ANIMATION_SPEED 1
#define BORDER_ANIMATION_OFFSET 2

#define SAMPLES_COUNT 100000

typedef struct
{
    Vector2 Position;
    float Atributes[16];
} Sample;

// Коллекция сэмплов
typedef struct
{
    Sample *samples;
    int count;
    int capacity;
} Samples;

void AppendSample(Samples *samples, Sample sample)
{
    // Если в коллекции больше нет места для новых сэмлов
    if (samples->count == samples->capacity)
    {
        // Увеличиваем максимальную вместимость + обработка special case когда в коллекции еще нет элементов
        samples->capacity = samples->capacity == 0 ? 1 : samples->capacity * 2;

        // Выделения большего буфера памяти с сохранением всех семлов благодаря realloc
        samples->samples = (Sample *)realloc(samples->samples, samples->capacity * sizeof(Sample));
    }

    samples->samples[samples->count++] = sample;
}

// Случайное дробное число от 0 до RAND_MAX(2147483647)
static inline float RandomFloat()
{
    return (float)rand() / (float)RAND_MAX;
}

// Генерация рандомного датасета вокруг окружности
static void GenerateSet(Vector2 center, float radius, int count, Samples *samples)
{
    for (int i = 0; i < count; i++)
    {
        // Случайный угол
        float angle = RandomFloat() * 2 * PI;

        // Случайная величина
        float magnitude = RandomFloat();

        // Сэмпл
        Sample sample = {.Position.x = center.x + cosf(angle) * magnitude * radius,
                         .Position.y = center.y + sinf(angle) * magnitude * radius};

        for (int j = 0; j < 16; j++)
        {
            sample.Atributes[j] = RandomFloat();
        }

        // Добавление нового семпла в коллекцию
        AppendSample(samples, sample);
    }
}

Vector2 ProjectSampleToScreenCoordinates(Vector2 sample)
{
    float normalizedX = (sample.x - MIN_X) / (LEN_X);
    float normalizedY = (sample.y - MIN_Y) / (LEN_Y);

    return Vector2{.x = normalizedX * GetScreenWidth(), .y = GetScreenHeight() - normalizedY * GetScreenHeight()};
}

static Samples set = {};
static Samples Clusters[CLUSTER_COUNT] = {};
static Sample Means[CLUSTER_COUNT] = {};

static Color Colors[] = {
    YELLOW, PINK, LIME, SKYBLUE, PURPLE, BEIGE, BROWN,
};

static int ColorsCount = sizeof(Colors) / sizeof(Color);

static void InitizlizeNewState()
{
    set.count = 0;

    int iterations = rand() % 10 + 10;
    for (int i = 0; i < iterations; i++)
    {
        // Mouse dataset
        // GenerateSet(Vector2{.x = 0, .y = 0}, 10, SAMPLES_COUNT / iterations / 3, &set);
        // GenerateSet(Vector2{.x = MIN_X / 2, .y = MAX_Y / 2}, 5, SAMPLES_COUNT / iterations / 3, &set);
        // GenerateSet(Vector2{.x = MAX_X / 2, .y = MAX_Y / 2}, 5, SAMPLES_COUNT / iterations / 3, &set);

        // Pure Random dataset
        GenerateSet(Vector2{.x = RandomFloat() * (LEN_X) + MIN_X, .y = RandomFloat() * (LEN_Y) + MIN_Y}, 10,
                    SAMPLES_COUNT / iterations, &set);
    }

    // Рандомная инитиализация Means
    for (int i = 0; i < CLUSTER_COUNT; i++)
    {
        Means[i].Position.x = Lerp(MIN_X, MAX_X, RandomFloat());
        Means[i].Position.y = Lerp(MIN_Y, MAX_Y, RandomFloat());
    }
}

static void ReclusterState()
{
    // Очистка кластеров перед новой инитиализацией
    for (int i = 0; i < CLUSTER_COUNT; i++)
    {
        Clusters[i].count = 0;
    }

    // Кластеризация
    for (int i = 0; i < set.count; i++)
    {
        Sample a = set.samples[i];

        // Индекс ближайшей к центройду точки
        int closest = -1;
        float closestDistance = __FLT_MAX__;

        // Поиск ближайшей к центройду
        for (int j = 0; j < CLUSTER_COUNT; j++)
        {
            Sample b = Means[j];

            float distance = Vector2LengthSqr(Vector2Subtract(a.Position, b.Position));

            if (distance < closestDistance)
            {
                closest = j;
                closestDistance = distance;
            }
        }

        AppendSample(&Clusters[closest], a);
    }
}

static bool UpdateMeans()
{
    bool isChanged = false;

    for (int i = 0; i < CLUSTER_COUNT; i++)
    {
        // Если коллекция пустая, то инициализируем случайным образом заново
        if (Clusters[i].count == 0)
        {
            Means[i].Position.x = Lerp(MIN_X, MAX_X, RandomFloat());
            Means[i].Position.y = Lerp(MIN_Y, MAX_Y, RandomFloat());

            continue;
        }

        Vector2 s = Vector2();

        for (int j = 0; j < Clusters[i].count; j++)
        {
            s = Vector2Add(s, Clusters[i].samples[j].Position);
        }

        s.x /= Clusters[i].count;
        s.y /= Clusters[i].count;

        if (s.x != Means[i].Position.x || s.y != Means[i].Position.y)
        {
            isChanged = true;
        }

        Means[i].Position = s;
    }

    return isChanged;
}

int main()
{
    srand(time(0));

    SetConfigFlags(FLAG_WINDOW_RESIZABLE);
    InitWindow(640, 640, "K-Means Clustering");
    SetTargetFPS(60);

    // Инициализация датасета и means
    InitizlizeNewState();

    // Рекластеризация
    ReclusterState();

    bool isChangedLastFrame = true;

    while (!WindowShouldClose())
    {
        if (isChangedLastFrame || IsKeyPressed(KEY_SPACE))
        {
            isChangedLastFrame = UpdateMeans();
            ReclusterState();
        }

        if (IsKeyPressed(KEY_R))
        {
            InitizlizeNewState();
            ReclusterState();
            isChangedLastFrame = true;
        }

        BeginDrawing();
        ClearBackground(GetColor(0x181818AA));

        for (int i = 0; i < set.count; i++)
        {
            Vector2 sample = set.samples[i].Position;

            DrawCircleV(ProjectSampleToScreenCoordinates(sample), CIRCLE_RADIUS, RED);
        }

        for (int i = 0; i < CLUSTER_COUNT; i++)
        {
            Color color = Colors[i % ColorsCount];
            for (int j = 0; j < Clusters[i].count; j++)
            {
                Vector2 sample = Clusters[i].samples[j].Position;

                DrawCircleV(ProjectSampleToScreenCoordinates(sample), CIRCLE_RADIUS, color);
            }

            Vector2 mean = Means[i].Position;

            // Светлая обводка
            DrawCircleV(ProjectSampleToScreenCoordinates(mean),
                        MEAN_RADIUS + (2) + abs(BORDER_ANIMATION_OFFSET * sinf(GetTime() * BORDER_ANIMATION_SPEED)),
                        WHITE);

            // Черная обводка
            DrawCircleV(ProjectSampleToScreenCoordinates(mean), MEAN_RADIUS + 2, BLACK);
            DrawCircleV(ProjectSampleToScreenCoordinates(mean), MEAN_RADIUS, color);
        }

        DrawText("R - New state", 10, 10, 20, WHITE);
        DrawText(TextFormat("Clusters: %i", CLUSTER_COUNT), 10, 40, 20, WHITE);
        DrawText(TextFormat("Samples: %i", set.count), 10, 70, 20, WHITE);

        EndDrawing();
    }

    CloseWindow();

    return 0;
}