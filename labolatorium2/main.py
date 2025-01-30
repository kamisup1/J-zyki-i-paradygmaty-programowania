#zadanie1

tekst = """
Ludzie twardo stąpający po ziemi nie chcą wierzyć, że przed półwieczem wydarzyło się dla Ziemi coś tak niezwykłego. Otóż pół wieku temu człowiek postawił nogę na Księżycu. Kiedy wieczorem spoglądamy na rozgwieżdżone niebo z sierpem księżyca, trudno wręcz przypuszczać, że można po nim chodzić.

W naszej wyobraźni tylko legendarny Mistrz Twardowski, zwany polskim Faustem, wylądował tam na kogucie i już pozostał. Poświęcono mu bez mała trzydzieści utworów, filmów, performance’ów, a nawet grę komputerową. Na Księżyc latali bohaterowie książek i filmów science fiction. O próbie kolonizacji ziemskiego satelity traktuje trylogia Jerzego Żuławskiego „Na srebrnym globie” sprzed ponad stu lat. Po więcej niż półwieczu jego stryjeczny wnuk, Andrzej Żuławski nakręcił film pod tym samym tytułem. A niespełna dwadzieścia lat wcześniej wielki krok dla ludzkości zrobił Neil Armstrong, stawiając stopę na Księżycu. Trzej astronauci polecieli statkiem Apollo 11 w roku 1969, by spełnić marzenie ludzkości. Znamy wszak wszyscy minitrylogię „Wokół Księżyca” pioniera prozy fantastycznonaukowej, Juliusza Verne’a. Dokładnie w stulecie pierwodruku powieści marzenie Ziemian się ziściło. Kilkadziesiąt lat po Vernie francuski reżyser, Georges Méliès przedstawił wyobrażenie Księżyca w filmie „Podróż na Księżyc”. Ale wtedy taka podróż była jeszcze mirażem i mrzonką.

Hołd odważnym kosmonautom oddali twórcy filmu „Apollo 13”, w którym usłyszeliśmy słynny tekst: „Houston, mamy problem!”. Armstrong doczekał się filmowej biografii w filmie „Pierwszy człowiek”. „Ukryte działania” to z kolei obraz o genialnych czarnoskórych matematyczkach w NASA. Pokazuje kobiety, które swymi obliczeniami umożliwiły pierwsze loty w kosmos, a swoją wiedzą i postawą zrobiły wiele dla równouprawnienia płciowego i rasowego w USA.

Zatem reasumując: kiedy para młodych mieszkańców Ziemi siedzi na rozgrzanej letnim słońcem ziemi i patrzy sobie w oczy i na błyszczący srebrny księżyc, niech w swych źrenicach szuka liczb parzystych i niewymiernych oraz matematycznych działań różniczkowych. A dzięki temu być może w podróż poślubną polecą na Księżyc.
"""

# Lista stop words
stop_words = {"i", "a", "to", "w", "po", "na", "z", "ze", "by", "o", "do",
              "kiedy", "że"}



def analiza_tekstu(tekst):
    akapity = tekst.split('\n')
    zdania = [zdanie.strip() for zdanie in tekst.split('.') if zdanie]
    slowa = [slowo.strip(',.!?') for slowo in tekst.split() if slowo.strip(',.!?')]

    liczba_slow = len(slowa)
    liczba_zdan = len(zdania)
    liczba_akapity = len(akapity)

    slowa_bez_stop_words = [slowo.lower() for slowo in slowa if slowo.lower() not in stop_words]
    slowa_wystepujace = {slowo: slowa_bez_stop_words.count(slowo) for slowo in set(slowa_bez_stop_words)}
    najczestsze_slowo = max(slowa_wystepujace, key=slowa_wystepujace.get)

    def transformacja(slowo):
        return slowo[::-1] if slowo.lower().startswith('a') else slowo

    transformacja_slow = [(slowo, transformacja(slowo)) for slowo in slowa if slowo.lower().startswith('a')]

    return {
        "liczba_slow": liczba_slow,
        "liczba_zdan": liczba_zdan,
        "liczba_akapity": liczba_akapity,
        "najczestsze_slowo": najczestsze_slowo,
        "transformacja_slow": transformacja_slow
    }

wyniki = analiza_tekstu(tekst)
print("zadanie 1 ", wyniki)



#zadanie 2

import numpy as np

def walidacja_operacji(operacja, macierz1, macierz2=None):
    if operacja == "add" and macierz1.shape != macierz2.shape:
        return False
    if operacja == "multiply" and macierz1.shape[1] != macierz2.shape[0]:
        return False
    return True

def wykonaj_operacje(operacja, macierz1, macierz2=None):
    if operacja == "add":
        return macierz1 + macierz2
    elif operacja == "multiply":
        return np.dot(macierz1, macierz2)
    elif operacja == "transpose":
        return np.transpose(macierz1)
    else:
        raise ValueError("Nieznana operacja")

macierz1 = np.array([[1, 2], [3, 4]])
macierz2 = np.array([[5, 6], [7, 8]])

print("\nzadanie 2")

operacja = "add"
if walidacja_operacji(operacja, macierz1, macierz2):
    wynik = wykonaj_operacje(operacja, macierz1, macierz2)
    print("\nwynik operacji add: ",wynik)
else:
    print("Operacja jest niepoprawna!")

operacja = "multiply"
if walidacja_operacji(operacja, macierz1, macierz2):
    wynik = wykonaj_operacje(operacja, macierz1, macierz2)
    print("\nwynik operacji multiply: ",wynik)
else:
    print("Operacja jest niepoprawna!")



#zadanie 3

dane = [3, "hello", (1, 2, 3), 10, "world", (4, 5), "a", "banana", 78]
def analiza_danych(dane):
    liczby = list(filter(lambda x: isinstance(x, (int, float)), dane))
    napisy = list(filter(lambda x: isinstance(x, str), dane))
    krotki = list(filter(lambda x: isinstance(x, tuple), dane))

    max_liczba = max(liczby, default=None)
    najdluzszy_napis = max(napisy, key=len, default=None)
    najwieksza_krotka = max(krotki, key=len, default=None)

    return {
        "najwieksza liczba": max_liczba,
        "najdluzszy napis": najdluzszy_napis,
        "najwieksza krotka": najwieksza_krotka
    }


wyniki = analiza_danych(dane)
print("\nzadanie 3", wyniki)



#zadanie4

import numpy as np
from functools import reduce

macierze = [
    np.array([[1, 2], [3, 4]]),
    np.array([[5, 6], [7, 8]]),
    np.array([[9, 10], [11, 12]])
]

def wykonaj_operacje_macierz(macierz, operacja):
    if operacja == "suma":
        return reduce(lambda x, y: x + y, macierz)
    elif operacja == "iloczyn":
        return reduce(lambda x, y: np.dot(x, y), macierz)
    else:
        print("Nieznana operacja!")
        return None



def main():
    print("\nZadanie 4 \nDostępne operacje: suma, iloczyn")

    operacja = input("Wybierz operację (suma/iloczyn): ").strip().lower()

    wynik = wykonaj_operacje_macierz(macierze, operacja)

    if wynik is not None:
        print(f"Wynik operacji {operacja}:\n{wynik}")

if __name__ == "__main__":
    main()


#zadanie5

def generuj_i_wykonaj_kod(szablon, dane):
    try:
        local_vars = dane.copy()

        exec(szablon, {}, local_vars)

        return local_vars.get('wynik', None)

    except Exception as e:
        print(f"Nie udało się wykonać kodu: {e}")
        return None

szablon = """
wynik = a + b
"""

dane = {'a': 5, 'b': 10}

wynik = generuj_i_wykonaj_kod(szablon, dane)

print(f"\nZadanie 5 \nWynik operacji: {wynik}")