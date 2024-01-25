using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;

namespace AutomatedLearningSystem.Domain.Users;

public class User
{

    private string _password { get; set; } = null!;

    public Guid Id { get; init; }
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    private List<LearningPath> _learningPaths { get; set; } = null!;
    public List<LearningPath> LearningPaths => _learningPaths.ToList();


    public Role Role { get; private set; }



    private User(string firstName, string lastName, string email, Role role, string password,
        Guid? id = null)
    {
        _password = password;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Role = role;
        Id = id ?? Guid.NewGuid();
    }

    private User()
    {

    }
    public static User Create(
        string firstName, string lastName, string email, Role role, string password,
        Guid? id = null)
    {

      
        return new User( firstName,  lastName,  email, role,  password,
            id);
    }

    



}