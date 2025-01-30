from Employee import Employee
from EmployeesManager import EmployeesManager

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def menu(self):
        while True:
            print("Employees System")
            print("1. dodaj pracownika")
            print("2. wyswietl wsztkich pracownikow")
            print("3. usun pracownikow w okreslonym przedziale wiekowym")
            print("4. zmien wynagrodzenie pracownika")
            print("5. zakoncz")

            choice = input("wybierz opcje")

            if choice == "1":
                name = input("podaj imie i nazwiko:")
                age = int(input("podaj wiek"))
                salary = float(input("podaj wynagrodzenie"))
                self.manager.add_employee(Employee(name, age,salary))
                print("dodano pracownika")

            elif choice == "2":
                self.manager.show_employees()

            elif choice == "3":
                minage = int(input("Podaj minimalny wiek"))
                maxage = int(input("podaj maksymalny wiek"))
                self.manager.remove_by_age(minage, maxage)

            elif choice == "4":
                name = input("podaj imie i nazwisko proacownika")
                new_salary = int (input("podaj nowa wypalte pracownika"))
                self.manager.update_salary(name, new_salary)

            elif choice == "5":
                print("zamykanie sytemu")
                break


            else:
                print("nie ma takigo polecenia")