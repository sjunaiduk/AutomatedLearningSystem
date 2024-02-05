using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.LearningPaths;
using Microsoft.EntityFrameworkCore;

namespace AutomatedLearningSystem.Domain.Users;

public class User
{
    private const int _maxLearningPaths = 3;
    public string Password { get; private set; }
    public Guid Id { get; init; }
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

   private List<LearningPath> _learningPaths { get; } = new();
   public IReadOnlyCollection<LearningPath> LearningPaths => _learningPaths;


    public Role Role { get; private set; }


    public Result AddLearningPath(LearningPath learningPath)
    {
        if (_learningPaths.Any(lp => lp.Id == learningPath.Id))
        {
            return LearningPathErrors.Conflict;
        }

        if (_learningPaths.Count == _maxLearningPaths)
        {
            return LearningPathErrors.LearningPathLimitReached;
        }
        _learningPaths.Add(learningPath);

        return Result.Success;
    }


    private User(string firstName, string lastName, string email, Role role, string password,
        Guid? id = null)
    {
        Password = password;
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


        return new User(firstName, lastName, email, role, password,
            id);
    }

    public void Update(string? firstName, string? lastName, string? email,
        string? password,
        Role? role)
    {
        FirstName = firstName ?? FirstName;
        LastName = lastName ?? LastName;
        Email = email ?? Email;
        Password = password ?? Password;
        Role = role ?? Role;
    }





}