class Employee {
  constructor(firstName, lastName, salary) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.salary = salary;
  }

  add1KToSalary(){
      this.salary = this.salary + 1000;
  }

  get details() {
      return "First name: " + this.firstName + " Last name: " + this.lastName + " Salary: $" + this.salary; 
  }
}

var emp = new Employee("Juan", "López", 15000);

var details = emp.details;
console.log(details);

emp.add1KToSalary();

details = emp.details;
console.log(details);
