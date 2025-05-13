// You are building an HR system that manages employee profiles. Every time an employee is promoted or their salary is changed, the HR system can optionally create a Memento, which is a snapshot of the profile at that exact point in time.
// Unlike undo stacks or named checkpoints, here you save a specific version as a Memento object and can restore the employee profile to that precise state later by directly calling Restore(memento).
// This approach mimics real-world versioning systems where you bookmark a version and later revert back to that exact version — without altering any other history.

// 🧱 Structure Overview
// 🔹 Originator
// EmployeeProfile

// Fields: Name, Position, Salary

// Methods:

// Promote(string newPosition, int newSalary)

// CreateMemento(): returns a snapshot of current state

// Restore(Memento m): restores state from memento

// ToString() to print current state

// 🔹 Memento
// Stores Name, Position, Salary

// Immutable, private fields

// Only accessible to EmployeeProfile

// The Memento class should be private or internal to prevent external tampering.


using System.Net;
using System.Reflection.Metadata.Ecma335;

class EmployeeProfile {

    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public EmployeeProfile(string name, decimal salary, string position) {
        Name = name;
        Salary = salary;
        Position = position;
    }

    public void Promote(string newPosition, int newSalary) {
        Position = newPosition;
        Salary = newSalary;
    }

    public Memento CreateMemento() {
        return new Memento(Name, Position, Salary);
    }

    public void Restore(Memento m) {
        var info = m.GetState();
        this.Name = info.Name;
        this.Salary = info.Salary;
        this.Position = info.Position;

    }

    public override string ToString() {
        return $"Employee: {Name}, Position: {Position} , Salary: {Salary}";
    }
    
}


class Memento {

    private readonly string? Name;
    private readonly string? Position;
    private readonly decimal Salary;

    public Memento(string? name, string? position, decimal salary) {
        Name = name;
        Position = position;
        Salary = salary;
    }


    public (string Name, string Position, decimal Salary) GetState() {
        return (Name, Position, Salary);
    }

}


class Caretaker {
    
    private EmployeeProfile employeeProfile;
    private Stack<Memento> mementos = new Stack<Memento>();

    public Caretaker(EmployeeProfile employeeProfile) {
        this.employeeProfile = employeeProfile;
    }

    public void DoSomething() {
        Memento memento = employeeProfile.CreateMemento();
        mementos.Push(memento);
    }

    public void Undo() {

        if (mementos.Count == 0) {
            Console.WriteLine("No saved states");
        }
        
        Memento memento = mementos.Pop();
        employeeProfile.Restore(memento);

    }


}
