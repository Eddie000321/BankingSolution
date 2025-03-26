💳 BankingApp Solution

This repository contains the source code for our team project implementing a Banking Application in C#. Our solution comprises two main projects:

📚 BankingAppClassLibrary: Handles core business logic including account management, transactions, logging, and event handling.

🚀 BankingApp: A console application project for integration testing, later extendable into a GUI Application.

📂 Project Structure

BankingAppSolution/
├── 📚 BankingAppClassLibrary/
│   ├── 📄 Account.cs                   (Student 5)
│   ├── 📄 AccountException.cs          (Student 3)
│   ├── 📄 AccountExceptionType.cs      (Student 5)
│   ├── 📄 Bank.cs                      (Student 1)
│   ├── 📄 Delegates.cs                 (Student 2)
│   ├── 📄 DayTime.cs                   (Student 4)
│   ├── 📄 Logger.cs                    (Student 5)
│   ├── 📄 LoginEventType.cs            (Student 1)
│   ├── 📄 LoginEventArgs.cs            (Student 1)
│   ├── 📄 Person.cs                    (Student 1)
│   ├── 📄 Transaction.cs               (Student 2)
│   ├── 📄 TransactionEventArgs.cs      (Student 4)
│   ├── 📄 Util.cs                      (Student 3)
│   ├── 📄 VisaAccount.cs               (Student 2)
│   ├── 📄 SavingAccount.cs             (Student 3)
│   └── 📄 CheckingAccount.cs           (Student 4)
│
└── 🚀 BankingApp/
    └── 📄 Program.cs                   (Integration tests)

⚙️ Getting Started

✅ Prerequisites

Visual Studio 2022 or later

.NET Core / .NET Framework (depending on your setup)

🛠️ Installation & Setup

Clone the repository:

git clone <repository-url>

Open Solution:

Open BankingAppSolution.sln in Visual Studio.

Build the Solution:

Use Ctrl+Shift+B to build all projects.

Run the Application:

Set BankingApp as the startup project.

Press F5 to run integration tests.

🧑‍💻 Team Members & Responsibilities

Student

Responsibilities

Student 1

LoginEventType.cs, LoginEventArgs.cs, Person.cs, Bank.cs

Student 2

Delegates.cs, Transaction.cs, VisaAccount.cs

Student 3

AccountException.cs, Util.cs, SavingAccount.cs

Student 4

TransactionEventArgs.cs, DayTime.cs, CheckingAccount.cs

Student 5

AccountExceptionType.cs, Logger.cs, Account.cs

Each team member is responsible for maintaining their assigned components. Integration is managed collaboratively in the BankingApp project.

🌐 Collaboration & Workflow

🌿 Branching Strategy

Use feature branches for individual tasks.

Create Pull Requests for code reviews.

Merge to main branch after approval.

✨ Code Standards

Follow consistent coding styles.

Clearly document interfaces and methods.

📢 Communication

Regular meetings to synchronize and update project status.

🚧 Future Enhancements

🖥️ GUI Extension:

Develop a graphical user interface using Windows Forms or WPF.

✅ Unit Testing:

Add comprehensive unit tests to ensure code quality.

📜 License



🙌 Acknowledgements

This project was developed as a team assignment for the Programming II course. Special thanks to our instructors for their guidance and support.

