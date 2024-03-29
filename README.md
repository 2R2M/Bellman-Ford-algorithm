# Алгоритм Беллмана-Форда 
## Описание алгоритма
Алгоритм Беллмана-Форда является классическим алгоритмом поиска кратчайших путей в графе. Он способен работать с графами, содержащими ребра с отрицательными весами, в отличие от других алгоритмов, таких как Дейкстра. Он основан на принципе динамического программирования.
Основная идея алгоритма состоит в том, чтобы постепенно уточнять предполагаемые расстояния от начальной вершины до всех остальных вершин. Алгоритм проходит по всем ребрам графа V-1 раз, где V - количество вершин. На каждой итерации алгоритма он обновляет расстояние до каждой вершины, используя информацию о ребре и текущем предполагаемом расстоянии. После завершения всех итераций алгоритма можно проверить наличие отрицательных циклов.
## Описание проекта
Данный проект предоставляет реализацию алгоритма Беллмана-Форда с использованием визуального интерфейса. Он позволяет визуализировать графическое представление графа и запускать алгоритм для поиска кратчайших путей.
