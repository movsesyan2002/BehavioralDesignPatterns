// You're building a login system for a multiplatform app. Different platforms or user preferences may require different authentication methods:
// Password-based authentication

// One-Time Password (OTP)

// Biometric (Face ID or Fingerprint)

// 🎯 Task Description
// Implement a system that supports different authentication strategies using the Strategy Design Pattern. The goal is to allow injecting different authentication behaviors at runtime.
// Required Strategies:
// PasswordAuthStrategy: Verifies username and password.


// OtpAuthStrategy: Verifies OTP sent to the user's phone/email.


// FaceIdAuthStrategy: Simulates a Face ID scan verification.

// 🏗️ Structure Hints
// IAuthStrategy interface with a method bool Authenticate(User user);

// AuthService class that uses an IAuthStrategy to perform authentication.

// User class with relevant fields (username, password, phone number, face ID metadata, etc.)


using System.Reflection.Metadata;

interface IAuthStrategy {
    bool Authenticate(User user);
}


class AuthService { 

    private IAuthStrategy _authStrategy;

    public AuthService(IAuthStrategy authStrategy) {
        _authStrategy = authStrategy;
    }

    public void SetStrategy(IAuthStrategy authStrategy) {
        _authStrategy = authStrategy;
    }

    public bool Authenticate(User user) {
        return _authStrategy.Authenticate(user);
    }

}


class PasswordAuthStrategy : IAuthStrategy {

    public bool Authenticate(User user) {
        if (user.Password.Contains("@")) {
            Console.WriteLine("Authenticating using password...\nSuccess!");
            return true;
        }
        Console.WriteLine("Authenticating using password...\nFailed!");
        return false;
    }
}


class FaceIdAuthStrategy : IAuthStrategy {

    public bool Authenticate(User user) {
        if (user.Metadata == "face-data") {
            Console.WriteLine("Authenticating using Face Id...\nFace Id match!");
            return true;
        }
        Console.WriteLine("Authenticating using Face id...\nFailed!");
        return false;
    }
}

class OtpAuthStrategy : IAuthStrategy {

    public bool Authenticate(User user) {
        if (!string.IsNullOrEmpty(user.PhoneNumber)) {
            Console.WriteLine("Authenticating using OTP...\nOTP verified successfully!");
            return true;
        }
        Console.WriteLine("Authenticating using OPT...\nFailed!");
        return false;
    }
}


class User {
    public string? Name { get; set;}
    public string? Password { get; set;}
    public string? PhoneNumber { get; set;}
    public string? Metadata { get; set;}

    public User (string name, string? password, string phoneNumber, string metadata) {
        Name = name;
        Password = password;
        PhoneNumber = phoneNumber;
        Metadata = metadata;
    }
}


