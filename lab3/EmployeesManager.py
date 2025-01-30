class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self,employee):
        self.employees.append(employee)

    def show_employees(self):
        if not self.employees:
            print("Brak pracowników w systemie")
        else:
            for emp in self.employees:
                print(emp)

    def remove_by_age (self, minage, maxage):
        self.eployees = [emp for emp in self.employees
                         if not (minage <= emp.age <= maxage)]
        print(f"Usunieto pracownikow w wieku {minage} - {maxage}")


    def find_employee(self, name):
        for emp in self.employees:
            if emp.name == name:
                return emp
        return None

    def update_salary(self, name, new_salary):
        emp = self.find_employee(name)
        if emp:
            emp.salary = new_salary
            print(f"Wynagrodzenie proacownika {name} "
                  f"zsoatlo zaktualizowane do {new_salary}")
        else:
            print("nie znaleziono pracownika")



