class Employee:
    def __init__(self, name: str, age: int, salary:float):
        self.name = name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"{self.name}, Wiek: {self.age}, Pensja: {self.salary} PLN"
