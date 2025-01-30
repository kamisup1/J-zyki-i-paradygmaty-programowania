
#zadanie1

wagi = [5, 10, 7, 8, 6, 4, 3]
max_waga = 15


def podzial_paczek(wagi, max_waga):
    wagi.sort(reverse=True)
    kursy = []

    while wagi:
        kurs = []
        suma = 0
        i = 0
        while i < len(wagi):
            if suma + wagi[i] <= max_waga:
                suma += wagi[i]
                kurs.append(wagi.pop(i))
            else:
                i += 1
        kursy.append(kurs)

    return len(kursy), kursy


liczba_kursow, kursy = podzial_paczek(wagi, max_waga)
print("\n Zadanie 1: Minimalna liczba kursów:", liczba_kursow)
print("Podział paczek:", kursy)


#zadanie2

from collections import deque

graf = {
    'A': ['B', 'C'],
    'B': ['A', 'D', 'E'],
    'C': ['A', 'F'],
    'D': ['B'],
    'E': ['B', 'F'],
    'F': ['C', 'E']
}
start, koniec = 'A', 'F'


def bfs(graf, start, koniec):
    kolejka = deque([(start, [start])])

    while kolejka:
        wierzcholek, sciezka = kolejka.popleft()
        for sasiad in graf[wierzcholek]:
            if sasiad == koniec:
                return sciezka + [sasiad]
            if sasiad not in sciezka:
                kolejka.append((sasiad, sciezka + [sasiad]))


sciezka = bfs(graf, start, koniec)
print("\nZadanie 2: Najkrótsza ścieżka:", sciezka)



#zadanie3
from functools import reduce

#lista zadan (czas wykonania, nagroda)
zadania = [(3, 10), (1, 5), (2, 7), (5, 20), (4, 15)]

#proceduralne
def optymalizacja_proceduralna(zadania):
    zadania.sort()
    czas = 0
    suma_czasow = 0
    kolejnosc = []

    for t, n in zadania:
        czas += t
        suma_czasow += czas
        kolejnosc.append((t, n))

    return kolejnosc, suma_czasow

#funkcyjne
def optymalizacja_funkcyjna(zadania):
    zadania = sorted(zadania)
    kolejnosc = list(map(lambda x: x, zadania))
    suma_czasow = reduce(lambda acc, z: (acc[0] + z[0], acc[1] + acc[0] + z[0]), zadania, (0, 0))[1]

    return kolejnosc, suma_czasow


kolejnosc_proc, czas_proc = optymalizacja_proceduralna(zadania)
kolejnosc_func, czas_func = optymalizacja_funkcyjna(zadania)


print("\nZadanie 3: Optymalizacja zadań")
print("proceduralnie: Kolejność zadan:", kolejnosc_proc, "Czas oczekiwania:", czas_proc)
print("funkcyjnie: Kolejność zadań:", kolejnosc_func, "Czas oczekiwania:", czas_func)



#zadanie4

pojemnosc_plecaka = 7
przedmioty = [(2, 10), (3, 15), (4, 20), (5, 25)]  #(waga, wartość)


#proceduralne
def plecak_proceduralny(pojemnosc, przedmioty):
    n = len(przedmioty)
    dp = [[0] * (pojemnosc + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        waga, wartosc = przedmioty[i - 1]
        for j in range(pojemnosc + 1):
            if waga > j:
                dp[i][j] = dp[i - 1][j]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i - 1][j - waga] + wartosc)


    wybrane = []
    j = pojemnosc
    for i in range(n, 0, -1):
        if dp[i][j] != dp[i - 1][j]:
            wybrane.append(przedmioty[i - 1])
            j -= przedmioty[i - 1][0]

    return dp[n][pojemnosc], wybrane


#funkcyjna
def plecak_funkcyjny(pojemnosc, przedmioty):
    if not przedmioty or pojemnosc == 0:
        return 0, []

    pierwsza_waga, pierwsza_wartosc = przedmioty[0]
    pozostale = przedmioty[1:]


    wartosc_bez, przedmioty_bez = plecak_funkcyjny(pojemnosc, pozostale)

    if pierwsza_waga > pojemnosc:
        return wartosc_bez, przedmioty_bez

    wartosc_z, przedmioty_z = plecak_funkcyjny(pojemnosc - pierwsza_waga, pozostale)
    wartosc_z += pierwsza_wartosc

    return (wartosc_z, [przedmioty[0]] + przedmioty_z) \
        if wartosc_z > wartosc_bez else (wartosc_bez, przedmioty_bez)



wartosc_proc, przedmioty_proc = plecak_proceduralny(pojemnosc_plecaka, przedmioty)
wartosc_func, przedmioty_func = plecak_funkcyjny(pojemnosc_plecaka, przedmioty)

#Wyniki
print("\nZadanie 4: Problem Plecakowy")
print("proceduralna: Maksymalna wartość:", wartosc_proc, ", wybrane przedmioty:", przedmioty_proc)
print("funkcyjna: Maksymalna wartość:", wartosc_func, ", wybrane przedmioty:", przedmioty_func)



#zad5
#proceduralne
zadania = [(1, 3, 50), (2, 5, 60), (4, 6, 70), (6, 8, 30)]  # (start, koniec, nagroda)

def harmonogram(zadania):
    zadania.sort(key=lambda x: x[1])
    wybrane = []
    aktualny_czas = 0

    for start, koniec, nagroda in zadania:
        if start >= aktualny_czas:
            wybrane.append((start, koniec, nagroda))
            aktualny_czas = koniec

    return wybrane

#funkcyjne
def harmonogram_funkcyjny(zadania):

    zadania_posortowane = sorted(zadania, key=lambda x: x[1])  #(start, koniec, nagroda)

    def select_task(acc, task):
        start, koniec, nagroda = task
        if acc['last_end_time'] <= start:
            acc['selected_tasks'].append(task)
            acc['total_reward'] += nagroda
            acc['last_end_time'] = koniec
        return acc

    result = reduce(select_task, zadania_posortowane, {'last_end_time': -1, 'selected_tasks': [], 'total_reward': 0})

    return result['selected_tasks'], result['total_reward']

zadania_wybrane, nagroda = harmonogram_funkcyjny(zadania)


print("\nZadanie 5: (proceduralne) Optymalny harmonogram:", harmonogram(zadania))
print("(funkcyjne): Optymalny harmonogram:", zadania_wybrane)
print("Całkowita nagroda:", nagroda)

